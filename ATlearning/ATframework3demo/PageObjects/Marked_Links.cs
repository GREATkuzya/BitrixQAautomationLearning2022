using atFrameWork2.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ATframework3demo.PageObjects
{
    public class Marked_Links
    {

        internal void GoToMarkedLink1(string MarkLink)
        {
           // string LinkMark = "http://www.google.com";
            WebDriver driver = new ChromeDriver();
            driver.Url = MarkLink;
           // return new BusinessPage();
        }
    }
}
