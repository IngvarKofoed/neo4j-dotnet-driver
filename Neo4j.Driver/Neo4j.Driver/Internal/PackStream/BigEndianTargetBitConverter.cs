//  Copyright (c) 2002-2016 "Neo Technology,"
//  Network Engine for Objects in Lund AB [http://neotechnology.com]
// 
//  This file is part of Neo4j.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
// 
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

using System;
using System.Linq;

namespace Neo4j.Driver.Internal.Packstream
{
    /// <summary>
    ///     Converts from/to big endian (target) to platform endian.
    /// </summary>
    internal class BigEndianTargetBitConverter : BitConverterBase
    {
        /// <summary>
        ///     Converts the bytes to big endian.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>The bytes converted to big endian.</returns>
        protected override byte[] ToTargetEndian(byte[] bytes)
        {
            if (BitConverter.IsLittleEndian)
            {
                return bytes.Reverse().ToArray();
            }
            return bytes;
        }

        /// <summary>
        ///     Converts the bytes to the platform endian type.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>The bytes converted to the platform endian type.</returns>
        protected override byte[] ToPlatformEndian(byte[] bytes)
        {
            if (BitConverter.IsLittleEndian)
            {
                return bytes.Reverse().ToArray();
            }
            return bytes;
        }
    }
}