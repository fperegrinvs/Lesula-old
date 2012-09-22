// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserDalc.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   Defines the IUserDalc type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Admin.Contracts
{
    using System.Collections.Generic;

    using Lesula.Admin.Contracts.Enumerators;
    using Lesula.Admin.Contracts.Models;

    /// <summary>
    /// The UserDalc interface.
    /// </summary>
    public interface IUserDalc
    {
        /// <summary>
        /// Authenticates user
        /// </summary>
        /// <param name="login">user login</param>
        /// <returns>user roles (null if login fails)</returns>
        UserRole? Authenticate(Login login);

        User GetUser(string email);

        void SaveUser(User user);

        List<User> GetAllUsers();
    }
}
