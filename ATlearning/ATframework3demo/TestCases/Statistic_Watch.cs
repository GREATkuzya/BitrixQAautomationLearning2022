using atFrameWork2.BaseFramework;

namespace ATframework3demo.TestCases
{
    public class Statistic_Watch : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Просмотр статистики по бизнесу", homePage => WatchBusinessStat(homePage)));
            return caseCollection;
        }

        void WatchBusinessStat(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            string BusinessName = "hello";
            homePage.GoToBusiness().ChooseBusiness(BusinessName);
            Thread.Sleep(10000);
        }



    }
}
