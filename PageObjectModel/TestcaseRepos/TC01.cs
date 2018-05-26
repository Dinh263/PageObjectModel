using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Configuration;
using OpenQA.Selenium.Chrome;
using PageObjectModel.PagesRepos;
using System.Threading;

namespace PageObjectModel.TestcaseRepos
{
    /// <summary>
    /// Summary description for TC01
    /// </summary>
    [TestClass]
    public class TC01
    {
        string username = "";
        string password = "";
        string baseUrl = "";
        IWebDriver driver;
        LoginPage login;
        DashBoardPage dashboard;
        [TestInitialize]
        public void OpenBrowserAndGoToUrl()
        {
            initiateDataForTesting();
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Window.Maximize();
            login = new LoginPage(driver);
            //Thread.Sleep(TimeSpan.FromMinutes(1));
            login.LoginToApplication(username, password);
        }

        [TestMethod]
        public void TestMethod1()
        {
            dashboard = new DashBoardPage(driver);
            dashboard.LoginSuccessfully("Marissa Chiu");
        }

        [TestCleanup]
        public void CloseBrowser()
        {
            driver.Quit();
        }

        private void initiateDataForTesting()
        {
            username = ConfigurationManager.AppSettings["username"].ToString();
            password = ConfigurationManager.AppSettings["password"].ToString();
            baseUrl = ConfigurationManager.AppSettings["baseUrl"].ToString();
            Console.WriteLine(username + " - " + password + " - " + baseUrl);
        }
    }
}
