using atFrameWork2.SeleniumFramework;

namespace atFrameWork2.PageObjects
{
    internal class BusinessPage
    {
        public BusinessPage()
        {
        }

        internal void AddBusiness()
        {
            var BusinessNameInput = new WebItem("//input[@name='business-name']", "Поле ввода названия бизнеса");
            BusinessNameInput.SendKeys("сделать пременную");
            var BusinessSubmit = new WebItem("//button[@name='submit']", "Кнопка создать бизнес");
            BusinessSubmit.Click();
        }
    }
}