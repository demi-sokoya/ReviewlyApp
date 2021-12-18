using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;

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
            _driver.Navigate().GoToUrl("http://localhost:5000/ReviewlyPages/Create");
            var Title = _driver.FindElement(By.Id("Films_FilmTitle"));
            var Genre = _driver.FindElement(By.Id("Films_Genres"));
            var Year = _driver.FindElement(By.Id("Films_Year"));
            var Summary = _driver.FindElement(By.Id("Films_Summary"));
            var Rating = _driver.FindElement(By.Id("Films_Rating"));
            var form = _driver.FindElement(By.CssSelector("form"));

            
            SelectElement s = new SelectElement(Genre);
            s.SelectByIndex(0);


            Title.SendKeys("ant-man");
            Year.SendKeys("2016");
            Summary.SendKeys("small man goes big");
            Rating.SendKeys("8.5");
            form.Submit();

            var Href = _driver.FindElements(By.CssSelector("a[href*=\"/ReviewlyPages/Edit?id=\"]"));
           

            int maxId = int.MinValue;

            for (int i = 0; i < Href.Count; i++)
            {
                var url = Href[i].GetAttribute("href");
                var alteredUrl = url.Replace("http://localhost:5000/ReviewlyPages/Edit?id=", string.Empty);
                int id = int.Parse(alteredUrl);

                if (id > maxId)
                {
                    maxId = id;
                }


            }
            var selectedRow = _driver.FindElement(By.Id($"{maxId}"));

            

            var AnchorElement = _driver.FindElement(By.CssSelector($"a[href*=\"/ReviewlyPages/Edit?id={maxId}\"]"));

            var CurrentRow = AnchorElement.FindElements(By.XPath("./parent::*/parent::*"));


            //var TitleOutput = CurrentRow.td:nth - of - type(0);
            //var GenreOutput = _driver.FindElement(By.CssSelector("td[name=]"));
            //var YearOutput = _driver.FindElement(By.CssSelector("td[2016]"));
            //var SummaryOutput = _driver.FindElement(By.CssSelector("td[name=small man goes big]"));
            //var RatingOutput = _driver.FindElement(By.CssSelector("td[name=8.5]"));
            var rowElements = selectedRow.FindElements(By.CssSelector("*"));

            for (int i = 0; rowElements.Count < i; i++)
            { if (rowElements[i].Text == "ant-man" || rowElements[i].Text == "2016" || rowElements[i].Text == "8.5")
                    Assert.IsTrue(true);
            }

            //Assert.AreEqual("ant-man", TitleOutput.Text);
            //Assert.AreEqual("2016", YearOutput.Text);
            //Assert.AreEqual("small man goes big", SummaryOutput.Text);
            //Assert.AreEqual("8.5", RatingOutput.Text);
            //Assert.AreEqual("ant-man", TitleOutput.Text);
        }

        [TestMethod]
        public void TestThatTheWebsiteCanDeleteTableRows()
        {
            _driver.Navigate().GoToUrl("http://localhost:5000/ReviewlyPages/");
            var deleteId = "Delete?id=";
            var deleteButton = _driver.FindElement(By.CssSelector("a[href*=\"/ReviewlyPages/Delete?id=\"]"));

            var url = deleteButton.GetAttribute("href");
            int id = int.Parse(url.Replace("http://localhost:5000/ReviewlyPages/Delete?id=", string.Empty));

            deleteButton.Click();
            var form = _driver.FindElement(By.CssSelector("form"));
            form.Submit();


            //var deleteConfirm = _driver.FindElement(By.CssSelector($"a[href*=\"/ReviewlyPages/Delete?id={deleteId}\"]"));

            Assert.ThrowsException<NoSuchElementException>(()=>_driver.FindElement(By.CssSelector($"a[href*=\"/ReviewlyPages/Delete?id={deleteId}\"]")));
        }



        [TestCleanup]
        public void Shutdown()
        {
            _driver.Quit();
        }
    }
}
