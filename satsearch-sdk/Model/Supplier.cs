// -------------------------------------------------------------------------------------------------
// <copyright file="Supplier.cs" company="RHEA System S.A.">
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
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a <see cref="Supplier"/> from the satsearch.co service
    /// </summary>
    public class Supplier : Thing
    {
        /// <summary>
        /// Gets or sets the Url of the supplier on satsearch.co
        /// </summary>
        [JsonProperty("supplier_url")]
        public string SupplierUrl { get; set; }

        /// <summary>
        /// Gets or sets the Url to supplier logo
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Supplier"/> description
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the date when the <see cref="Supplier"/> was last modified.
        /// </summary>
        [JsonProperty("last_modified")]
        public DateTime LastModified { get; set; }
    }
}