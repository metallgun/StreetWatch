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
    
    public partial class Заказчик
    {
        public Заказчик()
        {
            this.Заказ = new HashSet<Заказ>();
        }
    
        public int IDПользователя { get; set; }
        public Nullable<int> БалансСчета { get; set; }
    
        public virtual ICollection<Заказ> Заказ { get; set; }
        public virtual Пользователь Пользователь { get; set; }
    }
}
