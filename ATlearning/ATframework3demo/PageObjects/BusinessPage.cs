using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QRCodeDecoderLibrary;
using System.Drawing;
using System.Text;

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

        internal BusinessPage LinkAdd(string linkName, string linkAdress, string LinkShortName)
        {
            var LinkTagInput = new WebItem("//input[@name='tag']", "Поле ввода тэга ссылки");
            var LinkUrlInput = new WebItem("//input[@name='url']", "Поле ввода тэга ссылки");
            var LinkShortInput = new WebItem("//input[@name='short_path']", "Поле ввода тэга ссылки");
            var LinkSubmit = new WebItem("//input[@name='submit']", "Создание короткой ссылки");
            LinkTagInput.SendKeys(linkName);
            LinkUrlInput.SendKeys(linkAdress);
            LinkShortInput.SendKeys(LinkShortName);
            LinkSubmit.Click();
            return new BusinessPage();


        }

        internal BusinessPage GoToRedirectedLink(string LinkName)
        {
            var TagItem = new WebItem($"//div[contains(text(), '{LinkName}')]/../../..//div[@name='link-short-path']", "Короткая ссылка");
            string TagAdress = TagItem.GetAttribute("innerText");
            IWebDriver webDriver = DriverActions.GetNewDriver();
            webDriver.Navigate().GoToUrl(TagAdress);
            Log.Info($"Произведен переход по созданной короткой: {TagAdress}");
            webDriver.Quit();
            return new BusinessPage();
        }

        internal BusinessPage DeleteLink(string linkName)
        {
            var LinkCross = new WebItem($"//div[contains(text(), '{linkName}')]/..//*[@type='submit']", "Кнопка удаления ссылки");
            LinkCross.Click();
            var DelAgree = new WebItem("//button[@class='ui-btn ui-btn-success']/span[text() = 'Подтвердить']", "Кнопка подтвердить");
            DelAgree.WaitElementDisplayed();
            DelAgree.Click();
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
            string MarkTextHtml = MarkText.GetAttribute("textContent");
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

        internal BusinessPage GenerateQR(string LinkAdress)
        {
            var AddQR = new WebItem($"//a[@href = '{LinkAdress}']/../..//button[@name='generate-qr-btn']", "Кнопка генерации QR-кода");
            AddQR.Click();
            var QRImg = new WebItem($"//a[@href = '{LinkAdress}']/../..//img[@alt='Scan me!']", "Картинка QR-кода");
            string ImgSrc = QRImg.GetAttribute("src");
            var TagItem = new WebItem($"//a[@href = '{LinkAdress}']/../..//div[@name='link-short-path']", "Короткая ссылка");
            string TagAdress = TagItem.GetAttribute("innerText");
            
            //Создание дополнительного драйвера для передачи кода base64 и получения картинки с qr-кодом в файл
            IWebDriver webDriver = DriverActions.GetNewDriver();
            string uri1 = "https://codebeautify.org/base64-to-image-converter";
            webDriver.Navigate().GoToUrl(uri1);
            var TextArea = new WebItem("//textarea[@id='inputTextArea']", "Поле ввода Base64");
            var GenerateButton = new WebItem("//button[@id='defaultAction']", "Кнопка Генерации картинки");
            var DownloadImage = new WebItem("//button[@id='downloadImage2']", "Кнопка скачать");
            TextArea.WaitElementDisplayed(5, webDriver);
            GenerateButton.WaitElementDisplayed(5, webDriver);
            TextArea.SendKeys(ImgSrc, webDriver);
            GenerateButton.Click(webDriver);
            DownloadImage.Click(webDriver);
           
            //Создание еще одного драйвера для передачи картинки на распознавание и получения результата считывания кода 
            IWebDriver webDriver1 = DriverActions.GetNewDriver();
            string uri2 = "https://decodeit.ru/qr/";
            webDriver1.Navigate().GoToUrl(uri2);
            var ImgLoad = new WebItem("//input[@id='qr_file']", "загрузить картинку с qr-кодом");
            var Submit = new WebItem("//input[@id='qr_decode_submit']", "Кнопка загрузки картинки");
            string FileAdr = "C:/Users/kuzya/Downloads/cbimage.png";
            ImgLoad.WaitElementDisplayed(5, webDriver1);
            Submit.WaitElementDisplayed(5, webDriver1);
            ImgLoad.SendKeys($"{FileAdr}", webDriver1);
            Submit.Click(webDriver1);
            Thread.Sleep(2000);   //Просто чтобы наглядно показать, что распознавание кода прошло
            var Result = new WebItem("//div[@class='success']", "див с результатом");
            Result.WaitElementDisplayed(5, webDriver1);
            string QrResult = Result.GetAttribute("innerText", webDriver1);
            if (Result.AssertTextContains(TagAdress, "Ссылка не найдена", webDriver1)) 
            {
                Log.Info($"QR-код распознался правильно ({TagAdress} - код первоначальный, {QrResult}- Код распознанный)");
            }
            else
            {
                Log.Error("QR-код не распознался");
            };
            File.Delete($@"{FileAdr}");
            webDriver.Quit();
            webDriver1.Quit();
            return new BusinessPage();

           
        }

        internal BusinessPage CheckQRWithUI(string LinkName)
        {
            var TagItem = new WebItem($"//div[contains(text(), '{LinkName}')]/../../..//div[@name='link-short-path']", "Короткая ссылка");
            string TagAdress = TagItem.GetAttribute("innerText");
            //Создание еще одного драйвера для передачи картинки на распознавание и получения результата считывания кода 
            IWebDriver webDriver1 = DriverActions.GetNewDriver();
            string uri2 = "https://decodeit.ru/qr/";
            webDriver1.Navigate().GoToUrl(uri2);
            var ImgLoad = new WebItem("//input[@id='qr_file']", "загрузить картинку с qr-кодом");
            var Submit = new WebItem("//input[@id='qr_decode_submit']", "Кнопка загрузки картинки");
            string FileAdr = $"C:/Users/kuzya/Downloads/{LinkName}-qr.png";
            ImgLoad.WaitElementDisplayed(5, webDriver1);
            Submit.WaitElementDisplayed(5, webDriver1);
            ImgLoad.SendKeys($"{FileAdr}", webDriver1);
            Submit.Click(webDriver1);
            Thread.Sleep(2000);   //Просто чтобы наглядно показать, что распознавание кода прошло
            var Result = new WebItem("//div[@class='success']", "див с результатом");
            Result.WaitElementDisplayed(5, webDriver1);
            string QrResult = Result.GetAttribute("innerText", webDriver1);
            if (Result.AssertTextContains(TagAdress, "Ссылка не найдена", webDriver1))
            {
                Log.Info($"QR-код распознался правильно ({TagAdress} - код первоначальный, {QrResult}- Код распознанный)");
            }
            else
            {
                Log.Error("QR-код не распознался");
            };
            File.Delete($@"{FileAdr}");
           
            webDriver1.Quit();
            File.Delete($@"{FileAdr}");
            return new BusinessPage();
        }

        internal BusinessPage GetQRImg(string LinkAdress)
        {
            var AddQR = new WebItem($"//a[@href = '{LinkAdress}']/../..//button[@name='generate-qr-btn']", "Кнопка генерации QR-кода");
            AddQR.Click();
            var QRLink = new WebItem($"//a[@href = '{LinkAdress}']/../..//a[@class='qr-code-download-link']", "Скачать QR-код");
            QRLink.Click();

            return new BusinessPage();
        }


       

        internal BusinessPage GetQR(string fileName)
        {
          string fileAdr = $"C:/Users/kuzya/Downloads/{fileName}-qr.png";
            QRDecoder QRcode = new QRDecoder();
            Bitmap image1 = (Bitmap)Image.FromFile(@"C:\qr.png");
            //var res = decoder.ImageDecoder(image1);

            QRCodeResult[] ResultArray = QRcode.ImageDecoder((Bitmap)Image.FromFile(fileAdr));
            string TextResult = QRcode.ByteArrayToStr(ResultArray[0].DataArray);

            //string TextResult = QRCode.ByteArrayToStr(res[0]);
            //string link = Encoding.UTF8.GetString(res[0]);
            Log.Info($"{res}, {link}");
            File.Delete($@"{fileAdr}");            
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
            DriverActions.Refresh();
            return new StatisticPage();
        }



        internal StatisticPage RefreshPage()
        {
            Thread.Sleep(3000);   //время, необходимое, чтобы данные добавилиль в базу данных и отобразилась обновленная статистика 
            Waiters.WaitForCondition(() =>
            {
                DriverActions.Refresh();
                var BusinessPageLogo = new WebItem("//img[@class='logo']", "Иконка бизнесов");
                return BusinessPageLogo.WaitElementDisplayed(1);
            }, 5, 30, "Ожидание обновления страницы");
            
            return new StatisticPage();
        }


        internal BusinessPage LogOut()
        {
            var ExitButton = new WebItem("//a[@class='logout-btn-header-href']", "Выход из сервиса");
            ExitButton.Click();
            ExitButton.WaitWhileElementDisplayed();
            return new BusinessPage();
        }

        internal bool IsBusinessDeleted(string BusinessName)
        { 
              var BusinessCheck = new WebItem($"//div[contains(text(), '{BusinessName}')]", "Проверка присутствия переменной в бизнесах");
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
                Log.Info("Бизнес отсутствует на странице");
                return true;
            }
                    
        }



        internal bool IsBusinessAdded(string BusinessName)
        {
            var BusinessCheck = new WebItem($"//div[contains(text(), '{BusinessName}')]",
               "Проверка присутствия переменной в бизнесах");
            return BusinessCheck.AssertTextContains(BusinessName, "бизнес не найден", default);
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

        internal BusinessPage DeleteBusiness(string BusinessName)
        {
            var DelCross = new WebItem($"//div[contains(text(), '{BusinessName}')]/..//*[@type='submit']","Крестик удаления бизнеса");
            DelCross.Click();
            var DelAgree = new WebItem("//button[@class='ui-btn ui-btn-success']/span[text() = 'Подтвердить']", "Кнопка подтвердить");
            DelAgree.WaitElementDisplayed();
            DelAgree.Click();
            DelCross.WaitWhileElementDisplayed();   
            return new BusinessPage();
        }

        internal BusinessPage GoToMarkedLink(string MarkLink)
        {
            WebDriver driver = new ChromeDriver();
            driver.Url = MarkLink;
            Log.Info($"Произведен переход по странице со встроенной меткой данного бизнеса: {MarkLink}");
            driver.Quit();
            return new BusinessPage();
        }

    }
}