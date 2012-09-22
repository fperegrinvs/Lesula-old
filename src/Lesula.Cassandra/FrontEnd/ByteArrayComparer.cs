namespace Lesula.Cassandra
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Comparador para array de bytes.
    /// </summary>
    public class ByteArrayComparer : IEqualityComparer<byte[]>
    {
        /// <summary>
        /// Compara 2 byte[] e diz se são iguais
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// true caso sejam iguais
        /// </returns>
        public bool Equals(byte[] left, byte[] right)
        {
            if (left == null || right == null)
            {
                return left == right;
            }

            return left.SequenceEqual(right);
        }

        /// <summary>
        /// Hashcode para byteArray
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// Hash para o byteArray
        /// </returns>
        public int GetHashCode(byte[] key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            return Encoding.UTF8.GetString(key).GetHashCode();  
        }
    }
}
