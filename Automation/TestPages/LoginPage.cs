using System;
using System.Collections.Generic;
using System.Text;
using Automation.Utilities;
using OpenQA.Selenium;


namespace Automation.TestPages
{
   public class LoginPage : BasePage
    {       

        public void login(string username, string password)
        {
            EnterValuesInTextbox(TestConstants.Email,username);
            EnterValuesInTextbox(TestConstants.Password, password);
            clickOnButton(TestConstants.LoginButton);           
        }

        public string GetUserName()
        {
            return Driver.FindElement(By.XPath(LoginElements.userInfo)).Text;
        }

        public string GetCartQty()
        {
            return Driver.FindElement(By.XPath(LoginElements.cartQty)).Text;
        }

    }
}