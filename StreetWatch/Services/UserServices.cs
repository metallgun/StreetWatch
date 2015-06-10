
using StreetWatch.Authentication;
using StreetWatch.Classes;
using StreetWatch.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreetWatch.Services
{
    public class UserServices
    {

        /// <summary>
        /// словарь с вариантами поощрения человека
        /// </summary>

        public int userID { get; set; }

        /// <summary>
        /// получить доступные пользоватлею методы идентификации
        /// </summary>
        /// <returns></returns>

        /// <summary>
        /// создать пользователя
        /// </summary>
        /// <returns></returns>
        public void CreateUser(string umail, string hashPass, string surn, string name, string del, out int idu)
        {
            //сделать хэш пароля
            var db = new Data.StreetWatchDataBaseEntities1();
            Пользователь u = new Пользователь();
            u.Почта = umail;
            u.Имя = name;
            u.Фамилия = surn;
            u.Обращение = del;
            u.ХэшПароля = hashPass;
            db.Пользователь.Add(u);
            try
            {
                db.SaveChanges();
            }
            catch (Exception e) { }
            idu = u.IDПользователя;
            db.Database.Connection.Close();
        }

        public bool CheckUser(string p)
        {
            var db = new Data.StreetWatchDataBaseEntities1();
            var found_users_count = db.Пользователь.Where(x => x.Почта == p).Count();
            db.Database.Connection.Close();
            return found_users_count > 0;
        }

        public void CreateExecutioner(Classes.Executioner executioner)
        {
            var db = new Data.StreetWatchDataBaseEntities1();
            Исполнитель exec = new Исполнитель();
            exec.IDПользователя = executioner.Id;
            exec.ГотовНеготов = executioner.ready;
            exec.ПослМесто1 = executioner.lastPlace1;
            exec.ПослМесто2 = executioner.lastPlace2;
            db.Исполнитель.Add(exec);
            db.SaveChanges();
            db.Database.Connection.Close();
        }

        public bool CheckExecutionerById(int idUser)
        {
            var db = new Data.StreetWatchDataBaseEntities1();
            var query = db.Исполнитель.Where(x => x.IDПользователя == idUser).Count();
            db.Database.Connection.Close();
            return query > 0;
        }

        public user GetUserById(int id)
        {
            var db = new Data.StreetWatchDataBaseEntities1();
            var found_user = db.Пользователь.Where(x => x.IDПользователя == id).SingleOrDefault();
            db.Database.Connection.Close();
            if (found_user != null)
            {
                user result = new user();
                result.email = found_user.Почта;
                result.id = found_user.IDПользователя;
                result.name = found_user.Имя;

                //result.registered = found_user.Зарегистрирован == 1;
                return result;
            }
            else
            {
                return null;
            }
        }

        public bool AcceptUser(int id)
        {
            bool result = false;
            var db = new Data.StreetWatchDataBaseEntities1();
            var user_db = db.Пользователь.Where(x => x.IDПользователя == id)
                .SingleOrDefault();
            if (user_db != null)
            {
                db.SaveChanges();
                result = true;
            }
            db.Database.Connection.Close();
            return result;
        }

        public user LogonUser(string email, string ppw)
        {
            var db = new Data.StreetWatchDataBaseEntities1();
            var found_user = db.Пользователь.Where(x => x.Почта == email && x.ХэшПароля==ppw)
                .SingleOrDefault();
            db.Database.Connection.Close();
            if (found_user != null)
            {
                user result = new user();
                result.email = found_user.Почта;
                result.id = found_user.IDПользователя;

                result.userSession = startSession(found_user.IDПользователя);
                return result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// сделать запись о сессии
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        protected Session startSession(int uid)
        {
            Session session_result = new Session();

            var db = new Data.StreetWatchDataBaseEntities1();
            СессияПользователя session_data = new СессияПользователя();
            session_data.ВремяНачала = DateTime.Now;
            session_data.Id_Пользователя = uid;
            db.СессияПользователя.Add(session_data);
            db.SaveChanges();

            long session_id = session_data.Id_Сессии;
            string session_key = session_id +""+ DateTime.Now.Ticks;

            Enc e = new Enc();
            session_key = e.Encode(session_key, "user"+uid);

            session_data.КодСессии = session_key;
            db.SaveChanges();

            session_result.code = session_key;
            session_result.start = session_data.ВремяНачала;
            return session_result;
        }

        /// <summary>
        /// продолжить выполнение сессии
        /// </summary>
        /// <param name="sessionCode"></param>
        /// <param name="uid"></param>
        /// <returns>если продление выполнено успешно - возвращает объект сессии; иначе - null</returns>
        protected Session continueSession(string sessionCode, int uid)
        {
            var session_result = new Session();
            var db = new Data.StreetWatchDataBaseEntities1();
            var found_session = db
                .СессияПользователя
                .Where(x => x.КодСессии == sessionCode
                        && x.Id_Пользователя == uid)
                        .SingleOrDefault();

            if (found_session != null)
            {
                session_result.code = found_session.КодСессии;
                session_result.start = found_session.ВремяНачала;
                return session_result;
            }
            else return null;
        }
        
        /// <summary>
        /// проверить сессию
        /// </summary>
        /// <param name="sessionkey"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public bool CheckSession(string sessionkey, int uid, out Session currentSession)
        {
            var session_object = this.continueSession(sessionkey, uid);
            currentSession = session_object;
            if (session_object == null)
                return false;
            else return true;
        }


        /// <summary>
        /// завершить сессию
        /// </summary>
        public bool EndSession(string sessionkey)
        {
            var db = new Data.StreetWatchDataBaseEntities1();
            var found_session = db
                .СессияПользователя
                .Where(x=>x.КодСессии == sessionkey)
                        .SingleOrDefault();

            if (found_session != null)
            {
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// проверить наличие логина в базе данных
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>

        public void RemoveUser(int id_user)
        {
            throw new NotImplementedException();
        }
    }
}