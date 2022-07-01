using System.ComponentModel.DataAnnotations;
namespace aspnetserver.Data
{
    public class Reportcs
    {
        [Key]
        public int? RId { get; set; }
        public int? PId { get; set; }
        public string Email { get; set; }
        public int Taskstatus { get; set; }
        public string TaskDetails { get; set; }
        public string WhatAction { get; set; }
        public DateTime? ReportedOn { get; set; }
        public Project PIdNavigation { get; set; }
    }
}
