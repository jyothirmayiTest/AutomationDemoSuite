using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Automation.Common;
using Automation.Utilities;
using OpenQA.Selenium;


namespace Automation.TestPages
{
   public class BillingAdressPage : BasePage
    {

        public void SetBillingValues()
        {
            var fullPath = Path.GetFullPath(@"..\..\..\");
            var path = Path.Combine(fullPath, "BillingAddressDetails.xlsx");
            string[,] billingAddressDetails = ReadTestDataFromExcel(path);
            var billingDetails = new BillingAddress();
            for (var row = 1; row < 2; row++)
            {   //// login details data object
                    billingDetails.billAddress = billingAddressDetails[row, 0];
                    billingDetails.firstName = billingAddressDetails[row, 1];
                    billingDetails.lastName = billingAddressDetails[row, 2];
                    billingDetails.Email = billingAddressDetails[row, 3];
                    billingDetails.country = billingAddressDetails[row, 4];
                    billingDetails.city = billingAddressDetails[row, 5];
                    billingDetails.zipPostalCode = billingAddressDetails[row, 6];
                    billingDetails.address = billingAddressDetails[row, 7];
                    billingDetails.phoneNumber = billingAddressDetails[row, 8];
                }
            selectAddressDropdown(TestConstants.BillingAddress, billingDetails.billAddress);
            EnterValuesInTextbox(TestConstants.FirstName, billingDetails.firstName);
            EnterValuesInTextbox(TestConstants.LastName, billingDetails.lastName);
            EnterValuesInTextbox(TestConstants.Email, billingDetails.Email);
            selectCountryDropdown(TestConstants.Country, billingDetails.country,0);
            EnterValuesInTextbox(TestConstants.City, billingDetails.city);
            EnterValuesInTextbox(TestConstants.Address, billingDetails.address);
            EnterValuesInTextbox(TestConstants.ZipPostalCode, billingDetails.zipPostalCode);
            EnterValuesInTextbox(TestConstants.PhoneNumber, billingDetails.phoneNumber);
        }
    }
}