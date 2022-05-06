using atFrameWork2.BaseFramework;
using QRCodeDecoderLibrary;
namespace ATframework3demo.TestCases
{
    public class Statistic_Links : CaseCollectionBuilder
    {
                protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Создание короткой ссылки", homePage => CreateLink(homePage)));
            caseCollection.Add(new TestCase("Удаление ранее созданной короткой ссылки", homePage => DeleteLink(homePage)));
            caseCollection.Add(new TestCase("Просмотр количества переходов по ссылке(общее)", homePage => WatchStatsLink(homePage)));
            caseCollection.Add(new TestCase("Создание QR-кода по короткой ссылке, проверка соответствия текста в QR-коде через UI, удаление следов", homePage => QRCreateAndCheck(homePage)));
            caseCollection.Add(new TestCase("Проверка QR-кода с использованием библиотеки, ", homePage => QRCheckWithLib(homePage)));
            return caseCollection;
        }

        void CreateLink(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            string LinkName = "Памятка по XPath";
            string LinkAdress = "https://mellarius.ru/xpath";
            string LinkShortName = "";
            string BusinessName = "hello";
            homePage
                .GoToBusiness()                                //войти в бизнесы
                .ChooseBusiness(BusinessName)                  //выбрать бизнес
                .GoToLinks()                                   //выбрать генерация ссылки
                .LinkAdd(LinkName, LinkAdress, LinkShortName)  //создать ссылку
                .IsLinkAdded(LinkName);                        //проверить, что ссылка создана

        }

        void DeleteLink(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            string LinkName = "qwqert";
            string BusinessName = "hello";
            homePage
                .GoToBusiness()                       //войти
                .ChooseBusiness(BusinessName)         //выбрать бизнес
                .GoToLinks()                          //выбрать генерацию ссылок
                .DeleteLink(LinkName);                //Удалить интересующую ссылку
                                                      //Проверить, что ссылки нет(можно сделать)


        }


        void WatchStatsLink(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            string LinkName = "какое-то название";
            string BusinessName = "hello";
            homePage
                .GoToBusiness()                      //войти 
                .ChooseBusiness(BusinessName)        //выбрать бизнес
                .GoToLinksStatistic()                //выбрать статистику переходов
                .GetLinkStatistic(LinkName);         //получить статистику по нужному названию ссылки
        }

        void QRCreateAndCheck(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            string LinkName = "проверка QR-кода";
            string LinkAdress = "https://www.sports.ru/baltika/calendar/";
            string LinkShortName = "";
            string BusinessName = "hello";
            homePage
                .GoToBusiness()                                //войти в бизнесы
                .ChooseBusiness(BusinessName)                  //выбрать бизнес
                .GoToLinks()                                   //выбрать генерация ссылки
                .LinkAdd(LinkName, LinkAdress, LinkShortName)  //создать ссылку
                .GenerateQR(LinkAdress)                        //Создать QR-код и проверить
                .DeleteLink(LinkName);                         //Удалить ссылку
        }

        void QRCheckWithLib(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            string LinkName = "QR-код проверка";
            string LinkAdress = "https://www.sports.ru/";
            string LinkShortName = "";
            string BusinessName = "hello";
            homePage
                .GoToBusiness()                                //войти в бизнесы
                .ChooseBusiness(BusinessName)                  //выбрать бизнес
                .GoToLinks()                                   //выбрать генерация ссылки
                .LinkAdd(LinkName, LinkAdress, LinkShortName)  //создать ссылку
                .GetQR(LinkName);                              //создает QR-код(клик по кнопке)

                //.GenerateQR(LinkAdress)                        //Создать QR-код и проверить
                //.DeleteLink(LinkName);                         //Удалить ссылку
        }

    }
}
