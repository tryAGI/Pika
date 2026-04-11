
#nullable enable

namespace Pika
{
    public partial class SessionsClient
    {


        private static readonly global::Pika.EndPointSecurityRequirement s_CreateMeetingSessionSecurityRequirement0 =
            new global::Pika.EndPointSecurityRequirement
            {
                Authorizations = new global::Pika.EndPointAuthorizationRequirement[]
                {                    new global::Pika.EndPointAuthorizationRequirement
                    {
                        Type = "Http",
                        SchemeId = "HttpBearer",
                        Location = "Header",
                        Name = "Bearer",
                        FriendlyName = "Bearer",
                    },
                },
            };
        private static readonly global::Pika.EndPointSecurityRequirement[] s_CreateMeetingSessionSecurityRequirements =
            new global::Pika.EndPointSecurityRequirement[]
            {                s_CreateMeetingSessionSecurityRequirement0,
            };
        partial void PrepareCreateMeetingSessionArguments(
            global::System.Net.Http.HttpClient httpClient,
            global::Pika.CreateMeetingSessionRequest request);
        partial void PrepareCreateMeetingSessionRequest(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpRequestMessage httpRequestMessage,
            global::Pika.CreateMeetingSessionRequest request);
        partial void ProcessCreateMeetingSessionResponse(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage);

        partial void ProcessCreateMeetingSessionResponseContent(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage,
            ref string content);

