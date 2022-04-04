using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestCases;
using atFrameWork2.BaseFramework.LogTools;

namespace ATframework3demo.PageObjects
{
    /// <summary>
    /// Форма добавления нового сообщения в новости
    /// </summary>
    public class NewsPostForm
    {
        //DateTime NewsTime = DateTime.Now;

        internal bool IsRecipientPresent(string recipientName)
        {
            //проверить наличие шильдика
            var recipientsArea = new atFrameWork2.SeleniumFramework.WebItem("//div[@id='entity-selector-oPostFormLHE_blogPostForm']//div[@class='ui-tag-selector-items']",
                "Область получателей поста");
            return recipientsArea.AssertTextContains(recipientName, default);
        }

        internal bool IsNewsWitFileAdded(string NewsTime)
        {
            //проверка что новость с текущим временем создалась(попробовал применить интерполяцию)
            var NewsCheck = new WebItem($"//div[contains(text(), '{NewsTime}')]",
                "Проверка присутствия переменной в новостях");
            return NewsCheck.AssertTextContains(NewsTime, "Новость не найдена", default);
            
        }

        internal bool IsFileAttached(string FileName)
        {
            // проверка, что файл прикрепился к посту
            var FileExists = new WebItem($"//img[@class='disk-ui-file-thumbnails-web-grid-img-item' and contains(@alt, '{FileName}')]", "проверка по имени файла в новости");
            if (!FileExists.WaitElementDisplayed())
                Log.Error("Файл не найден");
            return FileExists.AssertTextContains(FileName, "Файл не найден", default);
        }

        internal NewsPostForm AddNewsTitle(string NewsTime)
        {
            // добавляет в заголовок новости текущее время
            var NewsDeskFrame = new WebItem("//iframe[@class='bx-editor-iframe']", "ФРЕЙМ написать сообщение");
            // переключение во фрейм, отправление переменной, выход из фрейма
            NewsDeskFrame.SwitchToFrame();
            var NewsDescriptionField = new WebItem("//body[@contenteditable='true']", "поле фрейма написать сообщение");
            NewsDescriptionField.SendKeys(NewsTime);
            DriverActions.SwitchToDefaultContent();
            return new NewsPostForm();
        }

     
        internal NewsPostForm AddFiles(string FileAddr)
        {
            //добавляет файл в инпут
            var BtnAddFiles = new WebItem("//div[@class='disk-file-control-panel-file-wrap']/input[@type='file']", "загрузка файла");
            BtnAddFiles.SendKeys($"{FileAddr}");
            var OneDigit = new WebItem("//div[@class='ui-counter-inner' and text()='1']",
                "Значок единички, что файл загрузился");
            OneDigit.WaitElementDisplayed();// ожидание загрузки файла 
            return new NewsPostForm();
        }
        internal NewsPostForm SaveNews()
        {
            //сохраняет новость по кнопке отправить
            var BtnSaveNews = new WebItem("//button[@id='blog-submit-button-save']", 
                "Кнопка отправить новость");
            BtnSaveNews.Click();
            BtnSaveNews.WaitWhileElementDisplayed();
            return new NewsPostForm();
        }

       
    }
}
