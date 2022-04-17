using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;

namespace Lab_AnnaP_home1
{
    public class BasicGoogleTest
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(@"../../../" + "/Drivers/");
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.google.com/ncr");
        }

        [Test]
        public void CheckForImagesOnQuery()
        {
            IWebElement query = _driver.FindElement(By.Name("q"));

            query.SendKeys("Dodge Journey");
            query.Submit();
            
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var first = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("h3")));
            
            Console.WriteLine(first.GetAttribute("textContent"));
            Assert.That(first.GetAttribute("textContent").Contains("Images"));

            Assert.IsTrue(_driver.FindElement(By.CssSelector("h3")).Displayed);
            ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile("Test.png", ScreenshotImageFormat.Png);

            _driver.Quit();
        }
    }
}