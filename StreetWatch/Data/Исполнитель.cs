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
    
    public partial class Исполнитель
    {
        public Исполнитель()
        {
            this.Исполнение_заказа = new HashSet<Исполнение_заказа>();
        }
    
        public int IDПользователя { get; set; }
        public Nullable<int> ГотовНеготов { get; set; }
        public Nullable<double> ПослМесто1 { get; set; }
        public Nullable<double> ПослМесто2 { get; set; }
    
        public virtual ICollection<Исполнение_заказа> Исполнение_заказа { get; set; }
        public virtual Пользователь Пользователь { get; set; }
    }
}
