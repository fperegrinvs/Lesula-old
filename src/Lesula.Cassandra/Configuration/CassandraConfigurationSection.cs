// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CassandraConfigurationSection.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   ConfigurationSection for Aquiles
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Cassandra.Configuration
{
    using System.Configuration;

    /// <summary>
    /// ConfigurationSection for Aquiles
    /// </summary>
    public class CassandraConfigurationSection : ConfigurationSection
    {
        /// <summary>
        /// ctor
        /// </summary>
        protected CassandraConfigurationSection() : base() { }

        /// <summary>
        /// get or set the type of the client class to use for logging purpose
        /// </summary>
        [ConfigurationProperty("monitorFeaturesType", IsRequired = false)]
        public AquilesTextElement MonitorFeaturesType
        {
            get
            {
                return (AquilesTextElement)this["monitorFeaturesType"];
            }
            set
            {
                this["monitorFeaturesType"] = value;
            }
        }

        /// <summary>
        /// get or set the type of the client class to use for logging purpose
        /// </summary>
        [ConfigurationProperty("loggingManager", IsRequired = false)]
        public AquilesTextElement LoggingManager
        {
            get
            {
                return (AquilesTextElement)this["loggingManager"];
            }
            set
            {
                this["loggingManager"] = value;
            }
        }

        /// <summary>
        /// get or set the collection of clusters
        /// </summary>
        [ConfigurationProperty("clusters", IsRequired = true)]
        [ConfigurationCollection(typeof(CassandraClusterElement), AddItemName = "add", RemoveItemName = "remove", ClearItemsName = "clear")]
        public CassandraClusterCollection CassandraClusters
        {
            get
            {
                return (CassandraClusterCollection)this["clusters"];
            }
            set
            {
                this["clusters"] = value;
            }
        }
    }
}
