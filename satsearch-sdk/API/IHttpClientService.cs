// -------------------------------------------------------------------------------------------------
// <copyright file="IHttpClientService.cs" company="RHEA System S.A.">
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
    using System.Net.Http;

    /// <summary>
    /// The purpose of the <see cref="IHttpClientService"/> is to provide an <see cref="HttpClient"/>
    /// that can be used to retrieve data from the SatSearch service.
    /// </summary>
    public interface IHttpClientService
    {
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
        HttpClient QueryHttpClient(Credentials credentials);
    }
}