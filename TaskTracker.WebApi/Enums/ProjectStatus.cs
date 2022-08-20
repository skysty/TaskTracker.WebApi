using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace TaskTracker.WebApi.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProjectStatus
    {
        NotStarted,
        Active,
        Completed
    }
}
