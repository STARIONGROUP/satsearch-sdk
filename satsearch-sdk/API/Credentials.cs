// -------------------------------------------------------------------------------------------------
// <copyright file="Credentials.cs" company="RHEA System S.A.">
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

    /// <summary>
    /// The purpose of the <see cref="Credentials"/> class is to encapsulate connection credentials
    /// to access the <see cref="ISatSearchService"/>
    /// </summary>
    public class Credentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Credentials"/> class.
        /// </summary>
        /// <param name="apiToken">
        /// The API Token used to connect to the <see cref="ISatSearchService"/>
        /// </param>
        /// <param name="aplicationToken">
        /// the application token that is used to connect to the <see cref="ISatSearchService"/>
        /// </param>
        /// <param name="uri">
        /// The <see cref="Uri"/> of the <see cref="ISatSearchService"/>
        /// </param>
        public Credentials(string apiToken, string aplicationToken, Uri uri)
        {
            this.ApiToken = apiToken;
            this.ApplicationToken = aplicationToken;
            this.Uri = uri;
        }

        public string ApplicationToken { get; private set; }

        /// <summary>
        /// Gets the user name
        /// </summary>
        public string ApiToken { get; private set; }

        /// <summary>
        /// Gets the <see cref="URI"/> of the <see cref="ISatSearchService"/>
        /// </summary>
        public Uri Uri { get; private set; }
    }
}