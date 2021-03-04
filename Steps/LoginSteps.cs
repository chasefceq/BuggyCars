using BCars.Pages;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace BCars
{
    [Binding]
    public class LoginSteps

    {
        private DriverHelper _driverHelper;
        public LoginSteps(DriverHelper driverHelper) => _driverHelper = driverHelper;
        LoginPage loginPage = null;
   

        [Given(@"I launch the application")]
        public void GivenILaunchTheApplication()
        {
 
            loginPage = new LoginPage(_driverHelper.Driver);
            String URL = _driverHelper.Driver.Url;
            Assert.AreEqual(URL, "https://buggy.justtestit.org/");
        }

        [Given(@"I enter the following details")]
        public void GivenIEnterTheFollowingDetails(Table table)
        {
            var uname = table.Rows.First()["UserName"].ToString();
            var password = table.Rows.First()["Password"].ToString();

            loginPage.Login(uname);
            loginPage.Password(password);
        }

        [When(@"I click the login button")]
        
        public void GivenIClickLoginButton()
        {
            loginPage.ClickLoginButton();
            Thread.Sleep(2000);
        }

        [Then(@"I should see my Profile link")]
        public void ThenIShouldSeeMyProfileLink()
        {
            Assert.That(loginPage.IsMyProfileExist(), Is.True);  
        }

        [Then(@"login failed")]
        public void ThenLoginFailed()
        {
            Assert.IsTrue(loginPage.IsLoginErrorExist(), "Login error message displayed");
        }
    }
}
