using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using aspnetserver.EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace aspnetserver.DataAccessLayer
{
    public class ProjectsDAL : IRepository<ProjectT>
    {

        private NetFSDContext context = new NetFSDContext();

        public List<ProjectMemberT> GetProjects(int uid)
        {

            //var projects = new List<Project>();
            List<ProjectMemberT> projects = context.ProjectMembers.Where(t => t.UserId == uid).ToList();
            return projects;
        }


        public List<ProjectT> GetProjectsByUid(int sid)
        {

            var projects = new List<ProjectT>();
            List<ProjectMemberT> p = context.ProjectMembers.Where(t => t.UserId == sid).ToList();

            foreach (var item in p)
            {

                var name = context.Projects.Where(t => t.ProjectId == Convert.ToInt32(item.ProjectId)).FirstOrDefault();
                //projects.Add(name);


            }
            return projects;
        }

        public List<ProjectT> GetProjectsByPid(int pid)
        {

            //var projects = new List<Project>();
            List<ProjectT> projects = context.Projects.Where(t => t.ProjectId == pid).ToList();
            return projects;
        }

        public bool Add(ProjectT entity)
        {
            context.Projects.Add(entity);
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

        public ProjectT GetByID(int id)
        {
            return context.Projects.AsNoTracking().FirstOrDefault(
                e => e.ProjectId == id);
        }

        public IEnumerable<ProjectT> GetAll()
        {
            IEnumerable<ProjectT> p= context.Projects.ToList();
            return p;
        }

        public bool Delete(int id)
        {
            var proj = context.Projects.Find(id);
            //context.Projects.Remove(proj);
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

        public bool Update(ProjectT entity)
        {
            //context
            context.Projects.Update(entity);
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

