using System;
using System.Collections.Generic;
using System.Linq;
using aspnetserver.EntityLayer;
namespace aspnetserver.DataAccessLayer
{
    public class loginDAL
    {
        private NetFSDContext db;
        public loginDAL()
        {
            db = new NetFSDContext();
        }


        public UserT loginUser(LoginClass u)
        {
            UserT? op = null;
            UserT logged = db.Users.Where(t => t.Email == u.UserName && t.Password == u.Password).FirstOrDefault();
            if(logged != null)
            {
                 op = logged;
            }
            
            return op;
        }


       
    }
}
