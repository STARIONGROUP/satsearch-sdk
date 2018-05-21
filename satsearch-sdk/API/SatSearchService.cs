// -------------------------------------------------------------------------------------------------
// <copyright file="SatSearchService.cs" company="RHEA System S.A.">
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
    using System.Diagnostics;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using satsearch.sdk.Model;
    using NLog;
    using System.Collections.Concurrent;

    /// <summary>
    /// The <see cref="SatSearchService"/> provides access to the SatSearch data service
    /// </summary>
    [Export(typeof(ISatSearchService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class SatSearchService : ISatSearchService
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The version of the satsearch API
        /// </summary>
        private const string apiversion = "v1";

        /// <summary>
        /// The <see cref="IHttpClientService"/> used to query an <see cref="HttpClient"/>
        /// </summary>
        private IHttpClientService httpClientService;

        /// <summary>
        /// The <see cref="ISatSearchSerializer"/> used to deserialize SatSearch JSON
        /// </summary>
        private ISatSearchSerializer satSearchSerializer;

        /// <summary>
        /// Caches the results of the satsearch online service in memory for fast access
        /// </summary>
        private ConcurrentDictionary<Guid, Model.Thing> thingCache;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SatSearchService"/> class
        /// </summary>
        /// <param name="httpClientService">
        /// The (MEF) injected <see cref="IHttpClientService"/> used to retrieve an <see cref="HttpClient"/>
        /// </param>
        /// <param name="satSearchSerializer">
        /// The (MEF) injected <see cref="ISatSearchSerializer"/> used to deserialize SatSearch JSON
        /// </param>
        [ImportingConstructor]
        public SatSearchService(IHttpClientService httpClientService, ISatSearchSerializer satSearchSerializer)
        {
            this.thingCache = new ConcurrentDictionary<Guid, Model.Thing>();

            this.httpClientService = httpClientService;
            this.satSearchSerializer = satSearchSerializer;
        }

        /// <summary>
        /// Gets the <see cref="Model.SupplierResult"/> from the satsearch service.
        /// </summary>
        /// <param name="credentials">
        /// The <see cref="Credentials"/> used to access the satsearch service
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> with which the request can be cancelled.
        /// </param>
        /// <param name="page">
        /// Results page number (defaults to 1).
        /// </param>
        /// <returns>
        /// A <see cref="Model.SupplierResult"/>
        /// </returns>
        public async Task<SupplierResult> SupplierResult(Credentials credentials, CancellationToken cancellationToken, int page = 1)
        {
            if (credentials == null)
            {
                throw new InvalidOperationException("The credentials may not be null. Use Connect prior to performing a Search");
            }

            var httpClient = this.httpClientService.QueryHttpClient(credentials);

            try
            {
                var stopwatch = Stopwatch.StartNew();
                Logger.Debug("Start SupplierResult query");

                using (var httpResponseMessage = await httpClient.GetAsync($"{apiversion}/suppliers?page={page}", HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                    
                    using (var resultStream = await httpResponseMessage.Content.ReadAsStreamAsync())
                    {
                        var supplierResult = this.satSearchSerializer.DeserializeSupplierResult(resultStream);

                        Logger.Debug("SupplierResult details query executed in {0} [ms]", stopwatch.ElapsedMilliseconds);

                        return supplierResult;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Could not retrieve SupplierResult from the SatSearch service at {0}", httpClient.BaseAddress.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// Retrieves the full <see cref="Model.Supplier"/> details from the satsearch service
        /// </summary>
        /// <param name="credentials">
        /// The <see cref="Credentials"/> used to access the satsearch service
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> with which the request can be cancelled.
        /// </param>
        /// <param name="id">
        /// The unique identifier of the <see cref="Supplier"/> that is to be retrieved from the satsearch service.
        /// </param>
        /// <returns>
        /// A <see cref="Model.Supplier"/> instance
        /// </returns>
        public async Task<Supplier> Supplier(Credentials credentials, CancellationToken cancellationToken, Guid id)
        {
            if (credentials == null)
            {
                throw new InvalidOperationException("The credentials may not be null. Use Connect prior to performing a Search");
            }

            Thing thing;
            if (this.thingCache.TryGetValue(id, out thing))
            {
                return (Supplier)thing;
            }

            var httpClient = this.httpClientService.QueryHttpClient(credentials);

            try
            {
                var stopwatch = Stopwatch.StartNew();
                Logger.Debug("Start Supplier details query");

                using (var httpResponseMessage = await httpClient.GetAsync($"{apiversion}/suppliers/{id}", HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                    
                    using (var resultStream = await httpResponseMessage.Content.ReadAsStreamAsync())
                    {
                        var supplier = this.satSearchSerializer.DeserializeSupplier(resultStream);
                        this.thingCache.GetOrAdd(supplier.Uuid, supplier);

                        Logger.Debug("Supplier details query executed in {0} [ms]", stopwatch.ElapsedMilliseconds);

                        return supplier;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Could not retrieve Supplier from the SatSearch service at {0}", httpClient.BaseAddress.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// Gets all the <see cref="Supplier"/>s from the SatSearch service.
        /// </summary>
        /// <param name="credentials">
        /// The <see cref="Credentials"/> used to access the satsearch service
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> with which the request can be cancelled.
        /// </param>
        /// <returns></returns>

        public async Task<IEnumerable<Supplier>> Suppliers(Credentials credentials, CancellationToken cancellationToken)
        {
            var result = await this.SupplierResult(credentials, cancellationToken);            
            var lastPage = result.LastPage;
            
            var suppliers = new List<Supplier>();
            suppliers.AddRange(result.Data);
            
            for (int i = 2; i < lastPage + 1 ; i++)
            {
                result = await this.SupplierResult(credentials, cancellationToken, i);
                suppliers.AddRange(result.Data);
            }
            
            return suppliers;
        }

        /// <summary>
        /// Gets the categories from the SatSearch service.
        /// </summary>
        /// <param name="credentials">
        /// The <see cref="Credentials"/> used to access the satsearch service
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> with which the request can be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{Category}"/>, this may be empty.
        /// </returns>
        public async Task<IEnumerable<Category>> Categories(Credentials credentials, CancellationToken cancellationToken)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException(nameof(credentials), "The credentials may not be null.");
            }

            var httpClient = this.httpClientService.QueryHttpClient(credentials);

            try
            {
                var stopwatch = Stopwatch.StartNew();
                Logger.Debug("Start Category query");

                using (var httpResponseMessage = await httpClient.GetAsync($"{apiversion}/products/categories", HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                    
                    using (var resultStream = await httpResponseMessage.Content.ReadAsStreamAsync())
                    {
                        var categories = this.satSearchSerializer.DeserializeCategories(resultStream);
                        var sortedCategories = categories.OrderBy(cat => cat.Name);

                        Logger.Debug("Category details query executed in {0} [ms]", stopwatch.ElapsedMilliseconds);

                        return sortedCategories;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Could not retrieve Categories from the SatSearch service at {0}", httpClient.BaseAddress.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// Gets the attribute types from the SatSearch service;
        /// </summary>
        /// <param name="credentials">
        /// The <see cref="Credentials"/> used to access the satsearch service
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> with which the request can be cancelled.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{Attribute}"/>, this may be empty.
        /// </returns>
        public async Task<IEnumerable<satsearch.sdk.Model.AttributeType>> AttributeTypes(Credentials credentials, CancellationToken cancellationToken)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException(nameof(credentials), "The credentials may not be null.");
            }

            var httpClient = this.httpClientService.QueryHttpClient(credentials);

            try
            {
                var stopwatch = Stopwatch.StartNew();
                Logger.Debug("Start AttributeType query");

                using (var httpResponseMessage = await httpClient.GetAsync($"{apiversion}/products/attributes", HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                    
                    using (var resultStream = await httpResponseMessage.Content.ReadAsStreamAsync())
                    {
                        var attributes = this.satSearchSerializer.DeserializeAttributes(resultStream);

                        Logger.Debug("AttributeTypes query executed in {0} [ms]", stopwatch.ElapsedMilliseconds);

                        return attributes;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Could not retrieve AttributeTypes from the SatSearch service at {0}", httpClient.BaseAddress.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// Perform a search query on a SatSearch service
        /// </summary>
        /// <param name="credentials">
        /// The <see cref="Credentials"/> used to access the satsearch service
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> with which the request can be cancelled.
        /// </param>
        /// <param name="searchParameter">
        /// The search query that is to be performed on the SatSearch service.
        /// </param>
        /// <returns></returns>
        public async Task<ProductResult> Search(Credentials credentials, CancellationToken cancellationToken, SearchParameter searchParameter)
        {
            if (credentials == null)
            {
                throw new InvalidOperationException("The credentials may not be null. Use Connect prior to performing a Search");
            }

            var httpClient = this.httpClientService.QueryHttpClient(credentials);

            try
            {
                var stopwatch = Stopwatch.StartNew();
                
                var queryParameters = searchParameter == null ? string.Empty : searchParameter.ToString();
                var requestUri = queryParameters == string.Empty ? $"{apiversion}/products" : $"{apiversion}/products?{queryParameters}";

                Logger.Debug("Start ProductResult query: {0}", requestUri);

                using (var httpResponseMessage = await httpClient.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                    
                    using (var resultStream = await httpResponseMessage.Content.ReadAsStreamAsync())
                    {
                        var productResult = this.satSearchSerializer.DeserializeProductResult(resultStream);

                        Logger.Debug("ProductResult details query executed in {0} [ms]", stopwatch.ElapsedMilliseconds);

                        return productResult;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Could not retrieve ProductResult from the SatSearch service at {0}", httpClient.BaseAddress.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// Retrieves the full product details from the satsearch service
        /// </summary>
        /// <param name="credentials">
        /// The <see cref="Credentials"/> used to access the satsearch service
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> with which the request can be cancelled.
        /// </param>
        /// <param name="id">
        /// The unique identifier of the <see cref="Product"/> that is to be retrieved from the satsearch service.
        /// </param>
        /// <returns>
        /// A <see cref="Product"/> instance
        /// </returns>
        public async Task<Product> Product(Credentials credentials, CancellationToken cancellationToken, Guid id)
        {
            if (credentials == null)
            {
                throw new InvalidOperationException("The credentials may not be null. Use Connect prior to performing a Search");
            }

            Thing thing;
            if (this.thingCache.TryGetValue(id, out thing))
            {
                return (Product)thing;
            }

            var httpClient = this.httpClientService.QueryHttpClient(credentials);

            try
            {
                var stopwatch = Stopwatch.StartNew();
                Logger.Debug("Start Product details query");

                using (var httpResponseMessage = await httpClient.GetAsync($"{apiversion}/products/{id}", HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                    
                    using (var resultStream = await httpResponseMessage.Content.ReadAsStreamAsync())
                    {
                        var product = this.satSearchSerializer.DeserializeProduct(resultStream);
                        this.thingCache.GetOrAdd(product.Uuid, product);

                        Logger.Debug("Product details query executed in {0} [ms]", stopwatch.ElapsedMilliseconds);

                        return product;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Could not retrieve Product from the SatSearch service at {0}", httpClient.BaseAddress.ToString());
                throw ex;
            }           
        }
    }
}