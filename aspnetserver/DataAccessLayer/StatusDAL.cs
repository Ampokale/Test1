using aspnetserver.EntityLayer;
namespace aspnetserver.DataAccessLayer
{
    public class StatusDAL: IRepository<StatusTableT>
    {
        private NetFSDContext db = new NetFSDContext();
        public IEnumerable<StatusTableT> GetAll()
        {
            IEnumerable<StatusTableT> users = db.StatusTables.ToList();

            return users;
        }
        public bool Add(StatusTableT t)
        {
            bool op = false;
            try
            {
                db.StatusTables.Add(t);
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
                StatusTableT u = db.StatusTables.Find(t);
                db.StatusTables.Remove(u);
                if (db.SaveChanges() > 0)
                    op = true;


            }
            catch (Exception)
            {

                throw new Exception("Not Deleted");
            }
            return op;
        }



        public bool Update(StatusTableT t)
        {
            bool op = false;
            try
            {
                db.StatusTables.Update(t);
                db.SaveChanges();
                op = true;
            }
            catch (Exception)
            {

                throw new Exception("Not Updated");
            }
            return op;
        }

        public StatusTableT GetByID(int t)
        {
            StatusTableT u = new StatusTableT();
            u = db.StatusTables.Find(t);
            return u;
        }
    }
}
