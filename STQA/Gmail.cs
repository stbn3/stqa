using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using STQA.Custom;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace STQA
{
    class Gmail
    {
        MyWebDriver Chrome;

        [OneTimeSetUp]
        public void StartBrowser()
        {
            Chrome = new MyWebDriver(new ChromeDriver());
            Chrome.Manage().Window.Maximize();
            Chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
        }
        [Test,Order(0)]
        public void Login()
        {
            try
            {
                string Email = "nosoyprieto@gmail.com";
                string Password = "Abc1234!";

                Console.WriteLine("✔ Navegando a http://www.gmail.com");
                Chrome.Navigate().GoToUrl("http://www.gmail.com");

                Console.WriteLine("✔ Introduciendo el email: " + Email);
                IWebElement EmailElement = Chrome.FindElement(By.XPath("//*[@id='identifierId']"));
                EmailElement.SendKeys(Email);
                IWebElement EmailSiguiente = Chrome.FindElement(By.XPath("//*[@id='identifierNext']"));
                EmailSiguiente.Click();

                Console.WriteLine("✔ Introducciendo password");
                IWebElement PasswordElement = Chrome.FindElement(By.XPath("//*[@id='password']/div[1]/div/div[1]/input"));
                PasswordElement.SendKeys(Password);
                IWebElement PasswordSiguiente = Chrome.FindElement(By.XPath("//*[@id='passwordNext']"));
                PasswordSiguiente.Click();

                Console.WriteLine("✔ Iniciando sesión en Gmail");
                var Wait = new WebDriverWait(Chrome, TimeSpan.FromSeconds(10));
                Wait.Until(x => x.Title.Contains(Email));

                string ImagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Screenshot.png";
                
                Chrome.TakeScreenshot(ImagePath, ScreenshotImageFormat.Png);

            }
            catch (Exception ex) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("✘Ha ocurrido un error\r\n" + ex.Message);
            }

        }
        [Test, Order(1)]
        public void Logout() {
            string LogoutTitle = "Gmail";

            IWebElement ShowMenu = Chrome.FindElement(By.XPath("//*[@id='gb']/div[2]/div[1]/div[2]/div[5]/div[1]/a"));
            ShowMenu.Click();
            

            IWebElement CerrarSesion = Chrome.FindElement(By.XPath("//*[@id='gb_71']"));
            CerrarSesion.Click();

            var Wait = new WebDriverWait(Chrome, TimeSpan.FromSeconds(10));
            Wait.Until(x => x.Title.Contains(LogoutTitle));


        }
        [OneTimeTearDown]
        public void CloseBrowser()
        {
            Chrome.Quit();
        }
    }
}
