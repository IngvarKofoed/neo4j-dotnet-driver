﻿//  Copyright (c) 2002-2016 "Neo Technology,"
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
using System.Threading.Tasks;

namespace Neo4j.Driver.Internal
{
    /// <summary>
    ///     Encapsulates a pattern for doing try-catch and logging possible exceptions.
    /// </summary>
    internal static class TryExecute
    {
        /// <summary>
        ///     Executes the <paramref name="action"/> and catches any exceptions that
        ///     might be thown by the exetion of <paramref name="action"/>. 
        ///     Any exceptions are logged with the <paramref name="logger"/>.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <param name="logger">The logger to use to log possible exceptions.</param>
        public static void WithLogger(Action action, ILogger logger)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                logger?.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        ///     Executes the <paramref name="func"/> and catches any exceptions that
        ///     might be thown by the exetion of <paramref name="func"/>. 
        ///     Any exceptions are logged with the <paramref name="logger"/>.
        /// </summary>
        /// <param name="func">The function to execute.</param>
        /// <param name="logger">The logger to use to log possible exceptions.</param>
        /// <returns>The result of executing the <paramref name="func"/></returns>
        public static T WithLogger<T>(Func<T> func, ILogger logger)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                logger?.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        ///     Executes the <paramref name="func"/> and catches any exceptions that
        ///     might be thown by the exetion of <paramref name="func"/>. 
        ///     Any exceptions are logged with the <paramref name="logger"/>.
        /// </summary>
        /// <param name="func">The function to execute.</param>
        /// <param name="logger">The logger to use to log possible exceptions.</param>
        /// <returns>The result of executing the <paramref name="func"/></returns>
        public static async Task WithLoggerAsync(Func<Task> func, ILogger logger)
        {
            try
            {
                await func();
            }
            catch (Exception ex)
            {
                logger?.Error(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        ///     Executes the <paramref name="func"/> and catches any exceptions that
        ///     might be thown by the exetion of <paramref name="func"/>. 
        ///     Any exceptions are logged with the <paramref name="logger"/>.
        /// </summary>
        /// <param name="func">The function to execute.</param>
        /// <param name="logger">The logger to use to log possible exceptions.</param>
        /// <returns>The result of executing the <paramref name="func"/></returns>
        public static async Task<T> WithLoggerAsync<T>(Func<Task<T>> func, ILogger logger)
        {
            try
            {
                return await func();
            }
            catch (Exception ex)
            {
                logger?.Error(ex.Message, ex);
                throw;
            }
        }
    }
}