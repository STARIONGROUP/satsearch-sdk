// -------------------------------------------------------------------------------------------------
// <copyright file="HttpClientServiceTestFixture.cs" company="RHEA System S.A.">
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

namespace satsearch.sdk.tests.API
{
    using System;
    using satsearch.sdk.API;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="HttpClientService"/> class.
    /// </summary>
    [TestFixture]
    public class HttpClientServiceTestFixture
    {
        private HttpClientService httpClientService;

        private Uri uri;

        [SetUp]
        public void SetUp()
        {
            this.uri = new Uri("https://api.satsearch.co");

            this.httpClientService = new HttpClientService();
        }
        
        [Test]
        public void Verify_that_QueryHttpClient_returns_a_httpclient()
        {
            var credentials = new Credentials("apitoken", "application-token", this.uri);

            var clientRequestOne = this.httpClientService.QueryHttpClient(credentials);

            Assert.IsNotNull(clientRequestOne);

            var clientRequesTwo = this.httpClientService.QueryHttpClient(credentials);

            Assert.IsNotNull(clientRequesTwo);

            Assert.AreSame(clientRequestOne, clientRequesTwo);
        }

        [Test]
        public void Veroify_that_when_credentials_are_null_ArgumentNullException_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.httpClientService.QueryHttpClient(null));
        }

        [Test]
        public void Veroify_that_when_credentials_apitoken_empty_ArgumentNullException_is_thrown()
        {
            var credentials = new Credentials("", "application-token", this.uri);

            Assert.Throws<InvalidOperationException>(() => this.httpClientService.QueryHttpClient(credentials));
        }

        [Test]
        public void Veroify_that_when_credentials_applicationtoken_empty_ArgumentNullException_is_thrown()
        {
            var credentials = new Credentials("apitoken", "", this.uri);

            Assert.Throws<InvalidOperationException>(() => this.httpClientService.QueryHttpClient(credentials));
        }
    }
}