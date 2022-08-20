using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace TaskTracker.WebApi.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TaskStatus
    {
        ToDo,
        InProgress,
        Done
    }
}
