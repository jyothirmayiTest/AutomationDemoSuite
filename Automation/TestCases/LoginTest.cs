using Automation.Common;
using Automation.TestPages;
using Automation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Automation.TestCases
{    
    public class LoginTest:Tests
    {
        [Test]
        public void Test1()
        {   
            //page declarations
            var loginPageObj = new LoginPage();
            var booksPageObj = new BooksPage();
            var billingPageObj = new BillingAdressPage();
            var shipmentPageObj = new ShipmentPage();
            var shoppingCartPageObj = new ShoppingCrartPage();
            //navigate to the browser and login
            loginPageObj.clickOnHyperLink(TestConstants.LoginHyperLink);

            //validate welcome msg
            var welcomeMsg = loginPageObj.getPageTtile();
            Assert.AreEqual(welcomeMsg, TestConstants.WelcomeMsg);
            
            //login details
            var fullPath = System.IO.Path.GetFullPath(@"..\..\..\");
            var path = Path.Combine(fullPath, "LoginExcel.xlsx");
            string[,] loginInfo = loginPageObj.ReadTestDataFromExcel(path);
            var loginDetails = new Login();
            for (var row = 1; row < 2; row++)
            {   // login details data object
                loginDetails = new Login();
                {
                    loginDetails.email = loginInfo[row, 0];
                    loginDetails.password = loginInfo[row, 1];
                }
            }
            loginPageObj.login(loginDetails.email, loginDetails.password);
           
            //validates user name
            var userNameInUI = loginPageObj.GetUserName();
            Assert.AreEqual(userNameInUI, loginDetails.email);
            //validates shopping cart qty
            var shoppingCartValue = loginPageObj.GetCartQty();
            var replaceQty = shoppingCartValue.Replace("(","");
            var shoppingCartQty = replaceQty.Replace(")", "");
            Assert.AreEqual(Convert.ToInt16(shoppingCartQty), 0);
            //navigates to books category
            loginPageObj.clickOnHyperLink(TestConstants.Books);
            //clicks on a book
            booksPageObj.ClickOnBookItem();
            //get the price
            var price = booksPageObj.GetPrice();            
            //Enter Qty
            booksPageObj.EnterQty(TestConstants.qty);
            //AddtoCart
            booksPageObj.clickOnButton(TestConstants.AddTocart, TestConstants.Productessential);
            var msg = booksPageObj.GetNotificationMsg().TrimStart();
            Assert.AreEqual(msg, TestConstants.AddedToCartSuccessMessage);
            //navigates to shopping cart
            booksPageObj.clickOnHyperLink(TestConstants.shoppingCart);
            var subTotal = Convert.ToDecimal(shoppingCartPageObj.getSubTotalPrice());
            var newQty = price * 2;
            //validating subtotal and price qty
            Assert.AreEqual(newQty, subTotal);
            //agrees terms of service
            shoppingCartPageObj.agreeTerms();
            //perform checkout
            shoppingCartPageObj.checkOut(TestConstants.Checkout);
            //set billing values
            billingPageObj.SetBillingValues();
            shipmentPageObj.clickOnButton(TestConstants.Continue, null, TestConstants.billingContinueId);
            //set shipping values
            shipmentPageObj.SetShippingValues();
            shipmentPageObj.clickOnButton(TestConstants.Continue, null, TestConstants.shippingContinueId);
            //select nextdayair
            //validate cod confirmaation message
            shipmentPageObj.nextDayAir();
            shipmentPageObj.clickOnButton(TestConstants.Continue, null, TestConstants.shippingMethodContinueId);
            shipmentPageObj.clickOnButton(TestConstants.Continue, null, TestConstants.paymentMethodId);
            var codMsg = shipmentPageObj.getConfirmationMsg();
            Assert.AreEqual(codMsg, TestConstants.CodConfirmationMsg);
            shipmentPageObj.clickOnButton(TestConstants.Continue, null, TestConstants.paymentInfoId);
            shipmentPageObj.clickOnButton(TestConstants.Confirm);
            //order success msg
            var orderMsg = shipmentPageObj.OrderSuccessMsg();
            Assert.AreEqual(orderMsg, TestConstants.OrderSuccessMsg);
            var orderDetails = shipmentPageObj.getOrderNumber();
            //print order details
            Console.WriteLine(orderDetails);
        }
    }
}
