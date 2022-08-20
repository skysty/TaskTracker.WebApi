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
    public class ProjectWithIdModel
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ProjectStatus ProjectStatus { get; set; }
        public DateTime? EditDate { get; set; }
        public int Priority { get; set; }
    }
}
