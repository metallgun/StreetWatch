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
    
    public partial class СессияПользователя
    {
        public long Id_Сессии { get; set; }
        public Nullable<System.DateTime> ВремяНачала { get; set; }
        public Nullable<int> Id_Пользователя { get; set; }
        public string КодСессии { get; set; }
    
        public virtual Пользователь Пользователь { get; set; }
    }
}
