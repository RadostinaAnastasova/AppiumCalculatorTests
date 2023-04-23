using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;

namespace AppiumCalculatorTests
{
    public class CalculatorTests
    {
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        // Startin Appium on IP v6
        //private const string appiumServer = "http://[::1]:4723/wd/hub";
        private const string appLocation = @"D:\ina_rd\QA\QA Authomation FrontEnd\00. Projects\04.Appium-Desktop-Testing-Resources\SummatorDesktopApp.exe";
        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions appiumOptions;
        private AppiumLocalService appiumLocalService;

        [SetUp]
        public void OpenApplication()
        {
            // Start using the Desktop Appium Server
            this.appiumOptions= new AppiumOptions() { PlatformName = "Windows"};
            appiumOptions.AddAdditionalCapability("app", appLocation);
            //appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, appLocation);
            appiumOptions.AddAdditionalCapability("PlatformName", "Windows");
            this.driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions);
            
            // Start Appium using headless mode
            //this.appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            //appiumLocalService.Start();
            //this.appiumOptions = new AppiumOptions();
            //appiumOptions.AddAdditionalCapability("app", appLocation);
            //appiumOptions.AddAdditionalCapability("PlatformName", "Windows");
            //this.driver = new WindowsDriver<WindowsElement>(appiumLocalService, appiumOptions);
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);  
        }

        [TearDown]
        public void CloseApplication()
        {
            //driver.CloseApp();
            driver.Quit();
            //appiumLocalService.Dispose();
        }

        [Test]
        public void Test_Sum_TwoPositiveNumburs()
        {
            // Arrange
            var firstField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var resultField = driver.FindElementByAccessibilityId("textBoxSum");
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");

            // Act
            // with OneTimeTearDown the fields have to be cleared
            //firstField.Clear();
            //secondField.Clear();
            firstField.SendKeys("5");
            secondField.SendKeys("15");
            calcButton.Click();

            // Assert
            Assert.That(resultField.Text, Is.EqualTo("20"));
        }

        [Test]
        public void Test_Sum_InvalidNumburs()
        {
            // Arrange
            var firstField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var resultField = driver.FindElementByAccessibilityId("textBoxSum");
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");

            // Act
            firstField.SendKeys("aaadd");
            secondField.SendKeys("15");
            calcButton.Click();

            // Assert
            Assert.That(resultField.Text, Is.EqualTo("error"));
        }

        [TestCase("5", "15", "20")]
        [TestCase("15", "15", "30")]
        [TestCase("5", "wwwww", "error")]
        public void Test_Sum_DDT(string firstValue, string SecondValue, string result)
        {
            // Arrange
            var firstField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var resultField = driver.FindElementByAccessibilityId("textBoxSum");
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");

            // Act
            firstField.SendKeys(firstValue);
            secondField.SendKeys(SecondValue);
            calcButton.Click();

            // Assert
            Assert.That(resultField.Text, Is.EqualTo(result));
        }
    }
}