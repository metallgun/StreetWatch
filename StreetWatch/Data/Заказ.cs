//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StreetWatch.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Заказ
    {
        public Заказ()
        {
            this.Исполнение_заказа = new HashSet<Исполнение_заказа>();
        }
    
        public int IDЗаказа { get; set; }
        public Nullable<double> Коорд1 { get; set; }
        public Nullable<double> Коорд2 { get; set; }
        public Nullable<System.DateTime> ДатаСоздания { get; set; }
        public string Комментарий { get; set; }
        public Nullable<System.DateTime> PlanDate { get; set; }
        public Nullable<int> Urgent { get; set; }
        public string Описание { get; set; }
        public Nullable<int> IDПользователя { get; set; }
        public Nullable<int> maxКолвоИсполнителей { get; set; }
        public Nullable<int> minКолвоИсполнителей { get; set; }
        public Nullable<int> Статус { get; set; }
    
        public virtual Заказчик Заказчик { get; set; }
        public virtual ICollection<Исполнение_заказа> Исполнение_заказа { get; set; }
    }
}
