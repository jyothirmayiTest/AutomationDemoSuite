using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Utilities
{
    public static class ShipmentElements
    {
        public const string notificationMsgXpath = "//div[@class='title']/strong";
        public const string orderNumberXpath = "//ul[@class='details']/li";
        public const string codConfirmationMsgXpath = "//div[@class='section payment-info']//td/p";
        public const string nextDdayAirXpath = "//div[@class='method-name']//input[@value='Next Day Air___Shipping.FixedRate']";
    }
}
