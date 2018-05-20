// -------------------------------------------------------------------------------------------------
// <copyright file="Product.cs" company="RHEA System S.A.">
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

namespace satsearch.sdk.Model
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Representation of a product in the SatSearch catalog
    /// </summary>
    public class Product : Thing
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Product"/>
        /// </summary>
        public Product()
        {
            this.Attributes = new List<Attribute>();
            this.Images = new List<string>();
            this.Configurations = new List<string>();
        }
        
        /// <summary>
        /// Gets or sets the name of the supplier
        /// </summary>
        [JsonProperty("supplier_name")]
        public string Supplier { get; set; }

        /// <summary>
        /// Gets or sets the Url of the supplier on satsearch.co
        /// </summary>
        [JsonProperty("supplier_url")]
        public string SupplierUrl { get; set; }

        /// <summary>
        /// Gets or sets the Url of the product on satsearch.co
        /// </summary>
        [JsonProperty("product_url")]
        public string ProductUrl { get; set; }

        /// <summary>
        /// Gets or sets the URIs to images
        /// </summary>
        public List<string> Images { get; set; }

        /// <summary>
        /// Gets or sets the Array of product subcomponents
        /// </summary>
        [JsonProperty("subcomponents")]
        public List<string> SubComponents { get; set; }

        /// <summary>
        /// Gets or sets the Array of product configurations
        /// </summary>
        public List<string> Configurations{ get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Product"/> description
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the Cagetory
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Gets or sets the date when the <see cref="Product"/> was last modified.
        /// </summary>
        [JsonProperty("last_modified")]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Gets or sets a list of Attributes
        /// </summary>
        public List<Attribute> Attributes { get; set; }
    }
}