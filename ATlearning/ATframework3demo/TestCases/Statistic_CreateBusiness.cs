using atFrameWork2.BaseFramework;

namespace ATframework3demo.TestCases
{
    public class Statistic_CreateBusiness : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Создание бизнеса и удаление его", homePage => CreateBusiness(homePage)));
            return caseCollection;
        }

        void CreateBusiness(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            DateTime NewsTimeToPost = DateTime.Now;
            string NewsTime = NewsTimeToPost.ToString();


            if (homePage.GoToBusiness().AddBusiness(NewsTime).IsBusinessAdded(NewsTime)) ;
            { homePage.GoToBusiness().DeleteBusiness(NewsTime); }
            //перейти на страницу бизнесов
            //ввести имя бизнеса + нажать создать
            //проверить, что создался по названию
            //удалить этот бизнес
        }



    }
}
