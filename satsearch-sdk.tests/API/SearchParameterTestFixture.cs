// -------------------------------------------------------------------------------------------------
// <copyright file="SearchParameterTestFixture.cs" company="RHEA System S.A.">
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
    using System.Collections.Generic;
    using NUnit.Framework;
    using satsearch.sdk.API;
    using satsearch.sdk.Model;
    
    /// <summary>
    /// Suite of tests for the <see cref="SearchParameter"/> class
    /// </summary>
    [TestFixture]
    public class SearchParameterTestFixture
    {
        [Test]
        public void Verify_that_to_string_returns_expected_result()
        {
            var category = new Category { Uuid = Guid.Parse("fdc836a2-7a0e-5bce-ac48-8225ddb73a83") };

            var supplier = new Supplier { Uuid = Guid.Parse("6d706383-2b27-5942-9c55-385f4e425ff6") };

            var product = "reaction wheel";

            var searchParameter = new SearchParameter();
            searchParameter.Categories = new List<Category> { category };
            searchParameter.Suppliers = new List<Supplier> { supplier };
            searchParameter.Product = product;

            Assert.AreEqual("category_uuids=fdc836a2-7a0e-5bce-ac48-8225ddb73a83&supplier_uuids=6d706383-2b27-5942-9c55-385f4e425ff6&product_name=reaction wheel", searchParameter.ToString());
        }
    }
}
