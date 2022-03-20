using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace atFrameWork2.PageObjects
{
    public class PortalLeftMenu
    {
        public TasksListPage OpenTasks()
        {
            new WebItem("//li[@id='bx_left_menu_menu_tasks']", "Пункт левого меню 'Задачи'").Click();
            return new TasksListPage();
        }

        public static SiteListPage OpenSites()
        {
            new WebItem("//li[@id='bx_left_menu_menu_sites']", "Пункт левого меню 'Сайты'").Click();
            return new SiteListPage();
        }
<<<<<<< Updated upstream
=======

        internal PortalSettingsMainPage OpenSettings()
        {
            //Развернуть меню
            var btnMore = new WebItem("//span[@id='menu-more-btn-text']", "Кнопка еще левого меню");
            btnMore.Click();
            //клик в пункт меню настройки 
            var btnSettings = new WebItem("//li[@id='bx_left_menu_menu_configs_sect']", "Кнопка Настройки левого меню");
            btnSettings.Click();
              
            
            return new PortalSettingsMainPage();
        }

        internal NewsPage OpenNews()
        {
            //клик в пункт меню новости
            var btnNews = new WebItem("//span[@id='menu-counter-live-feed']", "кнопка Новости");
           //throw new NotImplementedException();
            return new NewsPage();
        }
>>>>>>> Stashed changes
    }
}
