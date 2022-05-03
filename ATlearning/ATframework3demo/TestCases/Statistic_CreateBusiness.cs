using atFrameWork2.BaseFramework;

namespace ATframework3demo.TestCases
{
    public class Statistic_CreateBusiness : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Создание бизнеса", homePage => CreateBusiness(homePage)));
            return caseCollection;
        }

        void CreateBusiness(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            //перейти на страницу бизнесов
            homePage.GoToBusiness().AddBusiness();
            //ввести имя бизнеса
            //нажать создать
            //проверить, что создался по названию
        }

    }
}
