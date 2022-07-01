using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    public class KanbanContext : DbContext
    {
        public KanbanContext(DbContextOptions options)
                  : base(options)
        {


        }
        public KanbanContext()
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlite("Data Source=./Data/AppDB.db");
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlServer("data source = vm2\\SQLEXPRESS; initial catalog = kanban; persist security info=True;Integrated Security = SSPI");
        //public DbSet<Login> login { get; set; }
        public DbSet<Project> project { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<ProjectMembers> projectMember { get; set; }
        public DbSet<Status> status { get; set; }
        public DbSet<KanbanTask>  task{ get; set; }
        public DbSet<Reportcs> reports{ get; set; }
        //public DbSet<Status> report { get; set; }


    }
}
