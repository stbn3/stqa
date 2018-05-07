using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STQA
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='menu-item-21']/a")]
        private IWebElement about;

        [FindsBy(How = How.ClassName, Using = "fusion-main-menu-icon")]
        private IWebElement searchIcon;

        public void goToPage()
        {
            driver.Navigate().GoToUrl("https://www.swtestacademy.com");
        }

        public AboutPage goToAboutPage()
        {
            about.Click();
            return new AboutPage(driver);
        }
    }
}
