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
            caseCollection.Add(new TestCase("Мастер-кейс(Создание бизнеса => создание короткой ссылки => переход по созданной ссылке и просмотр статистики(3раза) => удаление ссылки => удаление бизнеса => выход из системы)", homePage => MasterCase(homePage)));
            return caseCollection;
        }

        void MasterCase(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            DateTime TimeToPost = DateTime.Now;
            string BusinessName = TimeToPost.ToString();
            string LinkName = "Проверка";
            string LinkAdress = "https://www.ya.ru/";
            string LinkShortName = "";
                homePage
                    .GoToBusiness()                                //перейти на страницу бизнесов
                    .AddBusiness(BusinessName)                     //ввести имя бизнеса + нажать создать
                    .ChooseBusiness(BusinessName)                  //выбрать бизнес
                    .GoToLinks()                                   //выбрать генерация ссылки
                    .LinkAdd(LinkName, LinkAdress, LinkShortName)  //создать короткую ссылку
                   //в идеале по короткой ссылке можно перейти из распознанного qr-кода, если получится реализовать
                    .GoToRedirectedLink(LinkName)                  //перейти по короткой ссылке, чтобы было количество переходов
                    .GoToLinksStatistic()                          //перейти на статистику переходов
                    .GetLinkStatistic(LinkName)                    //получить статистику по названию ссылки(1)
                    .GoToLinks()                                   //Снова на страницу ссылок   
                    .GoToRedirectedLink(LinkName)                  //Переход по ссылке опять
                    .GoToLinksStatistic()                          //переход на страницу статистики(таким образом страница статистики обновляется и получает обновленные данные)
                    .GetLinkStatistic(LinkName)                    //получить обновленную статистику(2)
                    .GoToLinks()                                   //Снова на страницу ссылок
                    .GoToRedirectedLink(LinkName)                  //Переход по ссылке 3й раз
                    .GoToLinksStatistic()                          //переход на страницу статистики(таким образом страница статистики обновляется и получает обновленные данные)
                    .GetLinkStatistic(LinkName)                    //получить обновленную статистику(3)
                    .GoToLinks()                                   //обратно на страницу ссылок
                    .DeleteLink(LinkName);                         //Удалить ссылку
                homePage
                    .GoToBusiness()                                //перейти на страницу бизнесов
                    .DeleteBusiness(BusinessName)                  //удалить этот бизнес
                    .LogOut();                                     //Выйти из системы



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
