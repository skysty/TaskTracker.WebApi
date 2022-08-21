using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TaskTracker.WebApi.Enums;

namespace TaskTracker.WebApi.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TaskkStatus TaskkStatus { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTime? EditDate { get; set; }
        //[System.Text.Json.Serialization.JsonIgnore]
        //[Newtonsoft.Json.JsonIgnore]
        public int ProjectId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public ProjectViewModel ProjectViewModel { get; set; }
    }
}
