using atFrameWork2.BaseFramework.LogTools;
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

        internal StatisticPage IsUnicsChosen(bool MustBeChecked)
        {
            var Unics = new WebItem("//input[@name='unique_only']", "Чекбокс уникальные пользователи");
            var IsUnicsCheked = Unics.Checked();
            if (IsUnicsCheked != MustBeChecked)
                Log.Error("Чекбокс не выбран, хотя должен быть выбран");
            else
            {
                Log.Info("Чекбокс выбран");
            };
            return new StatisticPage();
        }

    }
}