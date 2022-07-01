using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    public class AppDBContext:DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Project> project { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<ProjectMembers> projectMember { get; set; }
        public DbSet<Status> status { get; set; }
        public DbSet<KanbanTask> task { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlite("Data Source=./Data/AppDB.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Post[] postsToSeed = new Post[6];
            for (int i = 1; i < 7; i++)
            {
                postsToSeed[i - 1] = new Post
                {
                    PostId = i,
                    Title = $"Post {i}",
                    Content = $"this is post {i} content"
                };
            }
            modelBuilder.Entity<Post>().HasData(postsToSeed);

        }
    }
}
