using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;
using TaskTracker.WebApi.Enums;

namespace TaskTracker.WebApi.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TaskkStatus TaskkStatus { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        //public DateTime? EditDate { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public int ProjectId { get; set; }
    }
}
