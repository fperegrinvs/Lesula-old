// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserController.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   Gerenciamento de usuários.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Admin.Controllers
{
    using System;
    using System.Web.Mvc;

    using Lesula.Admin.Contracts;
    using Lesula.Admin.Contracts.Models;
    using Lesula.Admin.Extensions;
    using Lesula.Core;

    /// <summary>
    /// Gerenciamento de usuários.
    /// </summary>
    public class UserController : AdminBaseController
    {
        //
        // GET: /User/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var users = Context.Container.Resolve<IUserDalc>().GetAllUsers();
            return View(users);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var user = new User();
            return View(user);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(User user)
        {
            try
            {
                user.Roles = user.BindFlagsFor(u => u.Roles);
                Context.Container.Resolve<IUserDalc>().SaveUser(user);
                SuccessMessage = SuccessMessageDefault;
                return this.RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ErrorMessage = ErrorMessageDefault;
                return this.View();
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
            var user = Context.Container.Resolve<IUserDalc>().GetUser(id);

            return View(user);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(User user)
        {
            try
            {
                user.Roles = user.BindFlagsFor(u => u.Roles);

                Context.Container.Resolve<IUserDalc>().SaveUser(user);
                SuccessMessage = SuccessMessageDefault;
                return this.RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ErrorMessage = ErrorMessageDefault;
                return this.View();
            }
        }
    }
}
