using System.ComponentModel.DataAnnotations;
namespace aspnetserver.Data
{
    public class ProjectMembers
    {
        [Key]
        public int project_MId { get; set; }
        public int? projectId { get; set; }
        public int? UserID { get; set; }


        //public Project Project { get; set; }
        //public User User { get; set; }
    }
}

