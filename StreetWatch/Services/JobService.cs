using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreetWatch.Services
{
    public class JobService
    {
        public static void NewJob(Classes.Job job)
        {
            var db = new Data.StreetWatchDataBaseEntities1();
            var db_order = new Data.Исполнение_заказа();
            db_order.IDЗаказа = job.JobId;
            db_order.IDИсполнителя = job.ExecutorId;
            db_order.Времяподтверждения = job.confirmDate;
            db_order.ДатавремяИсполнения = job.executDate;
            db_order.СделаноНесделано = job.Status;
            db.Исполнение_заказа.Add(db_order);
            db.SaveChanges();
        }

        public static void FulfillJob(Classes.Result result)
        {
            var db = new Data.StreetWatchDataBaseEntities1();
            var db_result = new Data.Результат();
            var db_detailedresult = new Data.ДеталиРезультата();
            var photo = new Data.Фото();
            db_result.IDЗаказа = result.orderId;
            var query = db.Заказ.Where(x=> x.IDЗаказа == result.orderId);
            foreach(var c in query)
            {
                db_result.IDПользователя = int.Parse(c.IDПользователя.Value.ToString());
            }
            db_detailedresult.IDЗаказа = result.orderId;
            db_detailedresult.IDПользователя = db_result.IDПользователя;
            db_detailedresult.КомментКФотке = result.photoComment;
            photo.ПутьКФото = result.photoLink;
            db.Фото.Add(photo);
            db_detailedresult.IDФото = photo.IDФото;
            db.ДеталиРезультата.Add(db_detailedresult);
            db.Результат.Add(db_result);
            var updater = db.Исполнение_заказа.Where(x => x.IDЗаказа == result.orderId).First();
            updater.ДатавремяИсполнения = DateTime.Now;
            updater.СделаноНесделано = 1;
            db.SaveChanges();
        }
    }
}