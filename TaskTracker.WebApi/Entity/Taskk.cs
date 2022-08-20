using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TaskTracker.WebApi.Enums;

namespace TaskTracker.WebApi.Entity
{
    public class Taskk
    {
        [Key]
        public int Id { get; set; }
        public string TaskName { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TaskStatus TaskStatus { get; set; }
        public string Description { get; set; }
        public int  Priority { get; set; }
        public DateTime? EditDate { get; set; }
        public int ProjectId { get; set; }

    }
}
