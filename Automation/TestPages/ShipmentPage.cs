using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Automation.Common;
using Automation.Utilities;
using OpenQA.Selenium;


namespace Automation.TestPages
{
   public class ShipmentPage : BasePage
    {
        public void SetShippingValues()
        {
            var fullPath = Path.GetFullPath(@"..\..\..\");
            var path = Path.Combine(fullPath, "ShippingAddressDetails.xlsx");
            string[,] shippingAddressDetails = ReadTestDataFromExcel(path);
            var shippingDetails = new ShippingAddress();
            for (var row = 1; row < 2; row++)
            {   //// login details data object
                shippingDetails.billAddress = shippingAddressDetails[row, 0];
                shippingDetails.firstName = shippingAddressDetails[row, 1];
                shippingDetails.lastName = shippingAddressDetails[row, 2];
                shippingDetails.Email = shippingAddressDetails[row, 3];
                shippingDetails.country = shippingAddressDetails[row, 4];
                shippingDetails.city = shippingAddressDetails[row, 5];
                shippingDetails.zipPostalCode = shippingAddressDetails[row, 6];
                shippingDetails.address = shippingAddressDetails[row, 7];
                shippingDetails.phoneNumber = shippingAddressDetails[row, 8];
            }
            selectAddressDropdown(TestConstants.ShippingAddress, shippingDetails.billAddress);
            EnterValuesInTextbox(TestConstants.FirstName, shippingDetails.firstName);
            EnterValuesInTextbox(TestConstants.LastName, shippingDetails.lastName);
            EnterValuesInTextbox(TestConstants.Email, shippingDetails.Email);
            selectCountryDropdown(TestConstants.Country, shippingDetails.country,1);
            EnterValuesInTextbox(TestConstants.City, shippingDetails.city);
            EnterValuesInTextbox(TestConstants.Address, shippingDetails.address);
            EnterValuesInTextbox(TestConstants.ZipPostalCode, shippingDetails.zipPostalCode);
            EnterValuesInTextbox(TestConstants.PhoneNumber, shippingDetails.phoneNumber);
        }
        public string OrderSuccessMsg()
        {
            return Driver.FindElement(By.XPath(ShipmentElements.notificationMsgXpath)).Text.Trim();
        }

        public void nextDayAir()
        {
            Driver.FindElement(By.XPath(ShipmentElements.nextDdayAirXpath)).Click();
        }
        public string getOrderNumber()
        {
            var orderDetails = Driver.FindElement(By.XPath(ShipmentElements.orderNumberXpath)).Text.Trim();
            return orderDetails;
        }
        
        public string getConfirmationMsg()
        {
            var msg = Driver.FindElement(By.XPath(ShipmentElements.codConfirmationMsgXpath)).Text.Trim();
            return msg;
        }

    }
}