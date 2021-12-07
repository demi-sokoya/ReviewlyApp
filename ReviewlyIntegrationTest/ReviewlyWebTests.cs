using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace ReviewlyIntegrationTest
{
    [TestClass]
    public class ReviewlyWebTests
    {
        IWebDriver _driver;

        [TestInitialize]
        public void Startup()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            _driver = new EdgeDriver();
        }

        [TestMethod]
        public void TestThatTheWebsiteSavesTitle()
        {
            
        }

        public void TestThatTheWebsiteSavesYear()
        {

        }

        public void TestThatTheWebsiteSavesRating()
        {

        }

        public void TestThatTheWebsiteSavesGenre()
        {

        }

        [TestCleanup]
        public void Shutdown()
        {
            _driver.Quit();
        }
    }
}
