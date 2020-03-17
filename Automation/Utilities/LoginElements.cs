using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Utilities
{
    public static class LoginElements
    {
        public const string userInfo = "//div[@class='header-links']//a[@href='/customer/info']";
        public const string  cartQty = "//div[@class='header-links']//following::a/span[@class='cart-qty']";
    }
}
