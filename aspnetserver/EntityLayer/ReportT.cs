using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace aspnetserver.EntityLayer
{
    public partial class ReportT
    {
        [Key]
        public int ReportId { get; set; }
        public int? PId { get; set; }
        public string Email { get; set; }
        public int Taskstatus { get; set; }
        public string TaskDetails { get; set; }
        public string WhatAction { get; set; }
        public DateTime? ReportedOn { get; set; }
        [JsonIgnore]
        public virtual ProjectT PIdNavigation { get; set; }
    }
}
