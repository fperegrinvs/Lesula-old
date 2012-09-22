﻿namespace Lesula.Cassandra.Configuration
{
    using System;
    using System.Configuration;

    /// <summary>
    /// Configuration element to hold endpointManager information
    /// </summary>
    public class EndpointManagerElement : ConfigurationElement
    {
        /// <summary>
        /// get or set the type to use
        /// </summary>
        [ConfigurationProperty("type", DefaultValue="ROUNDROBIN", IsRequired = true)]
        public string Type
        {
            get
            {
                return (string)this["type"];
            }
            set
            {
                this["type"] = value;
            }
        }

        /// <summary>
        /// get or set the collection of CassandraEndpoints
        /// </summary>
        [ConfigurationProperty("cassandraEndpoints", IsRequired = true)]
        [ConfigurationCollection(typeof(CassandraClusterElement), AddItemName = "add", RemoveItemName = "remove", ClearItemsName = "clear")]
        public CassandraEndpointCollection CassandraEndpoints
        {
            get
            {
                return (CassandraEndpointCollection)this["cassandraEndpoints"];
            }
            set
            {
                this["cassandraEndpoints"] = value;
            }
        }

        /// <summary>
        /// get or set the DefaultTime to be used when the CassandraEndpoint does not explicity declare one.
        /// </summary>
        [ConfigurationProperty("defaultTimeout", DefaultValue = "3000", IsRequired = true)]
        [IntegerValidator(MinValue = 1, MaxValue = Int32.MaxValue)]
        public int DefaultTimeout
        {
            get
            {
                return (int)this["defaultTimeout"];
            }
            set
            {
                this["defaultTimeout"] = value;
            }
        }
    }
}
