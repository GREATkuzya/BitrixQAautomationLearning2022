using atFrameWork2.SeleniumFramework;

namespace atFrameWork2.PageObjects
{
    internal class BusinessPage
    {
        public BusinessPage()
        {
        }

        internal BusinessPage AddBusiness()
        {
            var BusinessNameInput = new WebItem("//input[@name='business-name']", "Поле ввода названия бизнеса");
            BusinessNameInput.SendKeys("тестовый бизнес");
            var BusinessSubmit = new WebItem("//button[@name='submit']", "Кнопка создать бизнес");
            BusinessSubmit.Click();
            return new BusinessPage();
        }
    }
}