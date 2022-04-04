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
            string FileAddr = "C:/Windows/Web/Wallpaper/Theme1/img4.jpg";
            string FileName = "img4";
            string assertPhrase = "Всем сотрудникам";
            //Подготовка к кейсу, если галочка снята, то надо её установить обратно
            if (homePage.LeftMenu.OpenNews().AddPost().IsRecipientPresent(assertPhrase) == false)
            {
                homePage
                    .LeftMenu
                    .OpenSettings()
                    .EnableDefaultSendToAll()
                    .Save();

                bool isAllRecipientsDisplayed2 = homePage
                    .LeftMenu
                    .OpenNews()
                    .AddPost()
                    .IsRecipientPresent(assertPhrase);

                if (!isAllRecipientsDisplayed2)
                {
                    Log.Error("Не Отображается 'Всем сотрудникам' в получателях поста," +
                        " но при этом галочка в настройках установлена");
                }
            }
            // открыть новости
            // нажать на ввести сообщение
            // ввести сообщение
            // прикрепить файл
            // нажать отправить
            // Проверить, что новость отображается

            homePage
                .LeftMenu     // метод делали на лекции
                .OpenNews()   // метод делали на лекции
                .AddPost()    // тоже на лекции
                .AddNewsTitle(NewsTime) // вставляю переменную с датойвременем в название
                .AddFiles(FileAddr) // Добавляю файл из директории винды 10, который должен быть у всех
                .SaveNews() // жму на кнопку отправить
                //.IsNewsWitFileAdded(NewsTime) // проверяю добавился ли текст с переменной в пост
                .IsFileAttached(FileName); // проверяю есть ли файл по наличию текстового имени файла
        }
    }
}
