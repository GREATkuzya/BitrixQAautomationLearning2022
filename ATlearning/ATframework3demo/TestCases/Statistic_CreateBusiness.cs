using atFrameWork2.BaseFramework;

namespace ATframework3demo.TestCases
{
    public class Statistic_CreateBusiness : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Создание бизнеса, удаление его и выход из системы", homePage => CreateBusiness(homePage)));
            caseCollection.Add(new TestCase("Удаление ранее созданного бизнеса", homePage => DeleteBusiness(homePage)));
            caseCollection.Add(new TestCase("Проверка создания метки для сайта", homePage => CheckMark(homePage)));
            return caseCollection;
        }

        void CreateBusiness(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            DateTime NewsTimeToPost = DateTime.Now;
            string NewsTime = NewsTimeToPost.ToString();


            if (homePage
                    .GoToBusiness()                //перейти на страницу бизнесов
                    .AddBusiness(NewsTime)         //ввести имя бизнеса + нажать создать
                    .IsBusinessAdded(NewsTime)     //проверить, что создался по названию
                ) ;
                {homePage
                    .GoToBusiness()
                    .DeleteBusiness(NewsTime);     //удалить этот бизнес
            };
                homePage
                    .GoToBusiness()
                    .IsBusinessDeleted(NewsTime);  //Проверить, что бизнеса нет
            homePage.GoToBusiness().LogOut();       //Выйти из системы

        }


        void DeleteBusiness(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            string BusinessName = "для удаления";
            homePage
                .GoToBusiness()                   //перейти на страницу бизнесов
                .DeleteBusiness(BusinessName);    //удалить бизнес
            homePage
                .GoToBusiness()
                .IsBusinessDeleted(BusinessName); //проверить, что бизнес удален

        }


        void CheckMark(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            string BusinessName = "тест";
            homePage
                .GoToBusiness()                   //перейти на страницу бизнесов
                .ChooseBusiness(BusinessName)     //выбрать бизнес
                .GoToMarkPage()                   //перейти на страницу с меткой  
                .GetMark();                       //получить метку
                
        }

        

    }
}
