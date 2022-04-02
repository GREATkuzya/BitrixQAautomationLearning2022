using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    /// <summary>
    /// Форма добавления нового сообщения в новости
    /// </summary>
    public class NewsPostForm
    {
       // const string NewsTime = "Жопа";
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
            var NewsTime = DateTime.Now;
            var NewsDeskFrame = new WebItem("//iframe[@class='bx-editor-iframe']", "ФРЕЙМ написать сообщение");
            // переключение во фрейм, отправление переменной, выход из фрейма
            NewsDeskFrame.SwitchToFrame();
            var NewsDescriptionField = new WebItem("//body[@contenteditable='true']", "поле фрейма написать сообщение");
            NewsDescriptionField.SendKeys("Пост с картинкой, который создался " + NewsTime);
            DriverActions.SwitchToDefaultContent();
            return new NewsPostForm();
        }

      
        internal NewsPostForm AddFiles()
        {
            //добавляет файл в инпут
            var BtnAddFiles = new WebItem("//div[@class='disk-file-control-panel-file-wrap']/input[@type='file']", "загрузка файла");
            BtnAddFiles.SendKeys("C:/Windows/Web/Wallpaper/Theme1/img4.jpg");
            //BtnAddFiles.SendKeys("https://static.mir-kubikov.ru/upload/medialibrary/000dk/60242_Feature2.jpg");  //не работает на картинку в вебе
            Thread.Sleep(1000); //все ломается если не подождать здесь
            return new NewsPostForm();
        }
        internal NewsPostForm SaveNews()
        {
            //сохраняет новость по кнопке отправить
            var BtnSaveNews = new WebItem("//button[@id='blog-submit-button-save']", 
                "Кнопка отправить новость");
            BtnSaveNews.Click();
            Thread.Sleep(1000); //все ломается если не подождать здесь
            return new NewsPostForm();
        }

        internal bool IsNewsWitFileAdded(string NewsTime)
        {
            //проверка что новость с текущим временем создалась
            var NewsCheck = new WebItem("//div[@id='log_internal_container']", 
                "Проверка присутствия переменной в новостях");
            return NewsCheck.AssertTextContains(NewsTime, default);
         
        }

    }
}
