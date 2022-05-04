using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace atFrameWork2.PageObjects
{
    public class PortalHomePage
    {
        //public PortalLeftMenu LeftMenu => new PortalLeftMenu();

        internal BusinessPage GoToBusiness()
        {
            //переход к бизнесу пользователя
            var BusinessPageLogo = new WebItem("//img[@class='logo']", "Переход на страницу бизнесов пользователя");
            BusinessPageLogo.Click();
                return new BusinessPage();
        }
    }
}
