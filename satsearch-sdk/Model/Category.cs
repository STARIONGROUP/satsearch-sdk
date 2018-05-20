// -------------------------------------------------------------------------------------------------
// <copyright file="Category.cs" company="RHEA System S.A.">
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
    /// Represents a category of <see cref="Product"/>s provided by the SatSearc service.
    /// </summary>
    public class Category : Thing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        public Category()
        {
            this.Children = new List<Category>();
        }

        /// <summary>
        /// Gets or sets the unqiue identifier of the parent cateegory
        /// </summary>
        [JsonProperty("parent_uuid")]
        public Guid Parent { get; set; }

        /// <summary>
        /// Gets or sets the child categories of the current category
        /// </summary>
        public List<Category> Children { get; set; }
    }
}