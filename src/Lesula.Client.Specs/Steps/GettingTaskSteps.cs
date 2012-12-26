// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GettingTaskSteps.cs" company="Lesula MapReduce Framework - http://github.com/lstern/lesula">
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
//   Defines the GettingTaskSteps type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Lesula.Client.Specs.Steps
{
    using System.Collections.Generic;

    using Lesula.Client.Contracts;
    using Lesula.Client.Contracts.Models;
    using Lesula.Client.Services;
    using Lesula.Core;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Rhino.Mocks;

    using TechTalk.SpecFlow;

    [Binding]
    public class GettingATaskToExecuteInTheCorrectOrder
    {
        /// <summary>
        /// Constructor, used to build the testing context
        /// </summary>
        public GettingATaskToExecuteInTheCorrectOrder()
        {
            var taskDalc = MockRepository.GenerateStub<ITaskDalc>();
            ScenarioContext.Current.Add("taskDalc", taskDalc);
            
            Context.Container.Register(c => ThreadContext.CreateInstance());
            Context.Container.Register<IConfigSettings>(c => new AppConfigSettings());
            Context.Container.Register(c => taskDalc);
        }

        [Given(@"The queue is empty")]
        public void GivenTheQueueIsEmpty()
        {
            var taskDalc = (ITaskDalc)ScenarioContext.Current["taskDalc"];
            taskDalc.Stub(c => c.GetTaskList()).Return(new List<ITaskDalc>());
        }
        
        [Given(@"The queue has a new task")]
        public void GivenTheQueueHasANewTask()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the lastest task still running")]
        public void GivenTheLastestTaskStillRunning()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"there's no slot left in the lastest task")]
        public void GivenThereSNoSlotLeftInTheLastestTask()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"there's an slot left in the lastest task")]
        public void GivenThereSAnSlotLeftInTheLastestTask()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the system searches for an task")]
        public void WhenTheSystemSearchesForAnTask()
        {
            var segment =TaskService.DefaultInstance.GetSegment();
            ScenarioContext.Current.Add("currentSegment", segment);
        }
        
        [Then(@"no task is executed")]
        public void ThenNoTaskIsExecuted()
        {
            var segment = (Segment)ScenarioContext.Current["currentSegment"];
            Assert.IsNull(segment);
        }
        
        [Then(@"executes the new task")]
        public void ThenExecutesTheNewTask()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"allocates slots from the lastest task")]
        public void ThenAllocatesSlotsFromTheLastestTask()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
