// -------------------------------------------------------------------------------------------------
// <copyright file="SearchParameter.cs" company="RHEA System S.A.">
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
    using System.Collections.Generic;
    using System.Linq;
    using satsearch.sdk.Model;

    /// <summary>
    /// The purpose of the <see cref="SearchParameter"/>
    /// </summary>
    public class SearchParameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchParameter"/>
        /// </summary>
        public SearchParameter()
        {
            this.Categories = new List<Category>();
            this.Suppliers = new List<Supplier>();
        }

        /// <summary>
        /// Gets or sets the categories that <see cref="Product"/>s are to be searched for.
        /// </summary>
        public List<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets a filter based on product name (pattern matching).
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// Gets or sets a filter based on supplier name (pattern matching).
        /// </summary>
        public List<Supplier> Suppliers { get; set; }

        /// <summary>
        /// Gets or sets the Results page number (defaults to 1).
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Gets or sets the Results page size (defaults to 10).
        /// </summary>
        public int? PageSize { get; set; }
        
        /// <summary>
        /// Returns a string that represents the current object
        /// </summary>
        /// <returns>
        /// a string representation of the object
        /// </returns>
        public override string ToString()
        {
            var queryParameters = new List<string>();
            
            foreach (var category in this.Categories)
            {
                queryParameters.Add($"category_uuids={category.Uuid}");
            }

            foreach (var supplier in this.Suppliers)
            {
                queryParameters.Add($"supplier_uuids={supplier.Uuid}");
            }
            
            if (!string.IsNullOrEmpty(this.Product) || !string.IsNullOrWhiteSpace(this.Product))
            {
                queryParameters.Add($"product_name={this.Product}");
            }

            if (this.Page.HasValue)
            {
                queryParameters.Add($"page={this.Page.Value}");
            }

            if (this.PageSize.HasValue)
            {
                queryParameters.Add($"page_size={this.PageSize.Value}");
            }
            
            return string.Join("&", queryParameters);
        }
    }
}