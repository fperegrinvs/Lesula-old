// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppConfigSettings.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   Implementação da interface <see cref="IConfigSettings" /> utilizando o web.config para armazenar os dados.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Core
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    /// <summary>
    /// Implementação da interface <see cref="IConfigSettings"/> utilizando o web.config / app.config para armazenar os dados.
    /// </summary>
    public class AppConfigSettings : IConfigSettings
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
        public bool Get<T>(string property, out T value)
        {
            var type = typeof(T).Name;
            bool success = false;

            var setting = ConfigurationManager.AppSettings.Get(property);

            if (setting != null)
            {
                switch (type)
                {
                    case "Int32":
                        int val;
                        success = int.TryParse(setting, out val);
                        value = (T)(object)val;
                        break;
                    case "Int64":
                        long lval;
                        success = long.TryParse(setting, out lval);
                        value = (T)(object)lval;
                        break;
                    case "UInt64":
                        ulong uval;
                        success = ulong.TryParse(setting, out uval);
                        value = (T)(object)uval;
                        break;
                    case "String":
                        value = (T)(object)setting;
                        success = true;
                        break;
                    case "Guid":
                        Guid g;
                        success = Guid.TryParse(setting, out g);
                        value = (T)(object)g;
                        break;
                    case "DateTime":
                        DateTime d;
                        success = DateTime.TryParse(setting, out d);
                        value = (T)(object)d;
                        break;
                    default:
                        {
                            throw new ArgumentException("Tipo de dado não suportado");
                        }
                }
            }
            else
            {
                value = default(T);
            }

            return success;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="property">
        /// The String key of the entry that contains the values to get.
        /// </param>
        /// <returns>
        /// A String that contains a comma-separated list of the values associated with the specified key from the configuration, if found; otherwise, null.
        /// </returns>
        public string Get(string property)
        {
            return ConfigurationManager.AppSettings.Get(property);
        }

        /// <summary>
        /// Retorna todas as configurações do usuário.
        /// </summary>
        /// <returns>
        /// Todas as configurações do usuário.
        /// </returns>
        public Dictionary<string, string> GetAll()
        {
            var dic = new Dictionary<string, string>();

            var settings = ConfigurationManager.AppSettings;
            foreach (var key in settings.AllKeys)
            {
                dic[key] = settings[key];
            }

            return dic;
        }

        /// <summary>
        /// Sets the values associated with the specified property combined into one comma-separated list.
        /// </summary>
        /// <param name="property">The String key of the entry.</param>
        /// <param name="value">The new value for the entry</param>
        public void Set(string property, string value)
        {
            ConfigurationManager.AppSettings.Set(property, value);
        }
    }
}
