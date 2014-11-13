// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataTypeController.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   Defines the DataTypeController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;

    using Lesula.Admin.Contracts;
    using Lesula.Client.Contracts.Models;
    using Lesula.CodeParser;
    using Lesula.Core;

    /// <summary>
    /// The data type controller.
    /// </summary>
    public class DataTypeController : AdminBaseController
    {
        public ActionResult Index()
        {
            var types = Context.Container.Resolve<IDataTypeDalc>().GetAllDataTypes();
            return this.View(types);
        }

        public ActionResult Create()
        {
            var dataType = new DataType
                {
                    Id = Guid.NewGuid(),
                    Code = Properties.Resources.NewDataTypeCode
                };

            return this.View(dataType);
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <returns>
        /// The System.Web.Mvc.ActionResult.
        /// </returns>
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(DataType collection)
        {
            try
            {
                // check if datatype is ok
                var checker = new DataTypeChecker();
                var error = checker.CheckDataType(collection);
                if (!string.IsNullOrEmpty(error))
                {
                    this.ErrorMessage = error;
                    return this.View("Create", collection);
                }

                Context.Container.Resolve<IDataTypeDalc>().SaveDataType(collection);
                return this.RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
                return this.View("Create", collection);
            }
        }

        public ActionResult Edit(Guid id)
        {
            var dataType = Context.Container.Resolve<IDataTypeDalc>().GetDataType(id);
            return this.View(dataType);
        }

        [HttpPost]
        public ActionResult Edit(DataType collection)
        {
            try
            {
                Context.Container.Resolve<IDataTypeDalc>().SaveDataType(collection);
                return this.RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
                return View(collection);
            }
        }
    }
}
