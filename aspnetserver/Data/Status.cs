using System.ComponentModel.DataAnnotations;
namespace aspnetserver.Data
{
    public class Status
    {

        [Key]
        public int StatusId { get; set; }

        //public List<KanbanTask> TbTasks { get; set; } = new List<KanbanTask>();

        public string ? StatusDetails { get; set; }

        
    }
}
