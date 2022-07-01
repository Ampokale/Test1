using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace aspnetserver.EntityLayer
{
    public partial class ProjectMemberT
    {
        [Key]
        public int ProjMemberId { get; set; }
        public int? ProjectId { get; set; }
        public int? UserId { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public virtual UserT EmailNavigation { get; set; }
        [JsonIgnore]
        public virtual ProjectT Project { get; set; }
        [JsonIgnore]
        public virtual UserT User { get; set; }
    }
}