        /// <summary>
        /// Create a meeting session with avatar<br/>
        /// Joins a Google Meet or Zoom call with an AI-powered avatar.<br/>
        /// Requires a reference image for the avatar appearance, a voice ID for speech synthesis,<br/>
        /// and the meeting URL to join.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Pika.ApiException"></exception>
        public async global::System.Threading.Tasks.Task<global::Pika.MeetingSessionResponse> CreateMeetingSessionAsync(

            global::Pika.CreateMeetingSessionRequest request,
            global::Pika.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            request = request ?? throw new global::System.ArgumentNullException(nameof(request));

            PrepareArguments(
                client: HttpClient);
            PrepareCreateMeetingSessionArguments(
                httpClient: HttpClient,
                request: request);


            var __authorizations = global::Pika.EndPointSecurityResolver.ResolveAuthorizations(
                availableAuthorizations: Authorizations,
                securityRequirements: s_CreateMeetingSessionSecurityRequirements,
                operationName: "CreateMeetingSessionAsync");

            using var __timeoutCancellationTokenSource = global::Pika.AutoSDKRequestOptionsSupport.CreateTimeoutCancellationTokenSource(
                clientOptions: Options,
                requestOptions: requestOptions,
                cancellationToken: cancellationToken);
            var __effectiveCancellationToken = __timeoutCancellationTokenSource?.Token ?? cancellationToken;
            var __effectiveReadResponseAsString = global::Pika.AutoSDKRequestOptionsSupport.GetReadResponseAsString(
                clientOptions: Options,
                requestOptions: requestOptions,
                fallbackValue: ReadResponseAsString);
            var __maxAttempts = global::Pika.AutoSDKRequestOptionsSupport.GetMaxAttempts(
                clientOptions: Options,
                requestOptions: requestOptions,
                supportsRetry: true);

            global::System.Net.Http.HttpRequestMessage __CreateHttpRequest()
            {
                            var __pathBuilder = new global::Pika.PathBuilder(
                                path: "/meeting-session",
                                baseUri: HttpClient.BaseAddress);
                            var __path = __pathBuilder.ToString();
                __path = global::Pika.AutoSDKRequestOptionsSupport.AppendQueryParameters(
                    path: __path,
                    clientParameters: Options.QueryParameters,
                    requestParameters: requestOptions?.QueryParameters);
                var __httpRequest = new global::System.Net.Http.HttpRequestMessage(
                    method: global::System.Net.Http.HttpMethod.Post,
                    requestUri: new global::System.Uri(__path, global::System.UriKind.RelativeOrAbsolute));
#if NET6_0_OR_GREATER
                __httpRequest.Version = global::System.Net.HttpVersion.Version11;
                __httpRequest.VersionPolicy = global::System.Net.Http.HttpVersionPolicy.RequestVersionOrHigher;
#endif

            foreach (var __authorization in __authorizations)
            {
                if (__authorization.Type == "Http" ||
                    __authorization.Type == "OAuth2" ||
                    __authorization.Type == "OpenIdConnect")
                {
                    __httpRequest.Headers.Authorization = new global::System.Net.Http.Headers.AuthenticationHeaderValue(
                        scheme: __authorization.Name,
                        parameter: __authorization.Value);
                }
                else if (__authorization.Type == "ApiKey" &&
                         __authorization.Location == "Header")
                {
                    __httpRequest.Headers.Add(__authorization.Name, __authorization.Value);
                } 
            }
                            var __httpRequestContent = new global::System.Net.Http.MultipartFormDataContent();
                            var __contentImage = new global::System.Net.Http.ByteArrayContent(request.Image ?? global::System.Array.Empty<byte>());
                            __httpRequestContent.Add(
                                content: __contentImage,
                                name: "\"image\"",
                                fileName: request.Imagename != null ? $"\"{request.Imagename}\"" : string.Empty);
                            if (__contentImage.Headers.ContentDisposition != null)
                            {
                                __contentImage.Headers.ContentDisposition.FileNameStar = null;
                            }
                            __httpRequestContent.Add(
                                content: new global::System.Net.Http.StringContent($"{request.VoiceId}"),
                                name: "\"voice_id\"");
                            __httpRequestContent.Add(
                                content: new global::System.Net.Http.StringContent($"{request.MeetUrl}"),
                                name: "\"meet_url\"");
                            __httpRequestContent.Add(
                                content: new global::System.Net.Http.StringContent($"{request.BotName}"),
                                name: "\"bot_name\"");
                            __httpRequestContent.Add(
                                content: new global::System.Net.Http.StringContent($"{request.Platform.ToValueString()}"),
                                name: "\"platform\"");
                            if (request.MeetingPassword != default)
                            {

                                __httpRequestContent.Add(
                                    content: new global::System.Net.Http.StringContent($"{request.MeetingPassword}"),
                                    name: "\"meeting_password\"");
                            } 
                            if (request.SystemPrompt != default)
                            {

                                __httpRequestContent.Add(
                                    content: new global::System.Net.Http.StringContent($"{request.SystemPrompt}"),
                                    name: "\"system_prompt\"");
                            }
                            __httpRequest.Content = __httpRequestContent;
                global::Pika.AutoSDKRequestOptionsSupport.ApplyHeaders(
                    request: __httpRequest,
                    clientHeaders: Options.Headers,
                    requestHeaders: requestOptions?.Headers);

                PrepareRequest(
                    client: HttpClient,
                    request: __httpRequest);
                PrepareCreateMeetingSessionRequest(
                    httpClient: HttpClient,
                    httpRequestMessage: __httpRequest,
                    request: request);

                return __httpRequest;
            }

            global::System.Net.Http.HttpRequestMessage? __httpRequest = null;
            global::System.Net.Http.HttpResponseMessage? __response = null;
            var __attemptNumber = 0;
            try
            {
                for (var __attempt = 1; __attempt <= __maxAttempts; __attempt++)
                {
                    __attemptNumber = __attempt;
                    __httpRequest = __CreateHttpRequest();
                    await global::Pika.AutoSDKRequestOptionsSupport.OnBeforeRequestAsync(
                            clientOptions: Options,
                            context: global::Pika.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "CreateMeetingSession",
                                methodName: "CreateMeetingSessionAsync",
                                pathTemplate: "\"/meeting-session\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: null,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attempt,
                                maxAttempts: __maxAttempts,
                                willRetry: false,
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                    try
                    {
                        __response = await HttpClient.SendAsync(
                request: __httpRequest,
                completionOption: global::System.Net.Http.HttpCompletionOption.ResponseContentRead,
                cancellationToken: __effectiveCancellationToken).ConfigureAwait(false);
                    }
                    catch (global::System.Net.Http.HttpRequestException __exception)
                    {
                        var __willRetry = __attempt < __maxAttempts && !__effectiveCancellationToken.IsCancellationRequested;
                        await global::Pika.AutoSDKRequestOptionsSupport.OnAfterErrorAsync(
                            clientOptions: Options,
                            context: global::Pika.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "CreateMeetingSession",
                                methodName: "CreateMeetingSessionAsync",
                                pathTemplate: "\"/meeting-session\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: null,
                                exception: __exception,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attempt,
                                maxAttempts: __maxAttempts,
                                willRetry: __willRetry,
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                        if (!__willRetry)
                        {
                            throw;
                        }

                        __httpRequest.Dispose();
                        __httpRequest = null;
                        await global::Pika.AutoSDKRequestOptionsSupport.DelayBeforeRetryAsync(
                            clientOptions: Options,
                            requestOptions: requestOptions,
                            cancellationToken: __effectiveCancellationToken).ConfigureAwait(false);
                        continue;
                    }

                    if (__response != null &&
                        __attempt < __maxAttempts &&
                        global::Pika.AutoSDKRequestOptionsSupport.ShouldRetryStatusCode(__response.StatusCode))
                    {
                        await global::Pika.AutoSDKRequestOptionsSupport.OnAfterErrorAsync(
                            clientOptions: Options,
                            context: global::Pika.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "CreateMeetingSession",
                                methodName: "CreateMeetingSessionAsync",
                                pathTemplate: "\"/meeting-session\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: __response,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attempt,
                                maxAttempts: __maxAttempts,
                                willRetry: true,
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                        __response.Dispose();
                        __response = null;
                        __httpRequest.Dispose();
                        __httpRequest = null;
                        await global::Pika.AutoSDKRequestOptionsSupport.DelayBeforeRetryAsync(
                            clientOptions: Options,
                            requestOptions: requestOptions,
                            cancellationToken: __effectiveCancellationToken).ConfigureAwait(false);
                        continue;
                    }

                    break;
                }

                if (__response == null)
                {
                    throw new global::System.InvalidOperationException("No response received.");
                }

                using (__response)
                {

                ProcessResponse(
                    client: HttpClient,
                    response: __response);
                ProcessCreateMeetingSessionResponse(
                    httpClient: HttpClient,
                    httpResponseMessage: __response);
                if (__response.IsSuccessStatusCode)
                {
                    await global::Pika.AutoSDKRequestOptionsSupport.OnAfterSuccessAsync(
                            clientOptions: Options,
                            context: global::Pika.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "CreateMeetingSession",
                                methodName: "CreateMeetingSessionAsync",
                                pathTemplate: "\"/meeting-session\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: __response,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attemptNumber,
                                maxAttempts: __maxAttempts,
                                willRetry: false,
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                }
                else
                {
                    await global::Pika.AutoSDKRequestOptionsSupport.OnAfterErrorAsync(
                            clientOptions: Options,
                            context: global::Pika.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "CreateMeetingSession",
                                methodName: "CreateMeetingSessionAsync",
                                pathTemplate: "\"/meeting-session\"",
                                httpMethod: "POST",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: __response,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attemptNumber,
                                maxAttempts: __maxAttempts,
                                willRetry: false,
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                }

                            if (__effectiveReadResponseAsString)
                            {
                                var __content = await __response.Content.ReadAsStringAsync(
                #if NET5_0_OR_GREATER
                                    __effectiveCancellationToken
                #endif
                                ).ConfigureAwait(false);

                                ProcessResponseContent(
                                    client: HttpClient,
                                    response: __response,
                                    content: ref __content);
                                ProcessCreateMeetingSessionResponseContent(
                                    httpClient: HttpClient,
                                    httpResponseMessage: __response,
                                    content: ref __content);

                                try
                                {
                                    __response.EnsureSuccessStatusCode();

                                    return
                                        global::Pika.MeetingSessionResponse.FromJson(__content, JsonSerializerContext) ??
                                        throw new global::System.InvalidOperationException($"Response deserialization failed for \"{__content}\" ");
                                }
                                catch (global::System.Exception __ex)
                                {
                                    throw new global::Pika.ApiException(
                                        message: __content ?? __response.ReasonPhrase ?? string.Empty,
                                        innerException: __ex,
                                        statusCode: __response.StatusCode)
                                    {
                                        ResponseBody = __content,
                                        ResponseHeaders = global::System.Linq.Enumerable.ToDictionary(
                                            __response.Headers,
                                            h => h.Key,
                                            h => h.Value),
                                    };
                                }
                            }
                            else
                            {
                                try
                                {
                                    __response.EnsureSuccessStatusCode();
                                    using var __content = await __response.Content.ReadAsStreamAsync(
                #if NET5_0_OR_GREATER
                                        __effectiveCancellationToken
                #endif
                                    ).ConfigureAwait(false);

                                    return
                                        await global::Pika.MeetingSessionResponse.FromJsonStreamAsync(__content, JsonSerializerContext).ConfigureAwait(false) ??
                                        throw new global::System.InvalidOperationException("Response deserialization failed.");
                                }
                                catch (global::System.Exception __ex)
                                {
                                    string? __content = null;
                                    try
                                    {
                                        __content = await __response.Content.ReadAsStringAsync(
                #if NET5_0_OR_GREATER
                                            __effectiveCancellationToken
                #endif
                                        ).ConfigureAwait(false);
                                    }
                                    catch (global::System.Exception)
                                    {
                                    }

                                    throw new global::Pika.ApiException(
                                        message: __content ?? __response.ReasonPhrase ?? string.Empty,
                                        innerException: __ex,
                                        statusCode: __response.StatusCode)
                                    {
                                        ResponseBody = __content,
                                        ResponseHeaders = global::System.Linq.Enumerable.ToDictionary(
                                            __response.Headers,
                                            h => h.Key,
                                            h => h.Value),
                                    };
                                }
                            }

                }
            }
            finally
            {
                __httpRequest?.Dispose();
            }
        }
        /// <summary>
        /// Create a meeting session with avatar<br/>
        /// Joins a Google Meet or Zoom call with an AI-powered avatar.<br/>
        /// Requires a reference image for the avatar appearance, a voice ID for speech synthesis,<br/>
        /// and the meeting URL to join.
        /// </summary>
        /// <param name="image">
        /// Avatar reference image (binary upload)
        /// </param>
        /// <param name="imagename">
        /// Avatar reference image (binary upload)
        /// </param>
        /// <param name="voiceId">
        /// Voice ID for avatar speech synthesis
        /// </param>
        /// <param name="meetUrl">
        /// Meeting URL to join
        /// </param>
        /// <param name="botName">
        /// Display name for the avatar bot in the meeting
        /// </param>
        /// <param name="platform">
        /// The video meeting platform
        /// </param>
        /// <param name="meetingPassword">
        /// Optional meeting password
        /// </param>
        /// <param name="systemPrompt">
        /// Optional system prompt to guide avatar behavior
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Threading.Tasks.Task<global::Pika.MeetingSessionResponse> CreateMeetingSessionAsync(
            byte[] image,
            string imagename,
            string voiceId,
            string meetUrl,
            string botName,
            global::Pika.MeetingPlatform platform,
            string? meetingPassword = default,
            string? systemPrompt = default,
            global::Pika.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var __request = new global::Pika.CreateMeetingSessionRequest
            {
                Image = image,
                Imagename = imagename,
                VoiceId = voiceId,
                MeetUrl = meetUrl,
                BotName = botName,
                Platform = platform,
                MeetingPassword = meetingPassword,
                SystemPrompt = systemPrompt,
            };

            return await CreateMeetingSessionAsync(
                request: __request,
                requestOptions: requestOptions,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}