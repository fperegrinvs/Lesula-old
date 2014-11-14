// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JobController.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   Defines the JobController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Admin.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Lesula.Admin.Contracts;
    using Lesula.Client.Contracts.Enumerators;
    using Lesula.Client.Contracts.Models;
    using Lesula.Core;

    public class TransformationController : AdminBaseController
    {
        public ActionResult Index()
        {
            var jobs = Context.Container.Resolve<ITransformationDalc>().GetAllTransformations();
            return this.View(jobs);
        }

        public ActionResult Create()
        {
            var job = new DataTransformation
            {
                Id = Guid.NewGuid(),
                JobType = TransformationType.Mapper,
                Code = Properties.Resources.NewMapper
            };

            this.EditorViewBag();
            return this.View(job);
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
        public ActionResult Create(DataTransformation collection)
        {
            try
            {
                Context.Container.Resolve<ITransformationDalc>().SaveTransformation(collection);
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
            var job = Context.Container.Resolve<ITransformationDalc>().GetTransformation(id);
            this.EditorViewBag();
            return this.View("Create", job);
        }

        [HttpPost]
        public ActionResult Edit(DataTransformation collection)
        {
            try
            {
                Context.Container.Resolve<ITransformationDalc>().SaveTransformation(collection);
                return this.RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
                return this.View("Create", collection);
            }
        }

        [NonAction]
        private void EditorViewBag()
        {
            var jobList = Context.Container.Resolve<ITransformationDalc>().GetAllTransformations().OrderBy(j => j.Name);
            ViewBag.JobList = new SelectList(jobList, "Id", "Name");
            ViewBag.MapperCode = Properties.Resources.NewMapper;
            ViewBag.ReducerCode = Properties.Resources.NewReducer;
        }
    }
}
