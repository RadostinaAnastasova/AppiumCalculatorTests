using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace AppiumCalculatorTests
{
    public class CalculatorTests
    {
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = @"C:\\R\\QA\\QA Automation FrontEnd\\04.Appium-Desktop-Testing-Resources\\SummatorDesktopApp.exe";
        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions appiumOptions;

        [SetUp]
        public void OpenApplication()
        {
            this.appiumOptions= new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", appLocation);
            appiumOptions.AddAdditionalCapability("PlatformName", "Windows");
            this.driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions);
        }

        [TearDown]
        public void CloseApplication()
        {
            this.driver.Quit();
            //driver.Quit();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}