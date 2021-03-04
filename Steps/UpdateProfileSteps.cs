using BCars.Pages;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace BCars.Steps
{
    [Binding]
    public sealed class UpdateProfileSteps
    {
        private DriverHelper _driverHelper;
        public UpdateProfileSteps(DriverHelper driverHelper) => _driverHelper = driverHelper;
        ProfilePage profilePage = null;
        public string pword = null;
        public string currentpass = null;
        public string name = null;
        public string sname = null;
        public string gender = null;
        public string age = null;
        public string address = null;
        public string phone = null;
        public string hobby = null;

        [When(@"I navigate to Profile")]
        public void WhenINavigateToProfile()
        {
            profilePage = new ProfilePage(_driverHelper.Driver);
            LoginPage loginPage = new LoginPage(_driverHelper.Driver);
            Thread.Sleep(1000);
            loginPage.ClickProfileLink();
            Thread.Sleep(2000);
        }

        [When(@"I update my details")]
        public void WhenIUpdateMyDetails(Table table)
        {
            name = table.Rows.First()["Name"].ToString();
            sname = table.Rows.First()["Surname"].ToString();
            gender = table.Rows.First()["Gender"].ToString();
            age = table.Rows.First()["Age"].ToString();
            address = table.Rows.First()["Address"].ToString();
            phone = table.Rows.First()["Phone"].ToString();
            hobby = table.Rows.First()["Hobby"].ToString();
            var cpass = table.Rows.First()["Cpass"].ToString();
            var npass = table.Rows.First()["Npass"].ToString();
            var conpass = table.Rows.First()["Conpass"].ToString();

            if (name != null)
            {
                profilePage.ClearFirstName();
                profilePage.Fname(name);

                if (sname != null)
                {
                    profilePage.ClearLasttName();
                    profilePage.Lname(sname);

                    if (gender != null)
                    {
                        profilePage.ClearGender();
                        profilePage.Gender(gender);

                        if (age != null)
                        {
                            profilePage.ClearAge();
                            profilePage.Age(age);

                            if (address != null)
                            {
                                profilePage.ClearAddress();
                                profilePage.Address(address);

                                if (phone != null)
                                {
                                    profilePage.ClearPhone();
                                    profilePage.Phone(phone);

                                    if (hobby != null)
                                    {
                                        profilePage.Hobby(hobby);

                                        if (cpass != null)
                                        {
                                            profilePage.Pass(cpass, npass, conpass);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        [When(@"I click the Save button")]
        public void WhenIClickTheSaveButton()
        {

            Thread.Sleep(2000);
            profilePage.SaveChanges();
            Thread.Sleep(2000);
        }

        [Then(@"I should see my details successfully updated")]
        public void ThenIShouldSeeMyDetailsSuccessfullyUpdated()
        {
            Assert.AreEqual(name, profilePage.txtFname.GetAttribute("value"));
            Assert.AreEqual(sname, profilePage.txtLname.GetAttribute("value"));
            Assert.AreEqual(gender, profilePage.txtGender.GetAttribute("value"));
            Assert.AreEqual(age, profilePage.txtAge.GetAttribute("value"));
            Assert.AreEqual(address, profilePage.txtAddress.GetAttribute("value"));
            Assert.AreEqual(phone, profilePage.txtPhone.GetAttribute("value"));
            Assert.AreEqual(hobby, profilePage.txtHobby.GetAttribute("value"));
        }
        [Then(@"I should see Incorrect Range Error Message")]
        public void ThenIShouldSeeIncorrectRangeErrorMessage()
        {
            Thread.Sleep(2000);
            Assert.That(profilePage.IsErroAgeRangeExist(), Is.True);
        }

        [Then(@"I should see Incorrect Age format Error Message")]
        public void ThenIShouldSeeIncorrectAgeFormatErrorMessage()
        {
            Thread.Sleep(2000);
            Assert.That(profilePage.IsErrorAgeFormatExist(), Is.True);
        }

    }
}
