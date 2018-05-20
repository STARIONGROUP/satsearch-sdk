// -------------------------------------------------------------------------------------------------
// <copyright file="ISatSearchSerializer.cs" company="RHEA System S.A.">
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
    using System.IO;
    using satsearch.sdk.Model;

    /// <summary>
    /// Definition of the interface to deserialze JSON provided by the SatSearch serice.
    /// </summary>
    public interface ISatSearchSerializer
    {
        /// <summary>
        /// Deserialize the SatSearch json to a list of <see cref="Category"/>
        /// </summary>
        /// <param name="json">
        /// a <see cref="Category"/> json string
        /// </param>
        /// <returns>
        /// returns an <see cref="IEnumerable{Category}"/>, this may be empty.
        /// </returns>
        IEnumerable<Category> DeserializeCategories(string json);

        /// <summary>
        /// Deserialize the SatSearch json <see cref="Stream"/> to a list of <see cref="Category"/>
        /// </summary>
        /// <param name="contentStream">
        /// a <see cref="Category"/> json <see cref="Stream"/>
        /// </param>
        /// <returns>
        /// returns an <see cref="IEnumerable{Category}"/>, this may be empty.
        /// </returns>
        IEnumerable<Category> DeserializeCategories(Stream contentStream);

        /// <summary>
        /// Deserialize the SatSearch json to a list of <see cref="Attribute"/>
        /// </summary>
        /// <param name="json">
        /// a <see cref="Attribute"/> json string
        /// </param>
        /// <returns>
        /// returns an <see cref="IEnumerable{Attribute}"/>, this may be empty.
        /// </returns>
        IEnumerable<AttributeType> DeserializeAttributes(string json);

        /// <summary>
        /// Deserialize the SatSearch json <see cref="Stream"/> to a list of <see cref="Attribute"/>
        /// </summary>
        /// <param name="contentStream">
        /// a <see cref="Attribute"/> json <see cref="Stream"/>
        /// </param>
        /// <returns>
        /// returns an <see cref="IEnumerable{Category}"/>, this may be empty.
        /// </returns>
        IEnumerable<AttributeType> DeserializeAttributes(Stream contentStream);

        /// <summary>
        /// Deserialize the satsearch json to a <see cref="SupplierResult"/> object
        /// </summary>
        /// <param name="json"></param>
        /// <returns>
        /// returns an <see cref="SupplierResult"/>.
        /// </returns>
        SupplierResult DeserializeSupplierResult(string json);

        /// <summary>
        /// Deserialize the satsearch json to a <see cref="SupplierResult"/> object
        /// </summary>
        /// <param name="contentStream">
        /// The json stream representation of a single <see cref="SupplierResult"/>
        /// </param>
        /// <returns>
        /// returns an <see cref="SupplierResult"/>.
        /// </returns>
        SupplierResult DeserializeSupplierResult(Stream contentStream);

        /// <summary>
        /// Deserialize the satsearch.co json to a <see cref="Supplier"/>
        /// </summary>
        /// <param name="json">
        /// The json representation of a single <see cref="Supplier"/>
        /// </param>
        /// <returns>
        /// returns an <see cref="Supplier"/>, this may be empty.
        /// </returns>
        Supplier DeserializeSupplier(string json);

        /// <summary>
        /// Deserialize the satsearch.co json to a <see cref="Supplier"/>
        /// </summary>
        /// <param name="contentStream">
        /// The json stream representation of a single <see cref="Supplier"/>
        /// </param>
        /// <returns>
        /// returns an <see cref="Supplier"/>.
        /// </returns>
        Supplier DeserializeSupplier(Stream contentStream);

        /// <summary>
        /// Deserialize the SatSearch json to a <see cref="ProductResult"/> object
        /// </summary>
        /// <param name="json"></param>
        /// <returns>
        /// returns an <see cref="IEnumerable{Product}"/>, this may be empty.
        /// </returns>
        ProductResult DeserializeProductResult(string json);

        /// <summary>
        /// Deserialize the SatSearch json to a <see cref="ProductResult"/> object
        /// </summary>
        /// <param name="contentStream">
        /// The json stream representation of a single <see cref="ProductResult"/>
        /// </param>
        /// <returns>
        /// returns an <see cref="IEnumerable{Product}"/>, this may be empty.
        /// </returns>
        ProductResult DeserializeProductResult(Stream contentStream);

        /// <summary>
        /// Deserialize the SatSearch json to a <see cref="Product"/> object
        /// </summary>
        /// <param name="json">
        /// The json representation of a single <see cref="Product"/>
        /// </param>
        /// <returns>
        /// returns a <see cref="Product"/>
        /// </returns>
        Product DeserializeProduct(string json);

        /// <summary>
        /// Deserialize the SatSearch json to a <see cref="Product"/> object
        /// </summary>
        /// <param name="contentStream">
        /// The json stream representation of a single <see cref="Product"/>
        /// </param>
        /// <returns>
        /// returns a <see cref="Product"/>
        /// </returns>
        Product DeserializeProduct(Stream contentStream);
    }
}