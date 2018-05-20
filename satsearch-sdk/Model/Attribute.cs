// -------------------------------------------------------------------------------------------------
// <copyright file="Attribute.cs" company="RHEA System S.A.">
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
    /// Represents an Attribute of a property which represents a Parameter / ParameterType
    /// </summary>
    public class Attribute
    {
        /// <summary>
        /// Satsearch product attribute class schema
        /// </summary>
        [JsonProperty("class")]
        public AttributeType AttributeType { get; set; }

        /// <summary>
        /// Gets or sets the Product configuration for the current attribute instance
        /// </summary>
        [JsonProperty("product_configuration")]
        public string ProductConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the Product subcomponent for the current attribute instance
        /// </summary>
        [JsonProperty("product_subcomponent")]
        public string ProductSubcomponent { get; set; }

        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the Minimum Value
        /// </summary>
        [JsonProperty("minimum_value")]
        public string MinimumValue { get; set; }

        /// <summary>
        /// Gets or sets the Maximum Value
        /// </summary>
        [JsonProperty("maximum_value")]
        public string MaximumValue { get; set; }

        /// <summary>
        /// Gets or sets the Measurement unit of the current attribute instance
        /// </summary>
        /// <remarks>
        /// The MeasurementUnit shall be mapped to a 10-25 <see cref="MeasurementScale"/>
        /// </remarks>
        [JsonProperty("measurement_unit")]
        public string MeasurementUnit { get; set; }

        /// <summary>
        /// Gets or sets the Optional notes about the current attribute instance
        /// </summary>
        public string Description { get; set; }
    }
}