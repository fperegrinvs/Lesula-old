// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinderExtensions.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   Helpers para facilitar o binding de objetos.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Admin.Extensions
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    /// <summary>
    /// Helpers para facilitar o binding de objetos.
    /// </summary>
    public static class BinderExtensions
    {
        /// <summary>
        /// Binder para enumeradores do tipo Flag
        /// </summary>
        /// <typeparam name="TModel">Tipo do modelo que contém a propriedade</typeparam>
        /// <typeparam name="TProperty">Tipo da propriedade</typeparam>
        /// <param name="model">referência para o modelo</param>
        /// <param name="expression">expressão lambda para acessar a propriedade</param>
        /// <returns>Valor para a propriedade</returns>
        public static TProperty BindFlagsFor<TModel, TProperty>(this TModel model, Expression<Func<TModel, TProperty>> expression) where TModel : class
        {
            string name = SelectExtensions.GetInputName(expression);
            var formValue = HttpContext.Current.Request.Form[name];

            if (string.IsNullOrWhiteSpace(formValue))
            {
                return default(TProperty);
            }

            string value = formValue.Split(',').Aggregate(0, (acc, v) => acc |= Convert.ToInt32(v), acc => acc).ToString();
            return (TProperty)Enum.Parse(typeof(TProperty), value);
        }
    }
}
