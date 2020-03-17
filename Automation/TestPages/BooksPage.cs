using System;
using System.Collections.Generic;
using System.Text;
using Automation.Utilities;
using OpenQA.Selenium;


namespace Automation.TestPages
{
    public class BooksPage : BasePage
    {
     public void ClickOnBookItem()
        {
            WaitForReady();
            Driver.FindElement(By.XPath(BooksElements.bookItemXpath)).Click();
        }
        public decimal GetPrice()
        {
            WaitForReady();
            var priceText = Driver.FindElement(By.XPath(BooksElements.priceXpath)).Text;
            var price = Convert.ToDecimal(priceText);
                return price;
        }

        public void EnterQty(string qty)
        {
            WaitForReady();
            Driver.FindElement(By.XPath(BooksElements.qtyXpath)).Clear();
            Driver.FindElement(By.XPath(BooksElements.qtyXpath)).SendKeys(qty);
        }

        public string GetNotificationMsg()
        {
            var msg = Driver.FindElement(By.XPath(BooksElements.NotificationMsgXpath)).Text;
            return msg;
        }
    }
}