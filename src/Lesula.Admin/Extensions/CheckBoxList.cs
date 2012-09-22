// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckBoxList.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   Implementação do CheckBoxList
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Admin.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Implementação do CheckBoxList
    /// </summary>
    public static class HtmlHelperExtensions
    {

        public static string CheckBoxList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> listInfo)
        {
            return htmlHelper.CheckBoxList(name, listInfo,
                ((IDictionary<string, object>)null));
        }

        public static string CheckBoxList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> listInfo, object htmlAttributes)
        {
            return htmlHelper.CheckBoxList(name, listInfo,
                ((IDictionary<string, object>)new RouteValueDictionary(htmlAttributes)));
        }

        public static string CheckBoxList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> listInfo, IDictionary<string, object> htmlAttributes)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("The argument must have a value", "name");
            }

            if (listInfo == null)
            {
                throw new ArgumentNullException("listInfo");
            }

            StringBuilder sb = new StringBuilder();

            foreach (SelectListItem info in listInfo)
            {
                TagBuilder builder = new TagBuilder("input");
                if (info.Selected)
                {
                    builder.MergeAttribute("checked", "checked");
                }

                builder.MergeAttributes(htmlAttributes);
                builder.MergeAttribute("type", "checkbox");
                builder.MergeAttribute("value", info.Value);
                builder.MergeAttribute("name", name);
                builder.InnerHtml = info.Text;
                sb.Append(builder.ToString(TagRenderMode.Normal));
                sb.Append("<br />");
            }

            return sb.ToString();
        }
    }
}
