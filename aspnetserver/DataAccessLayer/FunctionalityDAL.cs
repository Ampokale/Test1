using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using aspnetserver.EntityLayer;
namespace aspnetserver.DataAccessLayer
{
    public class FunctionalityDAL
    {
        private NetFSDContext _context; 
        public FunctionalityDAL()
        {
            _context = new NetFSDContext();
        }
        public IEnumerable<TbTaskT> getProjTable (int i)
        {
            return _context.TbTasks.Where(t => t.PId == i).ToList();
        }
    }
}
