using OpenQA.Selenium;

namespace BCars.Pages
{
    class ProfilePage
    {
        public IWebDriver _page { get; }
        public ProfilePage(IWebDriver webDriver) => _page = webDriver;

        public IWebElement txtFname => _page.FindElement(By.Id("firstName"));
        public IWebElement txtLname => _page.FindElement(By.Id("lastName"));
        public IWebElement txtGender => _page.FindElement(By.Id("gender"));
        public IWebElement txtAge => _page.FindElement(By.Id("age"));
        public IWebElement txtAddress => _page.FindElement(By.Id("address"));
        public IWebElement txtPhone => _page.FindElement(By.Id("phone"));
        public IWebElement txtHobby => _page.FindElement(By.Id("hobby"));
        public IWebElement txtCurPass => _page.FindElement(By.Id("currentPassword"));
        public IWebElement txtNewPass => _page.FindElement(By.Id("newPassword"));
        public IWebElement txtConPass => _page.FindElement(By.Id("newPasswordConfirmation"));
        public IWebElement btnSave => _page.FindElement(By.XPath("//button[text()='Save']"));
        public IWebElement lnkCancel => _page.FindElement(By.XPath("//button[text()='Cancel']"));
        public IWebElement UpdateProfileSuccessMessage => _page.FindElement(By.XPath("//div[contains(text(),'The profile has been saved successful')]"));
        public IWebElement ErrorAgeFormat => _page.FindElement(By.XPath("//div[contains(text(),'Unknown error')]"));
        public IWebElement ErrorAgeRange => _page.FindElement(By.XPath("//div[contains(text(),'Age must be in the range from 0 to 95')]"));
        public IWebElement ErrorAgeSpecialChar => _page.FindElement(By.XPath("//div[contains(text(),'Get a candy ;)]"));
        public IWebElement Errorpasssize => _page.FindElement(By.XPath("//div[contains(text(),'InvalidParameter: 1 validation error(s) found.')]"));
        public IWebElement Errorpasslength => _page.FindElement(By.XPath("//div[contains(text(),'InvalidPasswordException: Password did not conform with policy: Password not long enough')]"));
        public IWebElement Errorpassnolowcase => _page.FindElement(By.XPath("//div[contains(text(),'InvalidPasswordException: Password did not conform with policy: Password must have lowercase characters')]"));
        public IWebElement Errorpassnoupcase => _page.FindElement(By.XPath("//div[contains(text(),'InvalidPasswordException: Password did not conform with policy: Password must have uppercase characters')]"));
        public IWebElement Errorpasnosymbol => _page.FindElement(By.XPath("//div[contains(text(),'InvalidPasswordException: Password did not conform with policy: Password must have symbol characters')]"));
        public IWebElement Errorpassnonumeric => _page.FindElement(By.XPath("//div[contains(text(),'InvalidPasswordException: Password did not conform with policy: Password must have numeric characters')]"));
        public IWebElement Errorpassnotmatched => _page.FindElement(By.XPath("//div[contains(text(),'Passwords do not match')]"));


        public void valFname(string valfname)
        {
            txtFname.GetAttribute(valfname);
        }

        public bool IsUpdateProfileSuccessMessageExist() => UpdateProfileSuccessMessage.Displayed;
        public bool IsErrorAgeFormatExist() => ErrorAgeFormat.Displayed;
        public bool IsErroAgeRangeExist() => ErrorAgeRange.Displayed;
        public bool IsErroAgeSpecialCharExist() => ErrorAgeSpecialChar.Displayed;

        public void SaveChanges() => btnSave.Submit();
        public void CancelChanges() => lnkCancel.Click();
        public void ClearFirstName() => txtFname.Clear();
        public void ClearLasttName() => txtLname.Clear();
        public void ClearGender() => txtGender.Clear();
        public void ClearAge() => txtAge.Clear();
        public void ClearAddress() => txtAddress.Clear();
        public void ClearPhone() => txtPhone.Clear();
        public void ClearHobby() => txtHobby.Clear();

        public bool IsRgisterErrorpasssizeExist() => Errorpasssize.Displayed;
        public bool IsRgisterErrorpasslengthExist() => Errorpasslength.Displayed;
        public bool IsRgisterErrorpasslowcaseExist() => Errorpassnolowcase.Displayed;
        public bool IsRgisterErrorpassupcaseExist() => Errorpassnoupcase.Displayed;
        public bool IsRgisterErrorpassymbolExist() => Errorpasnosymbol.Displayed;
        public bool IsRgisterErrorpassnumericExist() => Errorpassnonumeric.Displayed;
        public bool IsRgisterErrorpassnotmatchedExist() => Errorpassnotmatched.Displayed;



        public void Fname(string fname)
        {
            txtFname.SendKeys(fname);
        }

        public void Lname(string lname)
        {
            txtLname.SendKeys(lname);
        }

        public void Gender(string gender)
        {
            txtGender.SendKeys(gender);
        }

        public void Age(string age)
        {
            txtAge.SendKeys(age);
        }

        public void Address(string address)
        {
            txtAddress.SendKeys(address);
        }

        public void Phone(string phone)
        {
            txtPhone.SendKeys(phone);
        }

        public void Hobby(string hobby)
        {
            txtHobby.SendKeys(hobby);
        }

        public void Pass(string cpass, string npass, string conpass)
        {
            txtCurPass.SendKeys(cpass);
            txtNewPass.SendKeys(npass);
            txtConPass.SendKeys(conpass);
        }
    }
}
