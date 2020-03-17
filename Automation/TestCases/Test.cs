using Automation.TestPages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;

namespace Automation
{
    public class Tests
    {
        [SetUp]
        public void startBrowser()
        {
            // PropertiesCollections.Driver = new ChromeDriver();
            BasePage.Driver = (IWebDriver)new InternetExplorerDriver
                                    (
                                        @"C:\Users\Public\Documents",
                                        new InternetExplorerOptions()
                                        {
                                            IntroduceInstabilityByIgnoringProtectedModeSettings = true
                                            ,
                                            InitialBrowserUrl = "about:blank",
                                            RequireWindowFocus = true
                                            ,
                                            EnablePersistentHover = false,
                                            EnsureCleanSession = true
                                        },
                                        TimeSpan.FromSeconds(200)
                                    );
            BasePage.Driver.Navigate().GoToUrl("http://demowebshop.tricentis.com/");
        }

        [TearDown]
        public void closeBrowser()
        {
            BasePage.Driver.Close();
        }



    }
}