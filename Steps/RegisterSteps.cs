using BCars.Pages;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;


namespace BCars.Features
{
    [Binding]
    public class RegisterSteps
    {
        private DriverHelper _driverHelper;
        public RegisterSteps(DriverHelper driverHelper) => _driverHelper = driverHelper;
        RegisterPage registerPage = null;
        public string username = null;
        public string pword = null;

        [Given(@"click the Register link")]
        public void GivenClickTheRegisterLink()
        {
            registerPage = new RegisterPage(_driverHelper.Driver);
            Thread.Sleep(2000);
            registerPage.ClickRegister();
        }


        [Given(@"I enter the register my details")]
        public void GivenIEnterTheRegisterMyDetails(Table table)
        {
            var uname = table.Rows.First()["UserName"].ToString();
            var fname = table.Rows.First()["FirstName"].ToString();
            var lname = table.Rows.First()["LastName"].ToString();
            var pword = table.Rows.First()["Password"].ToString();
            var cpword = table.Rows.First()["ConfirmPass"].ToString();

            registerPage.Register(uname, fname, lname, pword, cpword);
        }

        [Given(@"I enter the register my details with random username")]
        public void GivenIEnterTheRegisterMyDetailsWithRandomUsername(Table table)
        {
            username = Faker.Internet.UserName();
            var fname = table.Rows.First()["FirstName"].ToString();
            var lname = table.Rows.First()["LastName"].ToString();
            pword = table.Rows.First()["Password"].ToString();
            var cpword = table.Rows.First()["ConfirmPass"].ToString();

            registerPage.Register(username, fname, lname, pword, cpword);
        }

        [When(@"I click the Register button")]
        public void WhenIClickTheRegisterButton()
        {
            registerPage.ClickRegisterButton();
            Thread.Sleep(2000);
        }

        [Then(@"I should see success message displayed")]
        public void ThenIShouldSeeSuccessMessageDisplayed()
        {
            Assert.That(registerPage.IsRegisterSuccessMessageExist(), Is.True);
        }


        [Then(@"I should see username error message displayed")]
        public void ThenIShouldSeeUsernameErrorMessageDisplayed()
        {
            Assert.IsTrue(registerPage.IsRgisterErrorUsernameExist(), "Username already exist");
        }

        [Then(@"I should see minimum field error message displayed")]
        public void ThenIShouldSeeMinimumFieldErrorMessageDisplayed()
        {
            Thread.Sleep(1000);
            Assert.IsTrue(registerPage.IsRgisterErrorpasssizeExist(), "Minimum field size of 6");
        }

        [Then(@"I should see password no numeric error message displayed")]
        public void ThenIShouldSeePasswordNoNumericErrorMessageDisplayed()
        {
            Assert.IsTrue(registerPage.IsRgisterErrorpassnumericExist(), "Password must have numeric characters");
        }

        [Then(@"I should see password no lowercase error message displayed")]
        public void ThenIShouldSeePasswordNoLowercaseErrorMessageDisplayed()
        {
            Assert.IsTrue(registerPage.IsRgisterErrorpasslowcaseExist(), "Password must have lowercase characters");
        }

        [Then(@"I should see password no uppercase error message displayed")]
        public void ThenIShouldSeePasswordNoUppercaseErrorMessageDisplayed()
        {
            Assert.IsTrue(registerPage.IsRgisterErrorpassupcaseExist(), "Password must have uppercase characters");
        }

        [Then(@"I should see password no symbol error message displayed")]
        public void ThenIShouldSeePasswordNoSymbolErrorMessageDisplayed()
        {
            Assert.IsTrue(registerPage.IsRgisterErrorpassymbolExist(), "Password must have symbol");
        }

        [Then(@"I should see password do not match error message displayed")]
        public void ThenIShouldSeePasswordDoNotMatchErrorMessageDisplayed()
        {
            Assert.IsTrue(registerPage.IsRgisterErrorpassnotmatchedExist(), "Password do not match");
        }

        [Then(@"I can Login successfully using the newly registered user")]
        public void ThenICanLoginSuccessfullyUsingTheNewlyRegisteredUser()
        {
            LoginPage loginPage = new LoginPage(_driverHelper.Driver);
            loginPage.Login(username);
            loginPage.Password(pword);
            loginPage.ClickLoginButton();
            Thread.Sleep(2000);
            Assert.That(loginPage.IsMyProfileExist(), Is.True);
        }

    }
}
