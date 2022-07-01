using aspnetserver.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aspnetserver.DataAccessLayer
{
    public class userDAL : IRepository<UserT>
    {
        private NetFSDContext db = new NetFSDContext();


        public IEnumerable<UserT> GetAll()
        {
            IEnumerable<UserT> users = db.Users.ToList();



            foreach (UserT u in users)
            {
                u.Password = "********";
            }
            return users;


        }



        public bool Add(UserT t)
        {
            bool op = false;
            try
            {
                db.Users.Add(t);
                db.SaveChanges();
                op = true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return op;
        }

        public bool Delete(int t)
        {
            bool op = false;
            try
            {
                UserT u = db.Users.Find(t);
                db.Users.Remove(u);
                if (db.SaveChanges() > 0)
                    op = true;


            }
            catch (Exception)
            {

                throw new Exception("Not Deleted");
            }
            return op;
        }



        public bool Update(UserT t)
        {
            bool op = false;
            try
            {
                db.Users.Update(t);
                db.SaveChanges();
                op = true;
            }
            catch (Exception)
            {

                throw new Exception("Not Updated");
            }
            return op;
        }

        public UserT GetByID(int t)
        {
            UserT u = new UserT();
            u = db.Users.Find(t);
            return u;
        }
    }
}
