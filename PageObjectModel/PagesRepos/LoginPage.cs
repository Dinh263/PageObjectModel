using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.PagesRepos
{
    class LoginPage
    {
        [FindsBy(How=How.Name,Using = "UserName")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement PassWord { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Sign in']")]
        public IWebElement BtnSignIn { get; set; }

        private readonly IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void LoginToApplication(string username, string password)
        {
            UserName.SendKeys(username);
            PassWord.SendKeys(password);
            BtnSignIn.Click();
        }
    }
}
