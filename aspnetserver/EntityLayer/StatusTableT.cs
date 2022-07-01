using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace aspnetserver.EntityLayer
{
    public partial class StatusTableT
    {
        public StatusTableT()
        {
            TbTasks = new HashSet<TbTaskT>();
        }
        [Key]
        public int StatusId { get; set; }
        public string SDetail { get; set; }
        [JsonIgnore]
        public virtual ICollection<TbTaskT> TbTasks { get; set; }
    }
}
