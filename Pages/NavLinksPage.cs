using OpenQA.Selenium;

namespace BCars.Pages
{
    class NavLinksPage
    {
        public IWebDriver _page { get; }
        public NavLinksPage(IWebDriver webDriver) => _page = webDriver;

        public IWebElement BuggyRatingLink => _page.FindElement(By.XPath("//a[@class='navbar-brand'][text()='Buggy Rating']"));

        public void NavigatetoHomepage() => BuggyRatingLink.Click();
    }
}
