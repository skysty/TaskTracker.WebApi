using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TaskTracker.WebApi.Enums;

namespace TaskTracker.WebApi.Entity
{
    public class Projectt
    {
        [Key]
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate  { get; set; }
        public DateTime CompletionDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ProjectStatus ProjectStatus { get; set; }
        public DateTime? EditDate  { get; set; }
        public int Priority { get; set; }
    }
}
