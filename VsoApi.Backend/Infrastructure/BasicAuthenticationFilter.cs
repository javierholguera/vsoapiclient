namespace VsoApi.Backend.Infrastructure
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Filters;

    /// <summary>
    /// Authentication filter that uses Basic Authentication to authenticate users.
    /// </summary>
    /// <remarks>
    /// This class can be applied as [Attribute] if it inherits from Attribute class.
    /// However for the moment we will apply it on a global basis, to all the calls made to this Web API.
    /// </remarks>
    public class BasicAuthenticationFilter : IAuthenticationFilter
    {
        private const string ExpectedUsername = "javierh";
        private const string ExpectedPassword = "1Vso#client1";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public BasicAuthenticationFilter()
        {
            AllowMultiple = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether more than one instance of the indicated attribute can be specified for a single program element.
        /// </summary>
        /// <returns>
        /// true if more than one instance is allowed to be specified; otherwise, false. The default is false.
        /// </returns>
        public bool AllowMultiple { get; private set; }

        /// <summary>
        /// Authenticates the request.
        /// </summary>
        /// <returns>
        /// A Task that will perform authentication.
        /// </returns>
        /// <param name="context">The authentication context.</param><param name="cancellationToken">The token to monitor for cancellation requests.</param>
        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                // 1. Look for credentials in the request.
                HttpRequestMessage request = context.Request;
                AuthenticationHeaderValue authorization = request.Headers.Authorization;
                if (authorization == null) {
                    context.ErrorResult = new AuthenticationFailureResult("Missing credentials", request);
                    return;
                }

                // 3. If there are credentials but the filter does not recognize the authentication scheme, err.
                if (authorization.Scheme != "Basic") {
                    context.ErrorResult = new AuthenticationFailureResult("Erroneous authentication scheme", request);
                    return;
                }

                // 4. If there are credentials that the filter understands, try to validate them.
                // 5. If the credentials are bad, set the error result.
                if (string.IsNullOrEmpty(authorization.Parameter)) {
                    context.ErrorResult = new AuthenticationFailureResult("Missing credentials", request);
                    return;
                }

                Tuple<string, string> userNameAndPasword = ExtractUserNameAndPassword(authorization.Parameter);
                if (userNameAndPasword == null) {
                    context.ErrorResult = new AuthenticationFailureResult("Invalid credentials", request);
                    return;
                }

                string userName = userNameAndPasword.Item1;
                string password = userNameAndPasword.Item2;

                if (string.Equals(userName, ExpectedUsername, StringComparison.OrdinalIgnoreCase) == false ||
                    string.Equals(password, ExpectedPassword, StringComparison.OrdinalIgnoreCase) == false) {
                    context.ErrorResult = new AuthenticationFailureResult("Invalid username or password", request);
                }

            }, cancellationToken);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.Run(() => { }, cancellationToken);
        }

        private static Tuple<string, string> ExtractUserNameAndPassword(string authorizationParameter)
        {
            byte[] credentialBytes;

            try {
                credentialBytes = Convert.FromBase64String(authorizationParameter);
            } catch (FormatException) {
                return null;
            }

            // The currently approved HTTP 1.1 specification says characters here are ISO-8859-1.
            // However, the current draft updated specification for HTTP 1.1 indicates this encoding is infrequently
            // used in practice and defines behavior only for ASCII.
            Encoding encoding = Encoding.ASCII;

            // Make a writable copy of the encoding to enable setting a decoder fallback.
            encoding = (Encoding)encoding.Clone();
            
            // Fail on invalid bytes rather than silently replacing and continuing.
            encoding.DecoderFallback = DecoderFallback.ExceptionFallback;
            string decodedCredentials;

            try {
                decodedCredentials = encoding.GetString(credentialBytes);
            } catch (DecoderFallbackException) {
                return null;
            }

            if (String.IsNullOrEmpty(decodedCredentials)) {
                return null;
            }

            int colonIndex = decodedCredentials.IndexOf(':');

            if (colonIndex == -1) {
                return null;
            }

            string userName = decodedCredentials.Substring(0, colonIndex);
            string password = decodedCredentials.Substring(colonIndex + 1);
            return new Tuple<string, string>(userName, password);
        }
    }

    public class AuthenticationFailureResult : IHttpActionResult
    {
        public AuthenticationFailureResult(string reasonPhrase, HttpRequestMessage request)
        {
            ReasonPhrase = reasonPhrase;
            Request = request;
        }

        public string ReasonPhrase { get; private set; }

        public HttpRequestMessage Request { get; private set; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        private HttpResponseMessage Execute()
        {
            return new HttpResponseMessage(HttpStatusCode.Unauthorized) {
                RequestMessage = Request,
                ReasonPhrase = ReasonPhrase
            };
        }
    }
}