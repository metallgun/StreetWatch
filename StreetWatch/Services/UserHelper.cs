using StreetWatch.Classes;
using StreetWatch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreetWatch.Service
{
    /// <summary>
    /// средство поддержки авторизации
    /// </summary>
    public class UserHelper
    {
        public UserHelper()
        {
            CheckUser();
        }

        /// <summary>
        /// текущий пользователь, под которым был осуществлён вход в систему
        /// </summary>
        public user CurrentUser { get; set; }

        public void CheckUser()
        {
            if (HttpContext.Current != null)
            {
                var context = HttpContext.Current;

                UserServices service = new UserServices();
                var session_c = context.Request.Cookies.Get("session");
                var session = session_c == null ? null : session_c.Value;
                var uid_c = context.Request.Cookies.Get("id");
                var uid = uid_c == null ? null : uid_c.Value;
                if (uid == null || 
                    session == null)
                {
                    // завершить обработку, если аутентификация невозможна
                    IsOk = false;
                    CurrentUser = null;
                }
                else
                {
                    // попытаемся продлить сессию
                    Session session_data;
                    var session_is_ok = service.CheckSession(session, int.Parse(uid), out session_data);

                    if (session_is_ok == true)
                    {
                        IsOk = true;
                        int id = int.Parse(uid);
                        CurrentUser = service.GetUserById(id);
                        if (CurrentUser.registered == false)
                        {
                            IsOk = false;
                        }
                        else
                        {
                            service.userID = id;
                            CurrentUser.userSession = session_data;
                        }
                    }
                    else
                    {
                        IsOk = false;
                    }
                }
                Service = service;
            }
            else
            {
                Service = null;
                IsOk = false;
            }
        }
        public bool IsOk { get; set; }
        public UserServices Service{get;set;}

        public void GoToLogin()
        {
            var context = HttpContext.Current;
            context.Response.Redirect("~/Authentication/logon.aspx", true);
        }

        public void EndSession()
        {
            var session_ = CurrentUser.userSession.code;
            Service.EndSession(session_);
            IsOk = false;
        }


        /// <summary>
        /// проверка необходимости прохождения аутентификации пользователя
        /// </summary>
        public bool NeedsAuth
        {
            get
            {
                var context = HttpContext.Current;
                switch (System.IO.Path.GetFileName(context.Request.Url.AbsolutePath).ToLower())
                {
                    case "logon.aspx":
                    case "default.aspx":
                        return false;
                }
                return true;
            }
        }
    }
}