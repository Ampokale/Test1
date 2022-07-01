using System.ComponentModel.DataAnnotations;

namespace aspnetserver.Data
{
    public class User
    {

        [Key]
        public int UserId { get; set; }
       

        
        public string FirstName { get; set; } 

        
        public string LastName { get; set; } 
      

        
        public string Email { get; set; } 

        
        public string password { get; set; }

        
        public string? Role { get; set; }

        //public List<Project> Projects { get; set; } = new List<Project>();
    }
}
