// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   Informações sobre um usuário.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Admin.Contracts.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using Lesula.Admin.Contracts.Enumerators;

    /// <summary>
    /// Informações sobre um usuário.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Nome do usuário
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Papeis do usuário.
        /// </summary>
        public UserRole Roles { get; set; }

        /// <summary>
        /// Email do usuário.
        /// </summary>
        [Required]
        [DisplayName("E-Mail")]
        public string Email { get; set; }

        /// <summary>
        /// Senha do usuário.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Status do usuário.
        /// </summary>
        public UserStatus Status { get; set; }
    }
}
