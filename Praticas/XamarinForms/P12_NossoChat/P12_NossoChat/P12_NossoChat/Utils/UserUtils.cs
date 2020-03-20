using System;
using System.Collections.Generic;
using System.Text;
using P12_NossoChat.Model;
using Newtonsoft.Json;

namespace P12_NossoChat.Utils
{
    public class UserUtils
    {
        public static Usuario UserLogged {
            get {
                Usuario userLogged = null;
                if(App.Current.Properties["LOGIN"] is string user) {
                    userLogged = JsonConvert.DeserializeObject<Usuario>(user);
                }
                return userLogged;
            }
            set {
                App.Current.Properties["LOGIN"] = JsonConvert.SerializeObject(value);
            }
        }
    }
}
