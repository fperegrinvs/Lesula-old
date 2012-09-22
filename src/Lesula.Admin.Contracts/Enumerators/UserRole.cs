// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRole.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   Papeis do usuário no sistema.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Admin.Contracts.Enumerators
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Papeis do usuário no sistema.
    /// </summary>
    [Flags]
    public enum UserRole
    {
        /// <summary>
        /// Pode fazer tudo em um determinado cliente.
        /// </summary>
        [Description("Administrator")]
        Admin = 255,

        /// <summary>
        /// Usuário padrão.
        /// </summary>
        User = 1
    }
}
