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
            DateTime NewsTimeToPost = DateTime.Now;
            string NewsTime = NewsTimeToPost.ToString(); //так создалось, по другому не хотело
            string FileAddr = "C:/Windows/Web/Wallpaper/Theme1/img1.jpg";
            string FileName = "img1";
            string assertPhrase = "Добавить сотрудников, группы или отделы";
            // разные сценарии кейса если стоит или не стоит получатель
            if (homePage.LeftMenu.OpenNews().AddPost().IsRecipientPresent(assertPhrase) == true)
            {

                homePage
                    .LeftMenu     // Левое меню
                    .OpenNews()   // Клик в новости
                    .AddPost()    // Клик в поле новости
                    .EnableSendToAll() // включить адресацию всем сотрудникам
                    .AddNewsTitle(NewsTime) // вставляю переменную с датойвременем в название
                    .AddFiles(FileAddr) // Добавляю файл из директории винды 10, который должен быть у всех
                    .SaveNews() // жму на кнопку отправить
                     //.IsNewsWitFileAdded(NewsTime) // проверяю добавился ли текст с переменной в пост
                    .IsFileAttached(FileName); // проверяю есть ли файл по наличию текстового имени файла
            }
          
            else

                homePage
                    .LeftMenu     // Левое меню
                    .OpenNews()   // Клик в новости
                    .AddPost()    // Клик в поле новости
                    .AddNewsTitle(NewsTime) // вставляю переменную с датойвременем в название
                    .AddFiles(FileAddr) // Добавляю файл из директории винды 10, который должен быть у всех
                    .SaveNews() // жму на кнопку отправить
                    //.IsNewsWitFileAdded(NewsTime) // проверяю добавился ли текст с переменной в пост
                    .IsFileAttached(FileName); // проверяю есть ли файл по наличию текстового имени файла
        }
    }
}
