using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    /// <summary>
    /// Форма добавления нового сообщения в новости
    /// </summary>
    public class NewsPostForm
    {
        internal bool IsRecipientPresent(string recipientName)
        {
            //проверить наличие шильдика
            var recipientsArea = new atFrameWork2.SeleniumFramework.WebItem("//div[@id='entity-selector-oPostFormLHE_blogPostForm']//div[@class='ui-tag-selector-items']",
                "Область получателей поста");
            return recipientsArea.AssertTextContains(recipientName, default);
        }

        internal NewsPostForm AddNewsTitle()
        {
            // добавляет в заголовок новости текущее время
            //var AddNewsDesc = new WebItem("//div[@id='microoPostFormLHE_blogPostForm']", "Раскрывает поле Написать сообщение");
            //AddNewsDesc.Click();
            //iframe[@class='bx-editor-iframe']
            //NewsDeskFrame.SwitchToFrame();
            var NewsTime = DateTime.Now;
            var NewsDeskFrame = new WebItem("//iframe[@class='bx-editor-iframe']", "ФРЕЙМ написать сообщение");
            NewsDeskFrame.SwitchToFrame();
            NewsDeskFrame.Click();
            NewsDeskFrame.SendKeys("NewsTime");
            DriverActions.SwitchToDefaultContent();
            return new NewsPostForm();
        }

        internal bool IsNewsWitFileAdded()
        {
           //проверка что новость с текущим временем создалась
            throw new NotImplementedException();
        }

        internal NewsPostForm AddNewsDeskription()
        {
            var NewsDescription = new WebItem("", "Добавляет заголовок новости");
           // throw new NotImplementedException();
            return new NewsPostForm();
        }

        internal NewsPostForm SaveNews()
        {
            //сохраняет новость по кнопке отправить
            var BtnSaveNews = new WebItem("//button[@id='blog-submit-button-save']", "Кнопка отправить новость");
            BtnSaveNews.Click();
            return new NewsPostForm();
        }

        internal NewsPostForm AddFiles()
        {
            //добавляет файл
            var BtnAddFiles = new WebItem("//div[@class='disk-file-control-panel-file-wrap']/input[@type='file']", "загрузка файла");
            BtnAddFiles.SendKeys("C:/Windows/Web/Wallpaper/Theme1/img1.jpg");
            return new NewsPostForm();
        }
    }
}
