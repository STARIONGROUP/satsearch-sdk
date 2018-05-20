// -------------------------------------------------------------------------------------------------
// <copyright file="HttpClientService.cs" company="RHEA System S.A.">
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
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Net.Http;
    using System.Net.Http.Headers;

    /// <summary>
    /// The purpose of the <see cref="HttpClientService"/> is to provide an <see cref="HttpClient"/>
    /// that can be used to retrieve data from the SatSearch service.
    /// </summary>
    [Export(typeof(IHttpClientService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class HttpClientService : IHttpClientService
    {
        /// <summary>
        /// The cache of http clients
        /// </summary>
        private readonly Dictionary<Credentials, HttpClient> httpClientCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientService"/> class.
        /// </summary>
        public HttpClientService()
        {
            this.httpClientCache = new Dictionary<Credentials, HttpClient>();
        }

        /// <summary>
        /// Queries the service for an HttpClient that can be used to
        /// connect to the SatSearch service
        /// </summary>
        /// <param name="credentials">
        /// An instance of <see cref="Credentials"/> that carries the Uri and ApiToken
        /// </param>
        /// <returns>
        /// an instance of <see cref="HttpClient"/>
        /// </returns>
        public HttpClient QueryHttpClient(Credentials credentials)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException(nameof(credentials), "The Credentials may not be null");
            }

            if (string.IsNullOrEmpty(credentials.ApiToken))
            {
                throw new InvalidOperationException("The Credentials ApiToken may not be null or empty");
            }

            if (string.IsNullOrEmpty(credentials.ApplicationToken))
            {
                throw new InvalidOperationException("The Credentials ApplicationToken may not be null or empty");
            }

            HttpClient httpClient;
            if (this.httpClientCache.TryGetValue(credentials, out httpClient))
            {
                return httpClient;
            }

            httpClient = new HttpClient();
            httpClient.BaseAddress = credentials.Uri;
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", credentials.ApiToken);
            httpClient.DefaultRequestHeaders.Add("X-APP-ID", credentials.ApplicationToken);

            this.httpClientCache.Add(credentials, httpClient);
            return httpClient;
        }
    }
}