using System;
using System.Collections.Generic;
using System.Text;
using Automation.Utilities;
using OpenQA.Selenium;


namespace Automation.TestPages
{
   public class ShoppingCrartPage : BasePage
    {
        public string getSubTotalPrice()
        {
            var subTotal = Driver.FindElement(By.XPath(ShoppingCartElements.subTotalXpath)).Text;
            return subTotal;
        }

        public void agreeTerms()
        {
            Driver.FindElement(By.Id(ShoppingCartElements.termsCheckBoxId)).Click();
        }
        public void checkOut(string buttonName)
        {
            var buttonXpath = "//button[@value='" + buttonName + "']";
            Driver.FindElement(By.XPath(buttonXpath)).Click();
        }
    }
}