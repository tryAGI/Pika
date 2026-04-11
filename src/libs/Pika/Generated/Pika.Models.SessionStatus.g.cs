
#nullable enable

namespace Pika
{
    /// <summary>
    /// Session lifecycle status
    /// </summary>
    public enum SessionStatus
    {
        /// <summary>
        /// 
        /// </summary>
        Closed,
        /// <summary>
        /// 
        /// </summary>
        Created,
        /// <summary>
        /// 
        /// </summary>
        Error,
        /// <summary>
        /// 
        /// </summary>
        Pending,
        /// <summary>
        /// 
        /// </summary>
        Ready,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class SessionStatusExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this SessionStatus value)
        {
            return value switch
            {
                SessionStatus.Closed => "closed",
                SessionStatus.Created => "created",
                SessionStatus.Error => "error",
                SessionStatus.Pending => "pending",
                SessionStatus.Ready => "ready",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static SessionStatus? ToEnum(string value)
        {
            return value switch
            {
                "closed" => SessionStatus.Closed,
                "created" => SessionStatus.Created,
                "error" => SessionStatus.Error,
                "pending" => SessionStatus.Pending,
                "ready" => SessionStatus.Ready,
                _ => null,
            };
        }
    }
}