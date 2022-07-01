using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using aspnetserver.EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace aspnetserver.DataAccessLayer
{
    public class projectMemberDAL : IRepository<ProjectMemberT>
    {
        private NetFSDContext context=new NetFSDContext();

        public projectMemberDAL(NetFSDContext context)
        {
            this.context = context;
        }
        public projectMemberDAL()
        {

        }
        public bool Add(ProjectMemberT entity)
        {
            int affectedRecords = 0;
            UserT userTObj= context.Users.FirstOrDefault(x => x.UserId == entity.UserId);
            ProjectT projectTobj=context.Projects.FirstOrDefault(x=>x.ProjectId == entity.ProjectId);
            if(userTObj!=null || projectTobj != null)
            {
                //projectTobj.;
                //entity.User = userTObj;
                //entity.EmailNavigation = userTObj;

                context.ProjectMembers.Add(entity);
                affectedRecords = context.SaveChanges();
            }
            
            if (affectedRecords > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public ProjectMemberT GetByID(int id)
        {
            return context.ProjectMembers.AsNoTracking().FirstOrDefault(
                e => e.ProjectId == Convert.ToInt32(id));
        }

        public IEnumerable<ProjectMemberT> GetAll()
        {
            return context.ProjectMembers.ToList();
        }

        public bool Delete(int id)
        {
            var proj = context.ProjectMembers.Find(id);
            //context.ProjectMembers.Remove(proj);
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

        public bool Update(ProjectMemberT entity)
        {
            //context
            context.ProjectMembers.Update(entity);
            int affectedrecords = context.SaveChanges();
            if (affectedrecords > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
