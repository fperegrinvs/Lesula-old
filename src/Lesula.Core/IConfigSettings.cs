// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConfigSettings.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   
//    http://www.apache.org/licenses/LICENSE-2.0
//   
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// <summary>
//   Interface que armazena configurações sobre a aplicação.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Core
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface que armazena configurações sobre a aplicação.
    /// </summary>
    public interface IConfigSettings
    {
        /// <summary>
        /// Gets the values associated with the specified property combined into one comma-separated list.
        /// </summary>
        /// <typeparam name="T">
        /// Tipo do parâmetro esperado
        /// </typeparam>
        /// <param name="property">
        /// The String key of the entry that contains the values to get.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// A String that contains a comma-separated list of the values associated with the specified key from the configuration, if found; otherwise, null.
        /// </returns>
        bool Get<T>(string property, out T value);

        /// <summary>
        /// Gets the values associated with the specified property combined into one comma-separated list.
        /// </summary>
        /// <param name="property">
        /// The String key of the entry that contains the values to get.
        /// </param>
        /// <returns>
        /// A String that contains a comma-separated list of the values associated with the specified key from the configuration, if found; otherwise, null.
        /// </returns>
        string Get(string property);

        /// <summary>
        /// Retorna todas as configurações do usuário.
        /// </summary>
        /// <returns>
        /// Todas as configurações do usuário.
        /// </returns>
        Dictionary<string, string> GetAll();

        /// <summary>
        /// Sets the values associated with the specified property combined into one comma-separated list.
        /// </summary>
        /// <param name="property">The String key of the entry.</param>
        /// <param name="value">The new value for the entry</param>
        void Set(string property, string value);
    }
}
