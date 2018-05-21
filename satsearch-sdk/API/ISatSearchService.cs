// -------------------------------------------------------------------------------------------------
// <copyright file="ISatSearchService.cs" company="RHEA System S.A.">
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
    using System.Threading;
    using System.Threading.Tasks;
    using satsearch.sdk.Model;

    /// <summary>
    /// Interface definition of the <see cref="ISatSearchService"/> provides access to the SatSearch data service
    /// </summary>
    public interface ISatSearchService
    {
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
        Task<SupplierResult> SupplierResult(Credentials credentials, CancellationToken cancellationToken, int page = 1);

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
        Task<Supplier> Supplier(Credentials credentials, CancellationToken cancellationToken, Guid id);

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

        Task<IEnumerable<Supplier>> Suppliers(Credentials credentials, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the categories from the SatSearch service.
        /// </summary>
        /// <param name="credentials">
        /// The <see cref="Credentials"/> used to access the satsearch service
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{Category}"/>, this may be empty.
        /// </returns>
        Task<IEnumerable<Category>> Categories(Credentials credentials, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the attribute types from the SatSearch service;
        /// </summary>
        /// <param name="credentials">
        /// The <see cref="Credentials"/> used to access the satsearch service
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{Attribute}"/>, this may be empty.
        /// </returns>
        Task<IEnumerable<Model.AttributeType>> AttributeTypes(Credentials credentials, CancellationToken cancellationToken);

        /// <summary>
        /// Perform a search query on a SatSearch service
        /// </summary>
        /// <param name="searchParameter">
        /// The search query that is to be performed on the SatSearch service.
        /// </param>
        /// <param name="credentials">
        /// The <see cref="Credentials"/> used to access the satsearch service
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{Product}"/> that matches the search query, this may be empty.
        /// </returns>
        Task<ProductResult> Search(Credentials credentials, CancellationToken cancellationToken, SearchParameter searchParameter);

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
        Task<Product> Product(Credentials credentials, CancellationToken cancellationToken, Guid id);
    }
}