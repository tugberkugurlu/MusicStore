using System.Collections.Generic;

namespace System.Net
{
    public static class Extensions
    {
        public static Cookie GetCookieWithName(this CookieCollection cookieCollection, string cookieName)
        {
            foreach (Cookie cookie in cookieCollection)
            {
                if (cookie.Name == cookieName)
                {
                    return cookie;
                }
            }

            return null;
        }

        /// <summary>
        /// https://github.com/aspnet/HttpAbstractions/issues/121 - Helpers implemented here until that.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> ParseQueryString(this Uri uri)
        {
            var queryParameters = Uri.UnescapeDataString(uri.Query.TrimStart('?')).Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
            var queryItemCollection = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            if (queryParameters != null && queryParameters.Length > 0)
            {
                foreach (var queryParameter in queryParameters)
                {
                    var queryParameterParts = queryParameter.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    var value = queryParameterParts.Length == 1 ? string.Empty : queryParameterParts[1];
                    queryItemCollection.Add(queryParameterParts[0], value);
                }
            }

            return queryItemCollection;
        }
    }
}
