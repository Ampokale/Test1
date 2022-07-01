using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using aspnetserver.EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace aspnetserver.DataAccessLayer
{
    public class taskDAL : IRepository<TbTaskT>
    {
        private NetFSDContext context;
        public taskDAL()
        {
            context = new NetFSDContext();
        }
        public bool Add(TbTaskT entity)
        {

            {
                context.TbTasks.Add(entity);
                int affectedRecords = context.SaveChanges();
                if (affectedRecords > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public TbTaskT GetByID(int id)
        {
            return context.TbTasks.Find(id);
        }

        public IEnumerable<TbTaskT> GetAll()
        {
            return context.TbTasks.ToList();
        }

        public bool Delete(int id)
        {
            var tsk = context.TbTasks.Find(id);
            context.TbTasks.Remove(tsk);
            int affectedRecords = context.SaveChanges();
            if (affectedRecords > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(TbTaskT t)
        {
            bool op = false;
            try
            {
                context.TbTasks.Update(t);
                context.SaveChanges();
                op = true;
            }
            catch (Exception)
            {

                throw new Exception("Not Updated");
            }
            return op;
        }


    }
}
