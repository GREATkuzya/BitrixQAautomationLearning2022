using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class NewsPage
    {
        internal NewsPostForm AddPost()
        {
            // клик в написать сообщение
            var newsTextField = new WebItem("//div[@id='bx-html-editor-iframe-cnt-idPostFormLHE_blogPostForm']", "Поле ввода текста");
            //throw new NotImplementedException();
            return new NewsPostForm();
        }
    }
}
