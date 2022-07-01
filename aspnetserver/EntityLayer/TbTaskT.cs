using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace aspnetserver.EntityLayer
{
    public partial class TbTaskT
    {
        [Key]
        public int TId { get; set; }
        public int? PId { get; set; }
        public string AssignedTo { get; set; }
        public string TaskDetails { get; set; }
        public int? TaskStatus { get; set; }
        public string AssignedBy { get; set; }
        [JsonIgnore]
        public virtual ProjectT PIdNavigation { get; set; }
        [JsonIgnore]
        public virtual StatusTableT TaskStatusNavigation { get; set; }
    }
}
