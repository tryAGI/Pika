
#nullable enable

#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS3016 // Arrays as attribute arguments is not CLS-compliant

namespace Pika
{
    /// <summary>
    /// 
    /// </summary>
    [global::System.Text.Json.Serialization.JsonSourceGenerationOptions(
        DefaultIgnoreCondition = global::System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        Converters = new global::System.Type[]
        {
            typeof(global::Pika.JsonConverters.MeetingPlatformJsonConverter),

            typeof(global::Pika.JsonConverters.MeetingPlatformNullableJsonConverter),

            typeof(global::Pika.JsonConverters.SessionStatusJsonConverter),

            typeof(global::Pika.JsonConverters.SessionStatusNullableJsonConverter),

            typeof(global::Pika.JsonConverters.UnixTimestampJsonConverter),
        })]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Pika.JsonSerializerContextTypes))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Pika.BalanceResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(double))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(string))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Pika.TopupProductsResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Pika.TopupProduct>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Pika.TopupProduct))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(int))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Pika.TopupRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Pika.TopupResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Pika.MeetingPlatform), TypeInfoPropertyName = "MeetingPlatform2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Pika.CreateMeetingSessionRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(byte[]))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Pika.MeetingSessionResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Pika.SessionStatus), TypeInfoPropertyName = "SessionStatus2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Pika.SessionStatusResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(bool))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Pika.DeleteSessionResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Pika.CloneVoiceRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Pika.CloneVoiceResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.DateTime))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Pika.GenerateAvatarRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Pika.GenerateAvatarResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Pika.TopupProduct>))]
    public sealed partial class SourceGenerationContext : global::System.Text.Json.Serialization.JsonSerializerContext
    {
    }
}