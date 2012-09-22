namespace Lesula.Core
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface de contexto que é implementada em todas as aplicações da solução OneToOne.
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// Lista de erros provenientes de catches
        /// </summary>
        List<Exception> ErrorList { get; }

        /// <summary>
        /// Retorna dados do contexto local
        /// </summary>
        /// <typeparam name="T">tipo de dados do contexto</typeparam>
        /// <returns>container usado pela aplicação</returns>
        T GetAppContext<T>() where T : class;

        /// <summary>
        /// Define contexto local
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <typeparam name="T">
        /// tipo de dados do contexto
        /// </typeparam>
        void SetAppContext<T>(T context) where T : class;

        /// <summary>
        /// Adicionar Uma nova Exception
        /// </summary>
        /// <param name="ex">nova exception</param>
        void StoreException(Exception ex);

        /// <summary>
        /// Retorna instância com o contexto.
        /// </summary>
        /// <returns>
        /// Instância que implemente a interface IContext
        /// </returns>
        IContext CreateInstance();
    }
}
