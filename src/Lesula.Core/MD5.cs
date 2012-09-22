// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MD5.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   Defines the MD5 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text;

namespace Lesula.Core
{
    public static class MD5
    {
        public static string GetMD5Hexa(this string input)
        {
            var x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var bs = Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            var s = new StringBuilder();
            foreach (var b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }

            return s.ToString();
        }

        public static byte[] GetMD5(this byte[] input)
        {
            var x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            return x.ComputeHash(input);
        }
    }
}
