using OpenQA.Selenium;


namespace BCars.Pages
{
    class VotePage
    {
        public IWebDriver _page { get; }
        public VotePage(IWebDriver webDriver) => _page = webDriver;

        public IWebElement lnkModel => _page.FindElement(By.XPath("//a[contains(@href,'/model/')]"));
        public IWebElement ModelName => _page.FindElement(By.LinkText("Veneno"));
        public IWebElement lnkMakeLink => _page.FindElement(By.XPath("//a[contains(@href,'/make/')]"));
        public IWebElement lnkOverall => _page.FindElement(By.XPath("//a[contains(@href,'/overall')]"));
        public IWebElement btnVote => _page.FindElement(By.XPath("//button[text()='Vote!']"));
        public IWebElement lnkBuggyRating => _page.FindElement(By.XPath("//a[@class='navbar-brand'][text()='Buggy Rating']"));
        public IWebElement txtComment => _page.FindElement(By.Id("comment"));
        public IWebElement VoteSuccessMessage => _page.FindElement(By.XPath("//p[contains(text(),'Thank you for your vote!')]"));
        public IWebElement CannotVote => _page.FindElement(By.XPath("//p[contains(text(), 'You need to be logged in to vote.')]"));

        public void ClickVote() => btnVote.Click();
        public void PopularModelLink() => lnkModel.Click();
        public void PopularModelName() => ModelName.Click();
        public void PopularMakeLink() => lnkMakeLink.Click();
        public void OverallRatinglLink() => lnkOverall.Click();
        public void BuggyRatingLink() => lnkBuggyRating.Click();

        public bool IsVoteSuccessMessageExist() => VoteSuccessMessage.Displayed;
        public bool IsLoginToVoteMessageExist() => CannotVote.Displayed;
        public bool IsVoteButtonExist() => btnVote.Displayed;

        public void Vote(string comment)
        {
            txtComment.SendKeys(comment);
        }
    }
}