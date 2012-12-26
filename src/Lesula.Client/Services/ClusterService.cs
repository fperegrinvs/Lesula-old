namespace Lesula.Client.Services
{
    using System;

    /// <summary>
    /// The cluster service.
    /// </summary>
    public class ClusterService
    {
        /// <summary>
        /// default instance
        /// </summary>
        private static ClusterService instance = new ClusterService();

        /// <summary>
        /// Gets or sets the default instance.
        /// </summary>
        public static ClusterService DefaultInstance
        {
            get
            {
                return instance ?? (instance = new ClusterService());
            }

            set
            {
                instance = value;
            }
        }

        /// <summary>
        /// Say "hello I'm alive" and update current status (iddle, doing stuff, etc)
        /// </summary>
        public void UpdateStatus()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Register the machine as a map/reducer client
        /// </summary>
        public void BootStrap()
        {
            throw new NotImplementedException();
        }
    }
}
