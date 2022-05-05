using atFrameWork2.BaseFramework;

namespace ATframework3demo.TestCases
{
    public class Statistic_Watch : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Просмотр статистики по бизнесу", homePage => WatchBusinessStat(homePage)));
            caseCollection.Add(new TestCase("Просмотр статистики по бизнесу по фильтру уникальные", homePage => WatchBusinessStatUnics(homePage)));
            caseCollection.Add(new TestCase("Просмотр статистики по бизнесу по конкретной ссылке", homePage => WatchBusinessStatLink(homePage)));
            caseCollection.Add(new TestCase("Просмотр количества посещений конкретной ссылки", homePage => WatchLinkStatsNum(homePage)));
            caseCollection.Add(new TestCase("Переход по ссылке и просмотр статистики", homePage => VisitAndCheck(homePage)));
            return caseCollection;
        }

        void WatchBusinessStat(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            string BusinessName = "hello";
            homePage
                .GoToBusiness()                      //открыть страницу бизнесов
                .ChooseBusiness(BusinessName);       //Выбрать бизнес
            Thread.Sleep(10000);
        }

        void WatchBusinessStatUnics(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            string BusinessName = "тест";
            homePage
                .GoToBusiness()                      //открыть страницу бизнесов
                .ChooseBusiness(BusinessName)        //Выбрать бизнес
                .ChoseUnics();                       //Выбрать фильтр уникальные
            Thread.Sleep(10000);
        }

        void WatchBusinessStatLink(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            string BusinessName = "тест";
            string LinkAdress = "file:///D:/index.html";
            homePage
                .GoToBusiness()                      //открыть страницу бизнесов
                .ChooseBusiness(BusinessName)        //Выбрать бизнес
                .ChoseLink(LinkAdress)               //Выбрать ссылку
                .IsLinkChosen(LinkAdress);           //Проверить, что нужная ссылка выбрана
            Thread.Sleep(10000);
        }


        void WatchLinkStatsNum(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            string BusinessName = "тест";
            string LinkAdress = "file:///D:/index.html";
            homePage
                .GoToBusiness()                      //открыть страницу бизнесов
                .ChooseBusiness(BusinessName)        //Выбрать бизнес
                .GetWatchNum(LinkAdress);            //Посмотреть количество общих просмотров по ссылке
            //Thread.Sleep(10000);
        }


        void VisitAndCheck(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            string BusinessName = "тест";
            string LinkMark = "file:///D:/index.html";
            homePage
                .GoToBusiness()                   //перейти на страницу бизнесов
                .ChooseBusiness(BusinessName)     //выбрать бизнес
                .GetLinkStatistic(LinkMark)       //взять в лог количество посещений страницы
                .GoToMarkedLink(LinkMark)         //загрузить  страницу с меткой отдельно в новой вкладке и закрыть
                .GoToVisitStatistic()             //перейти(обновить) на страницу статистики для обновления данных
                .GetLinkStatistic(LinkMark);      //взять в лог количество посещений страницы(+1)
        }


    }
}
