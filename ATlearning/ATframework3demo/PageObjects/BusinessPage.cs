using atFrameWork2.SeleniumFramework;

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
            return new StatisticPage();
        }

        internal BusinessPage LogOut()
        {
            var ExitButton = new WebItem("//a[@class='logout-btn-header-href']", "Выход из сервиса");
            ExitButton.Click();
            return new BusinessPage();
        }

        internal bool IsBusinessDeleted(string NewsTime)
        {
            var BusinessCheck = new WebItem($"//div[contains(text(), '{NewsTime}')]",
             "Проверка присутствия переменной в бизнесах");
            if 
            (
                BusinessCheck.AssertTextContains(NewsTime, "бизнес не найден", default)
            ) 
                {
                return false;
                }
            else 
            {
                return true;
            }
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
    }
}