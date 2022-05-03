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

        internal bool IsBusinessAdded(string NewsTime)
        {
            var BusinessCheck = new WebItem($"//div[contains(text(), '{NewsTime}')]",
               "Проверка присутствия переменной в бизнесах");
            return BusinessCheck.AssertTextContains(NewsTime, "бизнес не найдена", default);
        }
    }
}