using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace aspnetserver.EntityLayer
{
    public partial class ProjectT
    {
        public ProjectT()
        {
            TbTasks = new HashSet<TbTaskT>();
        }
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDesc { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Startdate { get; set; }
        [JsonIgnore]
        public virtual UserT CreatedByNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<TbTaskT> TbTasks { get; set; }
    }
}
