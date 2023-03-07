using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;




namespace ExplicitWaitExample
{
    public class ExplicitWait
    {
        private IWebDriver driver;

        public ExplicitWait(IWebDriver driver)
        {
            this.driver = driver;
        }

        private string testUrl = "https://www.google.com/";
         

        [SetUp]
        public void Setup()
        {
            // Create a new ChromeDriver instance
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-web-security");

            // Navigate to Google.com
            driver.Navigate().GoToUrl(testUrl);
            driver.Manage().Window.Maximize();

        }


        [Test]
        public void TestSearch()
        {
            // Find the search box element and enter the search term
            IWebElement searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys("epam");

            // Submit the search query
            searchBox.Submit();

            // Wait for the search results to load
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement searchResults = wait.Until(ExpectedConditions.ElementExists(By.Id("search")));

            // Find the first search result and click on it
            IWebElement firstResult = driver.FindElement(By.CssSelector("#search a[href^='https://www.epam.com/']"));
            firstResult.Click();

            // Wait for the page to load
            wait.Until(ExpectedConditions.UrlContains("epam.com"));

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}

