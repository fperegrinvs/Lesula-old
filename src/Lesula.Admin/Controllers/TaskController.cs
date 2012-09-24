// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskController.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   Defines the TaskController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Admin.Controllers
{
    using System;
    using System.Web.Mvc;

    using Lesula.Admin.Contracts;
    using Lesula.Admin.Contracts.Models;
    using Lesula.Core;

    public class TaskController : AdminBaseController
    {
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var tasks = Context.Container.Resolve<ITaskDalc>().GetAll();
            return this.View(tasks);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var task = new Task { Id = Guid.NewGuid() };
            return this.View(task);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Task task)
        {
            try
            {
                task.ChangedBy = User.Identity.Name;
                task.ChangedDate = DateTime.Now;
                Context.Container.Resolve<ITaskDalc>().Save(task);
                this.SuccessMessage = this.SuccessMessageDefault;
                return this.RedirectToAction("Index");
            }
            catch (Exception)
            {
                ErrorMessage = ErrorMessageDefault;
                return this.View();
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid id)
        {
            var user = Context.Container.Resolve<ITaskDalc>().Get(id);
            return this.View(user);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Task task)
        {
            try
            {
                task.ChangedBy = User.Identity.Name;
                task.ChangedDate = DateTime.Now;
                Context.Container.Resolve<ITaskDalc>().Save(task);
                this.SuccessMessage = this.SuccessMessageDefault;
                return this.RedirectToAction("Index");
            }
            catch (Exception)
            {
                ErrorMessage = ErrorMessageDefault;
                return this.View();
            }
        }
    }
}
