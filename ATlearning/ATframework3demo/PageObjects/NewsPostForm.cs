using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
namespace ATframework3demo.PageObjects
{
    // Форма добавления нового сообщения в новости
    public class NewsPostForm
    {
        internal bool IsRecipientPresent(string recipientName)
        {
            // проверить наличие этого шильдика
            throw new NotImplementedException();
        }

        internal NewsPostForm AddNewsTitle()
        {
            // добавить заголовок новости
            var btnNewsDesc = new WebItem("//div[@id='microoPostFormLHE_blogPostForm']", "поле Написать сообщение");
            btnNewsDesc.Click();
            
            throw new NotImplementedException();
            return new NewsPostForm();
        }

        internal NewsPostForm AddFiles()
        {
            // Добавить файл
            throw new NotImplementedException();
            return new NewsPostForm();
        }

        internal NewsPostForm SaveNews()
        {
            // нажать на отправить
            throw new NotImplementedException();
        }
    }
}
