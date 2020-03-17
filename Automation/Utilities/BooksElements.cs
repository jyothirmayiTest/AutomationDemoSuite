using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Utilities
{
    public static class BooksElements
    {
        public const string bookItemXpath = "//div[@class='product-grid']//following::img";
        public const string priceXpath = "//div[@class='product-price']/span";
        public const string qtyXpath = "//div[@class='add-to-cart']//input[@class='qty-input']";
        public const string NotificationMsgXpath = "//div[@class='bar-notification success']";
    }
}
