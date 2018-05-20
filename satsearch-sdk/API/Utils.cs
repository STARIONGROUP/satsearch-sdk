// -------------------------------------------------------------------------------------------------
// <copyright file="Utils.cs" company="RHEA System S.A.">
//   Copyright (c) 2018 RHEA System S.A.
//
//   This file is part of satsearch-sdk
//
//   satsearch-sdk is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//   
//   satsearch-sdk is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//   GNU General Public License for more details.
//
//   You should have received a copy of the GNU General Public License
//   along with Foobar.  If not, see<http://www.gnu.org/licenses/>.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace satsearch.sdk.API
{
    using System;

    public static class Utils
    {
        /// <summary>
        /// Assertion that the provided string is a valid <see cref="Uri"/> to connect to
        /// a data-source with the current implementation of the <see cref="IDal"/>.
        /// </summary>
        /// <param name="uri">
        /// a string representing a <see cref="Uri"/>.
        /// </param>
        /// <returns>
        /// true when valid, false when invalid.
        /// </returns>
        /// <remarks>
        /// Only HTTP and HTTPS are valid.
        /// </remarks>
        public static bool IsValidUri(string uri)
        {
            try
            {
                var validUriAssertion = new Uri(uri);
                AssertUriIsHttpOrHttpsSchema(validUriAssertion);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Asserts that the uri is following the http or https schema.
        /// </summary>
        /// <param name="uri">
        /// The uri.
        /// </param>
        /// <exception cref="ArgumentException">
        /// If the <see cref="Uri"/> is not either a HTTP or a HTTPS schema, this exception is thrown.
        /// </exception>
        public static void AssertUriIsHttpOrHttpsSchema(Uri uri)
        {
            if (!(uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
            {
                throw new ArgumentException($"Invalid URI scheme for: {uri}");
            }
        }
    }
}