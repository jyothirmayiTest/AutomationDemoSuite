using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;


namespace Automation.TestPages
{
    public abstract class BasePage
    {

        private static IWebDriver driver;

        public static IWebDriver Driver { get => driver; set => driver = value; }
        public  void EnterValuesInTextbox(string fieldName, string value)
        {
            WaitForReady();
            try
            {
                var xpath = "(//label[text()='" + fieldName + "']/following-sibling::input)[last()]";
                Driver.FindElement(By.XPath(xpath)).Clear();
                Driver.FindElement(By.XPath(xpath)).SendKeys(value);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
        private static Excel.Application myExcelApplication;

        public string[,] ReadTestDataFromExcel(string path, string sheetName = "Sheet1")
        {
            myExcelApplication = new Excel.Application();
            try
            {
                Excel.Workbook myExcelWorkbook = myExcelApplication.Workbooks.Open(path, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Excel.Worksheet myExcelWorkSheet = (Excel.Worksheet)myExcelWorkbook.Sheets[sheetName];
                Excel.Range excelRange = myExcelWorkSheet.UsedRange;
                int rowCount = excelRange.Rows.Count;
                int colCount = excelRange.Columns.Count;
                string[,] testData = new string[rowCount, colCount];
                for (int i = 1; i <= rowCount; i++)
                {
                    for (int j = 1; j <= colCount; j++)
                    {
                        Excel.Range range = myExcelWorkSheet.Cells[i, j] as Excel.Range;
                        testData[i - 1, j - 1] = range.Value2 == null ? "" : range.Value2.ToString();
                    }
                }
                myExcelWorkbook.Close();
                myExcelApplication.Quit();
                return testData;
            }
            catch (Exception ex)
            {
                if (myExcelApplication != null)
                {
                    myExcelApplication.Quit(); // close the excel application
                }
                throw;
            }
        }

        public void WaitForReady()
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
        }

        public void clickOnHyperLink(string linkText)
        {
            WaitForReady();
            Driver.FindElement(By.LinkText(linkText)).Click();
        }

        public void clickOnButton(string buttonName, string xpath = null, string id=null)
        {
            WaitForReady();
            var buttonXpath = string.Empty;
            if (xpath != null)
            {
                buttonXpath = "//div[@class='"+xpath+"']//input[@value='" + buttonName + "']";
            }
            else
            {
                if (id != null)
                {
                    buttonXpath = "//div[@id='" + id + "']//input[@value='" + buttonName + "']";
                }
                else
                {
                    buttonXpath = "//input[@value='" + buttonName + "']";
                }
            }
            Driver.FindElement(By.XPath(buttonXpath)).Click();
        }

        public void selectAddressDropdown(string dropdownName, string value)
        {
            WaitForReady();
            var identy = "//label[text()='" + dropdownName + "']/following-sibling::div/select";
            var dropdownElement = Driver.FindElement(By.XPath(identy));
            SelectElement dropdownSelect = new SelectElement(dropdownElement);
            dropdownSelect.SelectByText(value);
        }
        public void selectCountryDropdown(string dropdownName, string value, int row)
        {
            WaitForReady();
            var identy = "//label[text()='" + dropdownName + "']/following-sibling::select";
            var dropdownElement = Driver.FindElements(By.XPath(identy))[row];
            SelectElement dropdownSelect = new SelectElement(dropdownElement);
            dropdownSelect.SelectByText(value);
        }

        public string getPageTtile()
        {
            WaitForReady();
            var pageTitle = Driver.FindElement(By.XPath("//div[@class='page-title']")).Text;
            return pageTitle;
        }

    }
}
