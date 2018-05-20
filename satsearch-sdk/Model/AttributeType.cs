// -------------------------------------------------------------------------------------------------
// <copyright file="AttributeType.cs" company="RHEA System S.A.">
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
    using Newtonsoft.Json;

    /// <summary>
    /// Representation of a type of Attribute, this maps to a <see cref="ParameterType"/> in 10-25
    /// </summary>
    public class AttributeType : Thing
    {
        /// <summary>
        /// Gets or sets a value that Indicates whether the value is a string or a number
        /// </summary>
        [JsonProperty("value_type")]
        public string ValueType { get; set; }

        /// <summary>
        /// Gets or sets the description of the AttributeType
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Array of possible measurement units
        /// </summary>
        [JsonProperty("allowed_measurement_units")]
        public string[] AllowedMeasurementUnits { get; set; }
    }
}