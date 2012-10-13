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
    using System.Linq;
    using System.Web.Mvc;

    using Lesula.Admin.Contracts;
    using Lesula.Client.Contracts.Models;
    using Lesula.Core;

    /// <summary>
    /// The data type controller.
    /// </summary>
    public class DataSourceController : AdminBaseController
    {
        public ActionResult Index()
        {
            var sources = Context.Container.Resolve<IDataSourceDalc>().GetAllDataSources();
            return this.View(sources);
        }

        public ActionResult Create()
        {
            var dataSource = new DataSource
            {
                Id = Guid.NewGuid(),
            };

            ViewBag.Jobs = Context.Container.Resolve<IJobDalc>().GetAllJobs().Select(job =>
                  new SelectListItem
                  {
                      Selected = false,
                      Text = job.Name,
                      Value = job.Id.ToString()
                  });

            ViewBag.DataTypes = Context.Container.Resolve<IDataTypeDalc>().GetAllDataTypes().Select(dataType =>
                  new SelectListItem
                  {
                      Selected = false,
                      Text = dataType.Name,
                      Value = dataType.Id.ToString()
                  });

            return this.View(dataSource);
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
        public ActionResult Create(DataSource collection)
        {
            try
            {
                Context.Container.Resolve<IDataSourceDalc>().SaveDataSource(collection);
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
            var dataSource = Context.Container.Resolve<IDataSourceDalc>().GetDataSource(id);
            return this.View(dataSource);
        }

        [HttpPost]
        public ActionResult Edit(DataSource collection)
        {
            try
            {
                Context.Container.Resolve<IDataSourceDalc>().SaveDataSource(collection);
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
