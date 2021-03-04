
using OpenQA.Selenium.Chrome;
using BoDi;
using TechTalk.SpecFlow;

namespace BCars.Hooks
{
    [Binding]
    public sealed class Hooks
    {

        private DriverHelper _driverHelper;
        public Hooks(DriverHelper driverHelper) => _driverHelper = driverHelper;


        [BeforeScenario]
        public void BeforeScenario()
        {
            _driverHelper.Driver = new ChromeDriver(@"C:\BuggyCars");
            _driverHelper.Driver.Navigate().GoToUrl("https://buggy.justtestit.org/");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driverHelper.Driver.Quit();
        }

    }
}