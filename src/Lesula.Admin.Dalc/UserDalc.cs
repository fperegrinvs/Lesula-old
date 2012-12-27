// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserDalc.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   Defines the UserDalc type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Admin.Dalc
{
    using System.Collections.Generic;
    using System.Linq;

    using Apache.Cassandra;

    using Lesula.Admin.Contracts;
    using Lesula.Admin.Contracts.Enumerators;
    using Lesula.Admin.Contracts.Models;
    using Lesula.Cassandra;
    using Lesula.Cassandra.FrontEnd;
    using Lesula.Core;
    using Lesula.Core.Cassandra;

    /// <summary>
    /// The user dalc.
    /// </summary>
    public class UserDalc : IUserDalc
    {
        /// <summary>
        /// Retorna dados de um usuário.
        /// </summary>
        /// <param name="email">
        /// email do usuário
        /// </param>
        /// <returns>
        /// /dados do usuário
        /// </returns>
        public User GetUser(string email)
        {
            var selector = DataBase.CreateSelector();
            var columns = selector.GetColumnFromRow("User", email, "DAT", ConsistencyLevel.ONE);
            var user = this.MapFromColumn(columns);
            return user;
        }

        /// <summary>
        /// The get all users.
        /// </summary>
        /// <returns>
        /// The System.Collections.Generic.List`1[T -&gt; Lesula.Admin.Contracts.Models.User].
        /// </returns>
        public List<User> GetAllUsers()
        {
            var selector = DataBase.CreateSelector();
            var rows = selector.GetColumnsFromRows("User", Selector.KeyRangeAll, Selector.NewColumnsPredicate("DAT"), ConsistencyLevel.ONE);
            var users = rows.Select(row => this.MapFromColumn(row.Value[0])).ToList();
            return users;
        }

        /// <summary>
        /// The save user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        public void SaveUser(User user)
        {
            user.Password = user.Password.GetMD5Hexa();
            var serialized = ServiceStack.Text.TypeSerializer.SerializeToString(user);
            var compressed = LZ4Sharp.LZ4.Compress(serialized.ToBytes());

            var mutator = DataBase.CreateMutator();
            var column = mutator.NewColumn("DAT", compressed);
            mutator.InsertColumn("User", user.Email, column, ConsistencyLevel.ONE);
        }

        /// <summary>
        /// Authenticates user
        /// </summary>
        /// <param name="login">user login</param>
        /// <returns>user roles (null if login fails)</returns>
        public UserRole? Authenticate(Login login)
        {
            User user;

            try
            {
                user = this.GetUser(login.Email);
            }
            catch (NotFoundException)
            {
                return null;
            }

            var hash = login.Password.GetMD5Hexa();
            if (user.Password != hash)
            {
                return null;
            }

            return user.Roles;
        }

        /// <summary>
        /// Map data column to User
        /// </summary>
        /// <param name="column">
        /// Column
        /// </param>
        /// <returns>
        /// Resulting user
        /// </returns>
        private User MapFromColumn(Column column)
        {
            var decompressed = LZ4Sharp.LZ4.Decompress(column.Value).ToUtf8String();
            var user = ServiceStack.Text.TypeSerializer.DeserializeFromString<User>(decompressed);
            return user;
        }
    }
}
