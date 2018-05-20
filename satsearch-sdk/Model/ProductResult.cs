// -------------------------------------------------------------------------------------------------
// <copyright file="ProductResult.cs" company="RHEA System S.A.">
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
    using System.Collections.Generic;
    using satsearch.sdk.API;

    /// <summary>
    /// Represents the results returned from a SatSearch product search
    /// </summary>
    public class ProductResult : AbstractResult
    {
        /// <summary>
        /// Gets or sets the Array of search result objects.
        /// </summary>
        public IEnumerable<Product> Data { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="SearchParameter"/> that was used to execute the search request
        /// </summary>
        public SearchParameter SearchParameter { get; set; }
    }
}