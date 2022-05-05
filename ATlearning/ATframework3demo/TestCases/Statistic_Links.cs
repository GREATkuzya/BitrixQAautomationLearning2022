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
            caseCollection.Add(new TestCase("Удаление ранее созданно короткой ссылки", homePage => DeleteLink(homePage)));
            caseCollection.Add(new TestCase("Просмотр количества переходов по ссылке(общее)", homePage => WatchStatsLink(homePage)));
            caseCollection.Add(new TestCase("Создание QR-кода по короткой ссылке", homePage => QRCreateAndCheck(homePage)));
            return caseCollection;
        }

        void CreateLink(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            string LinkName = "какое-то название";
            string LinkAdress = "https://git-scm.com/book/ru/v2/%D0%92%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5-%D0%A3%D1%81%D1%82%D0%B0%D0%BD%D0%BE%D0%B2%D0%BA%D0%B0-Git";
            string BusinessName = "hello";
            homePage
                .GoToBusiness()                                //войти в бизнесы
                .ChooseBusiness(BusinessName)                  //выбрать бизнес
                .GoToLinks()                                   //выбрать генерация ссылки
                .LinkAdd(LinkName, LinkAdress)                 //создать ссылку
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
                                                      //Проверить, что ссылки нет


        }


        void WatchStatsLink(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            string LinkName = "какое-то название";
            string BusinessName = "hello";
            homePage.GoToBusiness().ChooseBusiness(BusinessName).GoToLinksStatistic().GetLinkStatistic(LinkName);
            //войти
            //выбрать бизнес
            //выбрать статистику переходов
            //выбрать интересующую ссылку
        }

        void QRCreateAndCheck(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            string LinkName = "проверка QR-кода";
            string LinkAdress = "https://www.sports.ru/baltika/calendar/";
            string BusinessName = "hello";
            homePage
                .GoToBusiness()                                //войти в бизнесы
                .ChooseBusiness(BusinessName)                  //выбрать бизнес
                .GoToLinks()                                   //выбрать генерация ссылки
                .LinkAdd(LinkName, LinkAdress)                 //создать ссылку
                .GenerateQR(LinkAdress);
        }



    }
}
