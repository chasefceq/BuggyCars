using BCars.Pages;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace BCars.Steps
{
    [Binding]
    public sealed class VoteSteps
    {
        private DriverHelper _driverHelper;
        public VoteSteps(DriverHelper driverHelper) => _driverHelper = driverHelper;
        VotePage votePage = null;
        public string username = null;
        public string pword = null;

        [Given(@"Register and Login")]
        public void GivenRegisterAndLogin(Table table)
        {
            votePage = new VotePage(_driverHelper.Driver);
            LoginPage loginPage = new LoginPage(_driverHelper.Driver);
            RegisterPage registerPage = new RegisterPage(_driverHelper.Driver);

            Thread.Sleep(1000);
            registerPage.ClickRegister();

            username = Faker.Internet.UserName();
            var fname = table.Rows.First()["FirstName"].ToString();
            var lname = table.Rows.First()["LastName"].ToString();
            pword = table.Rows.First()["Password"].ToString();
            var cpword = table.Rows.First()["ConfirmPass"].ToString();
            registerPage.Register(username, fname, lname, pword, cpword);
            registerPage.ClickRegisterButton();
            Thread.Sleep(1000);
            
            loginPage.Login(username);
            loginPage.Password(pword);
            loginPage.ClickLoginButton();
            Thread.Sleep(1000);
            votePage.BuggyRatingLink();
            Thread.Sleep(1000);
        }

        [When(@"I select the model and input my comments")]
        public void WhenISelectTheModelAndInputMyComments(Table table)
        {

            var type = table.Rows.First()["VotingType"].ToString();
            var comment = table.Rows.First()["Comment"].ToString();


            if (type == "Popular Make")
            {
                votePage.PopularMakeLink();
                Thread.Sleep(1000);
                votePage.PopularModelName();
                Thread.Sleep(2000);
                votePage.Vote(comment);
                Thread.Sleep(1000);
            }
            else if (type == "Popular Model")
            {
                votePage.PopularModelLink();
                Thread.Sleep(1000);
                votePage.Vote(comment);
                Thread.Sleep(1000);

            }
            else if (type == "Overall Rating")
            {
                votePage.OverallRatinglLink();
                Thread.Sleep(1000);
                votePage.PopularModelName();
                Thread.Sleep(2000);
                votePage.Vote(comment);
                Thread.Sleep(1000);
            }
        }


        [When(@"I click vote")]
        public void WhenIClickVote()
        {
            votePage.ClickVote();
            Thread.Sleep(2000);
        }



        [Then(@"I can see the success message displayed")]
        public void ThenICanSeeTheSuccessMessageDisplayed()
        {
            Assert.That(votePage.IsVoteSuccessMessageExist(), Is.True);
        }


        [Then(@"I Cannot vote again on the same model")]
        public void ThenICannotVoteAgainOnTheSameModel()
        {  
            Assert.That(votePage.IsVoteSuccessMessageExist(), Is.True);
        }

        [When(@"I select the model and try to vote")]
        public void WhenISelectTheModelAndTryToVote(Table table)
        {
            votePage = new VotePage(_driverHelper.Driver);
            Thread.Sleep(2000);
            var type = table.Rows.First()["VotingType"].ToString();
           
            if (type == "Popular Make")
            {
                votePage.PopularMakeLink();
                Thread.Sleep(1000);
                votePage.PopularModelName();
                Thread.Sleep(2000);
            }
            else if (type == "Popular Model")
            {
                votePage.PopularModelLink();
                Thread.Sleep(2000);

            }
            else if (type == "Overall Rating")
            {
                votePage.OverallRatinglLink();
                Thread.Sleep(1000);
                votePage.PopularModelName();
                Thread.Sleep(2000);
            }
        }

        [Then(@"I can see the message prompting me to login to vote")]
        public void ThenICanSeeTheMessagePromptingMeToLoginToVote()
        {
            Assert.That(votePage.IsLoginToVoteMessageExist(), Is.True);
        }

    }
}
