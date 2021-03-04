using OpenQA.Selenium;

namespace BCars.Pages
{
    class RegisterPage
    {
        public IWebDriver _page { get; }
        public RegisterPage(IWebDriver webDriver) => _page = webDriver;

        //REGISTERPAGE
        public IWebElement lnkRegister => _page.FindElement(By.LinkText("Register"));
        public void ClickRegister() => lnkRegister.Click();

        public IWebElement txtLogin => _page.FindElement(By.Id("username"));
        public IWebElement txtFname => _page.FindElement(By.Id("firstName"));
        public IWebElement txtLnamee => _page.FindElement(By.Id("lastName"));
        public IWebElement txtPword => _page.FindElement(By.Id("password"));
        public IWebElement txtConfirmpass => _page.FindElement(By.Id("confirmPassword"));
        public IWebElement btnRegister => _page.FindElement(By.XPath("//button[text()='Register']"));
        public IWebElement RegisterSuccessMessage => _page.FindElement(By.XPath("//div[contains(text(),'Registration is successful')]"));
        public IWebElement ErrorUsername => _page.FindElement(By.XPath("//div[contains(text(),'UsernameExistsException: User already exists')]"));
        public IWebElement Errorpasssize => _page.FindElement(By.XPath("//div[contains(text(),'InvalidParameter: 1 validation error(s) found.')]"));
        public IWebElement Errorpasslength => _page.FindElement(By.XPath("//div[contains(text(),'InvalidPasswordException: Password did not conform with policy: Password not long enough')]"));
        public IWebElement Errorpassnolowcase => _page.FindElement(By.XPath("//div[contains(text(),'InvalidPasswordException: Password did not conform with policy: Password must have lowercase characters')]"));
        public IWebElement Errorpassnoupcase => _page.FindElement(By.XPath("//div[contains(text(),'InvalidPasswordException: Password did not conform with policy: Password must have uppercase characters')]"));
        public IWebElement Errorpasnosymbol => _page.FindElement(By.XPath("//div[contains(text(),'InvalidPasswordException: Password did not conform with policy: Password must have symbol characters')]"));
        public IWebElement Errorpassnonumeric => _page.FindElement(By.XPath("//div[contains(text(),'InvalidPasswordException: Password did not conform with policy: Password must have numeric characters')]"));
        public IWebElement Errorpassnotmatched => _page.FindElement(By.XPath("//div[contains(text(),'Passwords do not match')]"));

        public void ClickRegisterButton() => btnRegister.Submit();
        public bool IsRegisterSuccessMessageExist() => RegisterSuccessMessage.Displayed;
        public bool IsRgisterErrorUsernameExist() => ErrorUsername.Displayed;
        public bool IsRgisterErrorpasssizeExist() => Errorpasssize.Displayed;
        public bool IsRgisterErrorpasslengthExist() => Errorpasslength.Displayed;
        public bool IsRgisterErrorpasslowcaseExist() => Errorpassnolowcase.Displayed;
        public bool IsRgisterErrorpassupcaseExist() => Errorpassnoupcase.Displayed;
        public bool IsRgisterErrorpassymbolExist() => Errorpasnosymbol.Displayed;
        public bool IsRgisterErrorpassnumericExist() => Errorpassnonumeric.Displayed;
        public bool IsRgisterErrorpassnotmatchedExist() => Errorpassnotmatched.Displayed;

        public void Register(string userName, string firstName, string lastName, string password, string confimp)
        {
            txtLogin.SendKeys(userName);
            txtFname.SendKeys(firstName);
            txtLnamee.SendKeys(lastName);
            txtPword.SendKeys(password);
            txtConfirmpass.SendKeys(confimp);
        }


    }
}

