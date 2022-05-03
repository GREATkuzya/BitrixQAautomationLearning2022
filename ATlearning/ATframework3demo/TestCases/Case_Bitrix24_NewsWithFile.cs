﻿using atFrameWork2.BaseFramework;

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
            

            homePage
                .LeftMenu
                .OpenNews()
                .AddPost();
              
                
        }
    }
}
