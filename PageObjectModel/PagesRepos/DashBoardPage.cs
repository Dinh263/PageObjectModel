using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.PagesRepos
{
    class DashBoardPage
    {

        [FindsBy(How = How.XPath, Using = "//span[@id='userFullName']")]
        public IWebElement LbelUserName { get; set; }

        private readonly IWebDriver driver;
        public DashBoardPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void LoginSuccessfully(string profileName)
        {
            Assert.IsTrue(LbelUserName.Text.Equals(profileName));
        }
    }
}
