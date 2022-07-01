
using System.ComponentModel.DataAnnotations;
namespace aspnetserver.Data
{
    public class Project
    {

        [Key]
        public int PojectId { get; set; }
       
       
        public string ProjectName { get; set; }
     
       
        public string ? ProjectDescription { get; set; } = string.Empty;
      
        public string ? CreatedBy { get; set; } = string.Empty;
        public DateTime ? startdate { get; set; }


        //public List<KanbanTask> TbTasks { get; set; } = new List<KanbanTask>();
    }
}
