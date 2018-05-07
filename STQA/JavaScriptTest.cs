using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace CursoSelenium
{
    class JavaScriptTest
    {
        private IWebDriver driver;
        private string url = "https://www.anaesthetist.com/mnm/javascript/calc.htm";
        private IJavaScriptExecutor js;
        private string SevenButton = "seven";
        private string FourButton = "four";
        private string AddButton = "add";
        private string ResultButton = "result";

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Navigate().GoToUrl(url);
            js = (IJavaScriptExecutor)driver;
        }

        [Test]
        public void SumaJS()
        {
            try
            {
                js.ExecuteScript("document.getElementsByName('" + SevenButton + "')[0].click()");
                js.ExecuteScript("document.getElementsByName('" + AddButton + "')[0].click()");
                js.ExecuteScript("document.getElementsByName('" + FourButton + "')[0].click()");
                js.ExecuteScript("document.getElementsByName('" + ResultButton + "')[0].click()");
                string result = js.ExecuteScript("return document.Calculator.Display.value").ToString();

                Console.WriteLine("Result: " + result);

                Assert.AreEqual("11", result, "The result was not the expected.");
                Console.WriteLine("All successfull in SumaJS.");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR en SumaJS: " + e.Message);
            }
        }

        [Test]
        public void VerSiSieteOcultoJS()
        {
            try
            {
                js.ExecuteScript("document.getElementsByName('" + SevenButton + "')[0].style.display = 'none'");
                //js.ExecuteScript("document.getElementsByName('" + SevenButton + "')[0].style.display == 'none'");
                bool isSevenShowed = driver.FindElement(By.Name("seven")).Displayed;

                Assert.False(isSevenShowed, "The button seven is NOT hidden");
                Console.WriteLine("All successfull in VerSiSieteOcultoJS.");
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR en VerSiSieteOcultoJS: " + e.Message);
            }

        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
