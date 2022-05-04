using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace atFrameWork2.PageObjects
{
    internal class BusinessPage
    {
        public BusinessPage()
        {
        }

        internal BusinessPage AddBusiness(string NewsTime)
        {
            var BusinessNameInput = new WebItem("//input[@name='business-name']", "Поле ввода названия бизнеса");
            BusinessNameInput.SendKeys(NewsTime);
            var BusinessSubmit = new WebItem("//button[@name='submit']", "Кнопка создать бизнес");
            BusinessSubmit.Click();
            return new BusinessPage();
        }

        internal BusinessPage ChooseBusiness(string businessName)
        {
            var ChosenOneBus = new WebItem($"//div[contains(text(), '{businessName}')]/..//*[contains(text(), 'Открыть')]", "Выбор заданного бизнеса");
            ChosenOneBus.Click();
            return new BusinessPage();
        }

        internal BusinessPage LinkAdd(string linkName, string linkAdress)
        {
            var LinkTagInput = new WebItem("//input[@name='tag']", "Поле ввода тэга ссылки");
            var LinkUrlInput = new WebItem("//input[@name='url']", "Поле ввода тэга ссылки");
            var LinkShortInput = new WebItem("//input[@name='short_path']", "Поле ввода тэга ссылки");
            var LinkSubmit = new WebItem("//input[@name='submit']", "Создание короткой ссылки");
            LinkTagInput.SendKeys(linkName);
            LinkUrlInput.SendKeys(linkAdress);
            LinkSubmit.Click();
            return new BusinessPage();


        }

        internal BusinessPage DeleteLink(string linkName)
        {
            var LinkCross = new WebItem($"//div[contains(text(), '{linkName}')]/..//*[@type='submit']", "Кнопка удаления ссылки");
            LinkCross.Click();
            LinkCross.WaitWhileElementDisplayed();
            return new BusinessPage();

        }

        internal bool IsLinkAdded(string linkName)
        {
            var LinkCheck = new WebItem($"//div[contains(text(), '{linkName}')]", "Проверка присутствия ссылки");
            if (!LinkCheck.WaitElementDisplayed())
                Log.Error("Ссылка не существует");

            return LinkCheck.AssertTextContains(linkName, "Ссылка не найдена", default);
        }

        internal BusinessPage GetWatchNum(string linkAdress)
        {
            var LinkWatchNum = new WebItem($"(//a[text() = '{linkAdress}']/../../../..//td[@class='main-grid-cell main-grid-cell-left']/div/span)[2]", "Количество просмотров сайта");
            string WatchNum = LinkWatchNum.InnerText();
            Log.Info($"{WatchNum}");
            return new StatisticPage();
        }

        internal BusinessPage GetMark()
        {
            var MarkText = new WebItem("//div[@class='section-content']/pre", "Метка для вставки на страницу");
            MarkText.WaitElementDisplayed();
            //var MarkTextHtml = MarkText.InnerText().ToString();
            string MarkTextHtml = MarkText.GetAttribute("innerText");
            Log.Info($"{MarkTextHtml}");
            return new BusinessPage();
        }

        internal BusinessPage GoToMarkPage()
        {
            var MarkPage = new WebItem("//li/a[text() = 'Генерация меток']", "Переход на страницу генерации меток");
            MarkPage.Click();
            Thread.Sleep(3000);
            return new BusinessPage();
        }

        internal BusinessPage GetLinkStatistic(string linkName)
        {
            var AllLinkRedirects = new WebItem($"(//a[text() = '{linkName}']/../../../..//td[@class='main-grid-cell main-grid-cell-left']/div/span)[2]", "Количество переходов по ссылке всего");
         string RedirectsNum =  AllLinkRedirects.InnerText();
            Log.Info($"{RedirectsNum}");
            return new StatisticPage();
        }

        internal BusinessPage GoToLinksStatistic()
        {
            var StatisticLinks = new WebItem("//li/a[text() = 'Статистика переходов']", "Переход на страницу статистики перехода по ссылкам");
            StatisticLinks.Click();
            return new StatisticPage();
        }

        internal BusinessPage GoToLinks()
        {
            var ChoseLinks = new WebItem("//a[text() = 'Генерация ссылок']", "Переход на страницу создания и удаления коротких ссылок ссылок");
            ChoseLinks.Click();
            return new StatisticPage();
        }


        internal BusinessPage GoToVisitStatistic()
        {
            var ChoseLinks = new WebItem("//a[text() = 'Статистика посещений']", "Переход на страницу статистики посещений");
            ChoseLinks.Click();
            return new StatisticPage();
        }



        internal BusinessPage LogOut()
        {
            var ExitButton = new WebItem("//a[@class='logout-btn-header-href']", "Выход из сервиса");
            ExitButton.Click();
            ExitButton.WaitWhileElementDisplayed();
            return new BusinessPage();
        }

        internal bool IsBusinessDeleted(string NewsTime)
        { 
              var BusinessCheck = new WebItem($"//div[contains(text(), '{NewsTime}')]", "Проверка присутствия переменной в бизнесах");
            if
                (
                BusinessCheck.WaitElementDisplayed()
                ) 
            {
                Log.Error("Бизнес существует, хотя лолжен быть удален");
                return false;
            }
         else 
            {
                return true;
            }
          //return  BusinessCheck.AssertTextContains(NewsTime, "бизнес не найден", default);
           
        }



        internal bool IsBusinessAdded(string NewsTime)
        {
            var BusinessCheck = new WebItem($"//div[contains(text(), '{NewsTime}')]",
               "Проверка присутствия переменной в бизнесах");
            return BusinessCheck.AssertTextContains(NewsTime, "бизнес не найден", default);
        }

       
        internal StatisticPage ChoseUnics()
            {
                var ChoseUnicsFilter = new WebItem("//label[@class='checkbox-ios']", "Выбор фильтра уникальные");
                ChoseUnicsFilter.Click();
                return new StatisticPage();
            }

        internal StatisticPage ChoseLink(string LinkAdress)
        {
            var ChoseOneLink = new WebItem($"//*[text() = '{LinkAdress}']", "");
            ChoseOneLink.Click();
            return new StatisticPage();

        }

        internal BusinessPage DeleteBusiness(string NewsTime)
        {
            var DelCross = new WebItem($"//div[contains(text(), '{NewsTime}')]/..//*[@type='submit']","Крестик удаления бизнеса");
            DelCross.Click();
            var DelAgree = new WebItem("//button[@class='ui-btn ui-btn-success']/span[text() = 'Подтвердить']", "Кнопка подтвердить");
            DelAgree.WaitWhileElementDisplayed();
            DelAgree.Click();
            return new BusinessPage();
        }

        internal BusinessPage GoToMarkedLink(string MarkLink)
        {
            WebDriver driver = new ChromeDriver();
            driver.Url = MarkLink;
            Thread.Sleep(3000);
            return new BusinessPage();
        }

    }
}