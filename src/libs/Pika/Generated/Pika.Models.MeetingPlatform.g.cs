
#nullable enable

namespace Pika
{
    /// <summary>
    /// The video meeting platform
    /// </summary>
    public enum MeetingPlatform
    {
        /// <summary>
        /// 
        /// </summary>
        GoogleMeet,
        /// <summary>
        /// 
        /// </summary>
        Zoom,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class MeetingPlatformExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this MeetingPlatform value)
        {
            return value switch
            {
                MeetingPlatform.GoogleMeet => "google_meet",
                MeetingPlatform.Zoom => "zoom",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static MeetingPlatform? ToEnum(string value)
        {
            return value switch
            {
                "google_meet" => MeetingPlatform.GoogleMeet,
                "zoom" => MeetingPlatform.Zoom,
                _ => null,
            };
        }
    }
}