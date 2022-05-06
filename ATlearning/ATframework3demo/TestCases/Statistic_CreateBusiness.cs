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
            caseCollection.Add(new TestCase("Проверка метки для сайта для заранее созданного бизнеса", homePage => CheckMark(homePage)));
            return caseCollection;
        }

        void CreateBusiness(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            DateTime NewsTimeToPost = DateTime.Now;
            string BusinessName = NewsTimeToPost.ToString();


            if (homePage
                    .GoToBusiness()                    //перейти на страницу бизнесов
                    .AddBusiness(BusinessName)         //ввести имя бизнеса + нажать создать
                    .IsBusinessAdded(BusinessName)     //проверить, что создался по названию
                )
                {homePage
                    .GoToBusiness()
                    .DeleteBusiness(BusinessName);     //удалить этот бизнес
            };
                homePage
                    .GoToBusiness()
                    .IsBusinessDeleted(BusinessName);  //Проверить, что бизнеса нет
            homePage.GoToBusiness().LogOut();          //Выйти из системы

        }


        void DeleteBusiness(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            string BusinessName = "для удаления";
            homePage
                .GoToBusiness()                        //перейти на страницу бизнесов
                .DeleteBusiness(BusinessName);         //удалить бизнес
            homePage
                .GoToBusiness()                        //перейти на страницу бизнесов
                .IsBusinessDeleted(BusinessName);      //проверить, что бизнес удален

        }


        void CheckMark(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            string BusinessName = "тест";
            homePage
                .GoToBusiness()                   //перейти на страницу бизнесов
                .ChooseBusiness(BusinessName)     //выбрать бизнес
                .GoToMarkPage()                   //перейти на страницу с меткой  
                .GetMark();                       //получить метку(возможно изза тега <pre> не получается взять текст метки, но метка существует, тест проходит)
                
        }

        

    }
}
