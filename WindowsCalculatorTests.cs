using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using System.Text.RegularExpressions;

namespace AppiumCalculatorTests
{
    public class WindowsCalculatorTests
    {
        private const string appiumServer = "http://[::1]:4723/wd/hub";
        //private const string appLocation = @"C:\Windows\System32\calc.exe";
        private const string appLocation = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";
        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions appiumOptions;
        //private AppiumLocalService appiumLocalService;

        [SetUp]
        public void OpenApplication()
        {
            this.appiumOptions= new AppiumOptions() { PlatformName = "Windows"};
            appiumOptions.AddAdditionalCapability("app", appLocation);
            //appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, appLocation);
            appiumOptions.AddAdditionalCapability("PlatformName", "Windows");
            this.driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions);
        }

        [TearDown]
        public void CloseApplication()
        {
            driver.CloseApp();
            driver.Quit();
        }

        [Test]
        public void Test_Sum_TwoPositiveNumburs()
        {
            // Arrange
            var buttonOne = driver.FindElementByAccessibilityId("num1Button");
            var buttonTwo = driver.FindElementByAccessibilityId("num2Button");
            var buttonPlus = driver.FindElementByAccessibilityId("plusButton");
            var buttonEqual = driver.FindElementByAccessibilityId("equalButton");
            var resultField = driver.FindElementByAccessibilityId("CalculatorResults");
            
            // Act
            buttonOne.Click();
            buttonPlus.Click();
            buttonTwo.Click();
            buttonEqual.Click();

            // Assert
            //Assert.That(resultField.Text, Is.EqualTo("Display is 3"));

            var result = resultField.Text;
            var resultValue = Regex.Match(result, @"\d+").Value;

            Assert.That(resultValue, Is.EqualTo("3"));
        }        
    }
}