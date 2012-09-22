namespace Lesula.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using Funq;

    /// <summary>
    /// Implementação simples de contexto para ser usado em threads.
    /// </summary>
    public class ThreadContext : IContext
    {
        /// <summary>
        /// Contexto modelado para uma app específica.
        /// </summary>
        private object appContext;

        /// <summary>
        /// Prevents a default instance of the <see cref="ThreadContext"/> class from being created.
        /// </summary>
        private ThreadContext()
        {
        }

        /// <summary>
        /// Lista de erros provenientes de catches
        /// </summary>
        public List<Exception> ErrorList { get; set; }

        /// <summary>
        /// Variável estática que contém o contexto da thread
        /// </summary>
        [ThreadStatic]
        private static ThreadContext threadContext;

        /// <summary>
        /// Variável para identificar o contexto da thread
        /// </summary>
        [ThreadStatic]
        private static int contextId;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThreadContext"/> class. 
        /// Retorna instância com o contexto.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// Instância que implemente a interface IContext
        /// </returns>
        public static IContext CreateInstance()
        {
            if (contextId == Thread.CurrentContext.ContextID && threadContext != null)
            {
                return threadContext;
            }

            var threadDataSlot = Thread.GetNamedDataSlot("ThreadContext_" + Thread.CurrentContext.ContextID);
            ThreadContext context = null;

            if (threadDataSlot != null)
            {
                context = (ThreadContext)Thread.GetData(threadDataSlot);
            }

            if (context == null)
            {
                context = new ThreadContext();
                Thread.SetData(threadDataSlot, context);
            }

            contextId = Thread.CurrentContext.ContextID;
            threadContext = context;
            return context;
        }

        /// <summary>
        /// Adicionar Uma nova Exception
        /// </summary>
        /// <param name="ex">nova exception</param>
        public void StoreException(Exception ex)
        {
            if (this.ErrorList == null)
            {
                this.ErrorList = new List<Exception>();
            }

            this.ErrorList.Add(ex);
        }

        /// <summary>
        /// Retorna dados do contexto local
        /// </summary>
        /// <typeparam name="T">tipo de dados do contexto</typeparam>
        /// <returns>container usado pela aplicação</returns>
        public T GetAppContext<T>() where T : class
        {
            return (T)this.appContext;
        }

        /// <summary>
        /// Define contexto local
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <typeparam name="T">
        /// tipo de dados do contexto
        /// </typeparam>
        public void SetAppContext<T>(T context) where T : class
        {
            this.appContext = context;
        }
    }
}
