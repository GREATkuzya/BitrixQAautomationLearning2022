using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;

namespace ATframework3demo.TestCases
{
    public class Case_NewsWithFile : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var CaseCollection = new List<TestCase>();
            CaseCollection.Add(new TestCase("Создание поста с прикрепленным файлом в новостях", homePage => CreateNewsWithFile(homePage)));

            return CaseCollection;
        }
        void CreateNewsWithFile(atFrameWork2.PageObjects.PortalHomePage homePage)
        {
            // открыть новости
            // нажать на ввести сообщение
            // ввести сообщение
            // прикрепить  файл
            // нажать отправить
            // Проверить, что новость отображается

            homePage
                .LeftMenu
                .OpenNews()
                .AddPost()
                //.AddNewsTitle()
                //.AddNewsDeskription()
                .AddFiles()
                .SaveNews();
                //.IsNewsWitFileAdded();
        }
    }
}
