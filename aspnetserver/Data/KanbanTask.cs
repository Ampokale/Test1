using System.ComponentModel.DataAnnotations;
namespace aspnetserver.Data
{
    public class KanbanTask
    { 

        [Key]
        public int TId { get; set; }
        public int PId { get; set; }
       
        
        public string ?AssignTo { get; set; }
        
     
        public string? TaskDetails { get; set; }
        public int TaskStatusId { get; set; }

      
        public string? AssignBy { get; set; }

        //public Project PIdNavigation { get; set; }

        //public Status TaskStatusNavigation { get; set; }
    }
   

}
