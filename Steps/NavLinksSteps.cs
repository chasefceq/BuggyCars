using BCars.Pages;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace BCars.Steps
{
    [Binding]
    public sealed class NavLinksSteps
    {
        private DriverHelper _driverHelper;
        public NavLinksSteps(DriverHelper driverHelper) => _driverHelper = driverHelper;
        NavLinksPage navLinksPage => new NavLinksPage (_driverHelper.Driver);

        [When(@"I Navigate to any pagename")]
        public void WhenINavigateToAnyPagename(Table table)
        {
            VotePage votePage = new VotePage(_driverHelper.Driver);
            Thread.Sleep(1000);
            var type = table.Rows.First()["PageName"].ToString();

            if (type == "Popular Make")
            {
                votePage.PopularMakeLink();
                Thread.Sleep(1000);
            }
            else if (type == "Popular Model")
            {
                votePage.PopularModelLink();
                Thread.Sleep(1000);

            }
            else if (type == "Overall Rating")
            {
                votePage.OverallRatinglLink();
                Thread.Sleep(1000);
            }
        }

        [Then(@"I should be able to navigate back to my homepage")]
        public void ThenIShouldBeAbleToNavigateBackToMyHomepage()
        {

            navLinksPage.NavigatetoHomepage();
            String URL = _driverHelper.Driver.Url;
            Assert.AreEqual(URL, "https://buggy.justtestit.org/");
        }

    }
}
