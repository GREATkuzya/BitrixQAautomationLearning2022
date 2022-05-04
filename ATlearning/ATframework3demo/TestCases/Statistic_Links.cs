using atFrameWork2.BaseFramework;
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
            return caseCollection;
        }

        void CreateLink(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            string LinkName = "какое-то название";
            string LinkAdress = "https://git-scm.com/book/ru/v2/%D0%92%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5-%D0%A3%D1%81%D1%82%D0%B0%D0%BD%D0%BE%D0%B2%D0%BA%D0%B0-Git";
            string BusinessName = "hello";
            homePage.GoToBusiness().ChooseBusiness(BusinessName).GoToLinks().LinkAdd(LinkName, LinkAdress).IsLinkAdded(LinkName);
            //войти
            //выбрать бизнес
            //выбрать генерация ссылки
            //создать ссылку
            //проверить, что ссылка создана

        }

        void DeleteLink(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            string LinkName = "qwqert";
            string BusinessName = "hello";
            homePage.GoToBusiness().ChooseBusiness(BusinessName).GoToLinks().DeleteLink(LinkName);
            //войти
            //выбрать бизнес
            //выбрать генерацию ссылок
            //Удалить интересующую ссылку
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


       


    }
}
