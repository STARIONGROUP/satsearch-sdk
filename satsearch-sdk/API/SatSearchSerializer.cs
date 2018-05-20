// -------------------------------------------------------------------------------------------------
// <copyright file="SatSearchSerializer.cs" company="RHEA System S.A.">
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
    using System.Diagnostics;
    using System.Text;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.IO;
    using satsearch.sdk.Model;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using NLog;

    /// <summary>
    /// The purpose of the <see cref="SatSearchSerializer"/> is to deserialize JSON responses
    /// r[ovided by the SatSearch service.
    /// </summary>
    [Export(typeof(ISatSearchSerializer))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class SatSearchSerializer : ISatSearchSerializer
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Deserialize the SatSearch json to a list of <see cref="Category"/>
        /// </summary>
        /// <param name="json"></param>
        /// <returns>
        /// returns an <see cref="IEnumerable{Category}"/>, this may be empty.
        /// </returns>
        public IEnumerable<Category> DeserializeCategories(string json)
        {
            Logger.Trace("converting JSON to stream");

            var byteArray = Encoding.UTF8.GetBytes(json);

            using (var stream = new MemoryStream(byteArray))
            {
                return this.DeserializeCategories(stream);
            }
        }

        /// <summary>
        /// Deserialize the SatSearch json <see cref="Stream"/> to a list of <see cref="Category"/>
        /// </summary>
        /// <param name="contentStream">
        /// a <see cref="Category"/> json <see cref="Stream"/>
        /// </param>
        /// <returns>
        /// returns an <see cref="IEnumerable{Category}"/>, this may be empty.
        /// </returns>
        public IEnumerable<Category> DeserializeCategories(Stream contentStream)
        {
            var serializer = this.CreateJsonSerializer();

            var sw = new Stopwatch();
            sw.Start();
            
            IEnumerable<Category> categories;

            using (var streamReader = new StreamReader(contentStream))
            using (var jsonTextReader = new JsonTextReader(streamReader))
            {
                categories = serializer.Deserialize<IEnumerable<Category>>(jsonTextReader);
            }

            Logger.Trace("Category deserialization completed in {0} [ms]", sw.ElapsedMilliseconds);

            return categories;
        }

        /// <summary>
        /// Deserialize the SatSearch json to a list of <see cref="Attribute"/>
        /// </summary>
        /// <param name="json">
        /// a <see cref="Attribute"/> json string
        /// </param>
        /// <returns>
        /// returns an <see cref="IEnumerable{Attribute}"/>, this may be empty.
        /// </returns>
        public IEnumerable<Model.AttributeType> DeserializeAttributes(string json)
        {
            Logger.Trace("converting JSON to stream");

            var byteArray = Encoding.UTF8.GetBytes(json);

            using (var stream = new MemoryStream(byteArray))
            {
                return this.DeserializeAttributes(stream);
            }
        }

        /// <summary>
        /// Deserialize the SatSearch json <see cref="Stream"/> to a list of <see cref="Model.Attribute"/>
        /// </summary>
        /// <param name="contentStream">
        /// a <see cref="Model.Attribute"/> json <see cref="Stream"/>
        /// </param>
        /// <returns>
        /// returns an <see cref="IEnumerable{Category}"/>, this may be empty.
        /// </returns>
        public IEnumerable<Model.AttributeType> DeserializeAttributes(Stream contentStream)
        {
            var serializer = this.CreateJsonSerializer();

            var sw = new Stopwatch();
            sw.Start();

            IEnumerable<Model.AttributeType> attributes;

            using (var streamReader = new StreamReader(contentStream))
            using (var jsonTextReader = new JsonTextReader(streamReader))
            {
                attributes = serializer.Deserialize<IEnumerable<Model.AttributeType>>(jsonTextReader);
            }

            Logger.Trace("AttributeType deserialization completed in {0} [ms]", sw.ElapsedMilliseconds);

            return attributes;
        }

        /// <summary>
        /// Deserialize the satsearch json to a <see cref="SupplierResult"/> object
        /// </summary>
        /// <param name="json"></param>
        /// <returns>
        /// returns an <see cref="SupplierResult"/>.
        /// </returns>
        public SupplierResult DeserializeSupplierResult(string json)
        {
            Logger.Trace("converting JSON to stream");

            var byteArray = Encoding.UTF8.GetBytes(json);

            using (var stream = new MemoryStream(byteArray))
            {
                return this.DeserializeSupplierResult(stream);
            }
        }

        /// <summary>
        /// Deserialize the satsearch json to a <see cref="SupplierResult"/> object
        /// </summary>
        /// <param name="contentStream">
        /// The json stream representation of a single <see cref="SupplierResult"/>
        /// </param>
        /// <returns>
        /// returns an <see cref="SupplierResult"/>.
        /// </returns>
        public SupplierResult DeserializeSupplierResult(Stream contentStream)
        {
            var serializer = this.CreateJsonSerializer();

            var sw = new Stopwatch();
            sw.Start();

            SupplierResult supplierResult;

            using (var streamReader = new StreamReader(contentStream))
            using (var jsonTextReader = new JsonTextReader(streamReader))
            {
                supplierResult = serializer.Deserialize<SupplierResult>(jsonTextReader);
            }

            Logger.Trace("SupplierResult deserialization completed in {0} [ms]", sw.ElapsedMilliseconds);

            return supplierResult;
        }

        /// <summary>
        /// Deserialize the satsearch.co json to a <see cref="Supplier"/>
        /// </summary>
        /// <param name="json">
        /// The json representation of a single <see cref="Supplier"/>
        /// </param>
        /// <returns>
        /// returns an <see cref="Supplier"/>, this may be empty.
        /// </returns>
        public Supplier DeserializeSupplier(string json)
        {
            Logger.Trace("converting JSON to stream");

            var byteArray = Encoding.UTF8.GetBytes(json);

            using (var stream = new MemoryStream(byteArray))
            {
                return this.DeserializeSupplier(stream);
            }
        }

        /// <summary>
        /// Deserialize the satsearch.co json to a <see cref="Supplier"/>
        /// </summary>
        /// <param name="contentStream">
        /// The json stream representation of a single <see cref="Supplier"/>
        /// </param>
        /// <returns>
        /// returns an <see cref="Supplier"/>.
        /// </returns>
        public Supplier DeserializeSupplier(Stream contentStream)
        {
            var serializer = this.CreateJsonSerializer();

            var sw = new Stopwatch();
            sw.Start();

            Model.Supplier supplier;

            using (var streamReader = new StreamReader(contentStream))
            using (var jsonTextReader = new JsonTextReader(streamReader))
            {
                supplier = serializer.Deserialize<Supplier>(jsonTextReader);
            }

            Logger.Trace("Supplier deserialization completed in {0} [ms]", sw.ElapsedMilliseconds);

            return supplier;
        }

        /// <summary>
        /// Deserialize the SatSearch json to a list of <see cref="Product"/>
        /// </summary>
        /// <param name="json"></param>
        /// <returns>
        /// returns an <see cref="IEnumerable{Product}"/>, this may be empty.
        /// </returns>
        public ProductResult DeserializeProductResult(string json)
        {
            Logger.Trace("converting JSON to stream");

            var byteArray = Encoding.UTF8.GetBytes(json);

            using (var stream = new MemoryStream(byteArray))
            {
                return this.DeserializeProductResult(stream);
            }
        }

        /// <summary>
        /// Deserialize the SatSearch json to a list of <see cref="Product"/>
        /// </summary>
        /// <param name="contentStream"></param>
        /// <returns>
        /// returns an <see cref="IEnumerable{Product}"/>, this may be empty.
        /// </returns>
        public ProductResult DeserializeProductResult(Stream contentStream)
        {
            var serializer = this.CreateJsonSerializer();

            var sw = new Stopwatch();
            sw.Start();

            ProductResult productResult;

            using (var streamReader = new StreamReader(contentStream))
            using (var jsonTextReader = new JsonTextReader(streamReader))
            {
                productResult = serializer.Deserialize<ProductResult>(jsonTextReader);
            }

            Logger.Trace("ProductResult deserialization completed in {0} [ms]", sw.ElapsedMilliseconds);

            return productResult;
        }
        
        /// <summary>
        /// Deserialize the SatSearch json to a <see cref="Product"/> object
        /// </summary>
        /// <param name="json">
        /// The json representation of a single <see cref="Product"/>
        /// </param>
        /// <returns>
        /// returns a <see cref="Product"/>
        /// </returns>
        public Product DeserializeProduct(string json)
        {
            Logger.Trace("converting JSON to stream");

            var byteArray = Encoding.UTF8.GetBytes(json);

            using (var stream = new MemoryStream(byteArray))
            {
                return this.DeserializeProduct(stream);
            }
        }

        /// <summary>
        /// Deserialize the SatSearch json to a <see cref="Product"/> object
        /// </summary>
        /// <param name="contentStream">
        /// The json stream representation of a single <see cref="Product"/>
        /// </param>
        /// <returns>
        /// returns a <see cref="Product"/>
        /// </returns>
        public Product DeserializeProduct(Stream contentStream)
        {
            var serializer = this.CreateJsonSerializer();

            var sw = new Stopwatch();
            sw.Start();

            Product product;

            using (var streamReader = new StreamReader(contentStream))
            using (var jsonTextReader = new JsonTextReader(streamReader))
            {
                product = serializer.Deserialize<Product>(jsonTextReader);
            }

            Logger.Trace("Product deserialization completed in {0} [ms]", sw.ElapsedMilliseconds);

            return product;
        }

        /// <summary>
        /// Create a <see cref="JsonSerializer"/>
        /// </summary>
        /// <returns>
        /// an instance of <see cref="JsonSerializer"/>
        /// </returns>
        private JsonSerializer CreateJsonSerializer()
        {
            Logger.Trace("initializing JsonSerializer");
            var serializer = new JsonSerializer
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };

            return serializer;
        }
    }
}