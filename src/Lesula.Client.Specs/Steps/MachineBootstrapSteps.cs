using System;
using TechTalk.SpecFlow;

namespace Lesula.Client.Specs.Steps
{
    [Binding]
    public class MachineBootstrapSteps
    {
        [Given(@"the cluster have (.*) machines")]
        public void GivenTheClusterHaveMachines(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the cluster have (.*) machines and each machine is configured to have (.*) peers")]
        public void GivenTheClusterHaveMachinesAndEachMachineIsConfiguredToHavePeers(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"(.*) machines bootstraps")]
        public void WhenMachinesBootstraps(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"(.*) machine bootstraps")]
        public void WhenMachineBootstraps(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"(.*) machines bootstrap")]
        public void WhenMachinesBootstrap(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"cluster summary info is wrong")]
        public void WhenClusterSummaryInfoIsWrong()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"cluster must contain (.*) machines")]
        public void ThenClusterMustContainMachines(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the new machine must be listed as peer of (.*) machines")]
        public void ThenTheNewMachineMustBeListedAsPeerOfMachines(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"some machine must fix the summary")]
        public void ThenSomeMachineMustFixTheSummary()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
