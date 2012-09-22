namespace Lesula.Core
{
    /// <summary>
    /// Interface para o Factory de dados.
    /// </summary>
    public interface IFactory
    {
        /// <summary>
        /// Cria instancia de classe com base no nome do seu tipo.
        /// </summary>
        /// <param name="alias">
        /// Nome alternativo para resolução da classe
        /// </param>
        /// <typeparam name="T">
        /// Tipo da classe a ser instanciada.
        /// </typeparam>
        /// <returns>
        /// Instância da classe desejada.
        /// </returns>
        T Resolve<T>(string alias = null) where T : class;
    }
}
