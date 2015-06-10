using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreetWatch.Services
{
    public class OrderService
    {
        public void NewOrder(int IDuser, Classes.Order order)
        {
            var db = new Data.StreetWatchDataBaseEntities1();
            var db_order = new Data.Заказ();
            if(CheckOrderer(IDuser))
            {
                var db_orderer = new Data.Заказчик();
                db_orderer.IDПользователя = IDuser;
                db.Заказчик.Add(db_orderer);
            }
            db_order.Коорд1 = order.Coord1;
            db_order.Коорд2 = order.Coord2;
            db_order.ДатаСоздания = order.CreationDate;
            db_order.Комментарий = order.Comment;
            db_order.PlanDate = order.PlanDate;
            db_order.Urgent = order.Urgent;
            db_order.Статус = order.Status;
            order.IDuser = IDuser;
            db_order.IDПользователя = order.IDuser;
            db.Заказ.Add(db_order);
            db.SaveChanges();
            int i = db_order.IDЗаказа;
        }

        public static void payForOrder(int orderId)
        {
            var db = new Data.StreetWatchDataBaseEntities1();
            var c = db.Заказ.Where(x => x.IDЗаказа == orderId).First();
            c.Статус = 1;
            db.SaveChanges();
        }

        private bool CheckOrderer(int IDuser)
        {
            var db = new Data.StreetWatchDataBaseEntities1();
            var db_query = db.Заказчик.Where(x => x.IDПользователя == IDuser).Count();
            return db_query == 0;
        }
    }
}