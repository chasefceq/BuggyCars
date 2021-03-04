using OpenQA.Selenium;

namespace BCars.Pages
{
    public class LoginPage
    {
        public IWebDriver _page { get; }
        public LoginPage(IWebDriver webDriver) => _page = webDriver;
        
        public IWebElement txtUsername => _page.FindElement(By.Name("login"));
        public IWebElement txtPassword => _page.FindElement(By.Name("password"));
        public IWebElement btnLogin => _page.FindElement(By.XPath("//button[text()='Login']"));
        public IWebElement lnkProfile => _page.FindElement(By.XPath("//a[@class='nav-link'][text()='Profile']"));
        public IWebElement loginErrorMessage => _page.FindElement(By.XPath("//span[contains(text(), 'Invalid username/password')]"));
        
        public void ClickLoginButton() => btnLogin.Submit();
        public void ClickProfileLink() => lnkProfile.Click();
        public bool IsMyProfileExist() => lnkProfile.Displayed;
        public bool IsLoginErrorExist() => loginErrorMessage.Displayed;

        public void Login(string userName)
        {
            txtUsername.SendKeys(userName);
        }

        public void Password(string password)
        {
            txtPassword.SendKeys(password);
        }


    }
}