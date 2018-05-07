using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using STQA.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STQA
{
        class AboutPage
        {
            private IWebDriver driver;
            private WebDriverWait wait;

            public AboutPage(IWebDriver driver)
            {
                this.driver = driver;
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                PageFactory.InitElements(driver, this);
            }

        //[FindsBy(How = How.CssSelector, Using = "#sidebar input[class='s']")]
        [FindsBy(How = How.Custom, Using = "//*[@id='menu-main']/li[10]/div/form/div/div[1]/input",CustomFinderType = typeof(MySearchBy))]
        private IWebElement searchText;
        [Obsolete("En próximas versiones el campo se ocultará, este método dejará de funcionar")]
        public ResultPage search(string text)
        {
            searchText.SendKeys(text);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='menu-main']/li[10]/div/form/div/div[2]/input"))).Click();
            return new ResultPage(driver);
        }
    }
}
