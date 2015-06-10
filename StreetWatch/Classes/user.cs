using StreetWatch.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreetWatch.Classes
{
    public class user
    {
        /// <summary>
        /// почта
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// идентификатор
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// сессия
        /// </summary>
        public Session userSession { get; set; }

        /// <summary>
        /// имя
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// зарегистрирован ли пользователь?
        /// </summary>
        public bool registered { get; set; }
    }
}