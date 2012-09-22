namespace Lesula.Core
{
    using Funq;

    /// <summary>
    /// Application context
    /// </summary>
    public static class Context
    {
        /// <summary>
        /// Get the current context
        /// </summary>
        public static IContext Current
        {
            get
            {
                return Container.Resolve<IContext>();
            }
        }

        /// <summary>
        /// private value for DI containers
        /// </summary>
        private static Container container;

        /// <summary>
        /// DI Container
        /// </summary>
        public static Container Container
        {
            get
            {
                return container ?? (container = new Container());
            }

            internal set
            {
                container = value;
            }
        }
    }
}
