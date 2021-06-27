using Microsoft.Owin.Security;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Example.Api.Auth
{
    /// <summary>
    /// The authentication challenge result.
    /// </summary>
    public class ChallengeResult : IHttpActionResult
    {
        /// <summary>
        /// The <c>XsrfId</c> constant.
        /// </summary>
        private const string XsrfKey = "XsrfId";

        /// <summary>
        /// Creates an instance of <see cref="ChallengeResult"/>.
        /// </summary>
        /// <param name="provider">The auth provider.</param>
        /// <param name="redirectUri">The auth redirect URI.</param>
        /// <param name="request">The <see cref="HttpRequestMessage"/> instance.</param>
        public ChallengeResult(
            string provider,
            string redirectUri,
            HttpRequestMessage request)
            : this(provider, redirectUri, null, request)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="ChallengeResult"/>.
        /// </summary>
        /// <param name="provider">The auth provider.</param>
        /// <param name="redirectUri">The auth redirect URI.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="request">The <see cref="HttpRequestMessage"/> instance.</param>
        public ChallengeResult(
            string provider, 
            string redirectUri, 
            string userId, 
            HttpRequestMessage request)
        {
            AuthenticationProvider = provider;
            RedirectUri = redirectUri;
            UserId = userId;
            MessageRequest = request;
        }

        /// <summary>
        /// Gets and sets the auth provider. 
        /// </summary>
        public string AuthenticationProvider { get; private set; }

        /// <summary>
        ///  Gets and sets the redirect URI.
        /// </summary>
        public string RedirectUri { get; private set; }

        /// <summary>
        ///  Gets and sets the user identifier.
        /// </summary>
        public string UserId { get; private set; }

        /// <summary>
        ///  Gets and sets the <see cref="HttpRequestMessage"/> instance.
        /// </summary>
        public HttpRequestMessage MessageRequest { get; private set; }

        /// <summary>
        /// Executes the auth challenge logic.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The challenge response.</returns>
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = this.RedirectUri
            };

            if (UserId != null)
            {
                properties.Dictionary[XsrfKey] = UserId;
            }

            MessageRequest.GetOwinContext().Authentication.Challenge(properties, AuthenticationProvider);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                RequestMessage = MessageRequest
            };

            return Task.FromResult(response);
        }
    }
}