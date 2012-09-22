// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContext.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   Interface de contexto que é implementada em todas as aplicações da solução
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Core
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface de contexto que é implementada em todas as aplicações da solução
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
    }
}
