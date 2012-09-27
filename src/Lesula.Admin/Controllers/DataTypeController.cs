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
    using System.Web.Mvc;

    using Lesula.Client.Contracts.Models;

    /// <summary>
    /// The data type controller.
    /// </summary>
    public class DataTypeController : AdminBaseController
    {
        public ActionResult Index()
        {
            return View();
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

        [HttpPost]
        public ActionResult Create(DataType collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(Guid id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(DataType collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
