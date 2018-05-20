// -------------------------------------------------------------------------------------------------
// <copyright file="Thing.cs" company="RHEA System S.A.">
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

    /// <summary>
    /// Abstract super class from which all objects in the SatSearch domain model classes derive
    /// </summary>
    public abstract class Thing
    {
        /// <summary>
        /// Gets or sets the unique identifier of the <see cref="Thing"/>
        /// </summary>
        public Guid Uuid { get; set; }

        /// <summary>
        /// Gets or sets the human readable name
        /// </summary>
        public string Name { get; set; }
    }
}