// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdminBaseController.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   Controller base usado no admin
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Admin.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// Controller base usado no admin
    /// </summary>
    public abstract class AdminBaseController : Controller
    {
        /// <summary>
        /// Sets SuccessMessage.
        /// </summary>
        protected string SuccessMessage
        {
            set
            {
                this.TempData["SuccessMessage"] = value;
            }
        }

        /// <summary>
        /// Sets ErrorMessage.
        /// </summary>
        protected string ErrorMessage
        {
            get
            {
                return this.TempData["ErrorMessage"] as string;
            }

            set
            {
                this.TempData["ErrorMessage"] = value;
            }
        }

        protected string SuccessMessageDefault
        {
            get
            {
                return "Save Success!";
            }
        }

        protected string ErrorMessageDefault
        {
            get
            {
                return "There was an error saving changes.";
            }
        }
    }
}
