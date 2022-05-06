using atFrameWork2.SeleniumFramework;

namespace atFrameWork2.PageObjects

{
    internal class StatisticPage : BusinessPage
    {
        public StatisticPage() { }

        internal bool IsLinkChosen(string LinkAdress)
        {
            var DisplayedLink = new WebItem("//div[@class='up-charts-page-for-detail-notice']/b", "Выбранная ссылка");
            return DisplayedLink.AssertTextContains(LinkAdress, "Ссылка не найдена", default);
        }

        internal void IsUnicsChosen()
        {
            throw new NotImplementedException();
        }
    }
}