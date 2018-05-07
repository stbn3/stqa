using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STQA
{
    class SeleniumGrid
    {
        IWebDriver Driver;

        [SetUp]
        public void Init() {

            
            DesiredCapabilities Capabilities = new DesiredCapabilities();
            Capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
            Capabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));

            Driver = new RemoteWebDriver(new Uri("http://192.168.52.129:4444/wd/hub"),Capabilities);

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        [Test]
        public void OpenGoogle() {

            //string Url = "http://www.google.es";
            //Driver.Navigate().GoToUrl(Url);

            #region Entrada Gmail
            try
            {
                string Email = "nosoyprieto@gmail.com";
                string Password = "Abc1234!";

                Console.WriteLine("✔ Navegando a http://www.gmail.com");
                Driver.Navigate().GoToUrl("http://www.gmail.com");

                Console.WriteLine("✔ Introduciendo el email: " + Email);
                IWebElement EmailElement = Driver.FindElement(By.XPath("//*[@id='identifierId']"));
                EmailElement.SendKeys(Email);
                IWebElement EmailSiguiente = Driver.FindElement(By.XPath("//*[@id='identifierNext']"));
                EmailSiguiente.Click();

                Console.WriteLine("✔ Introducciendo password");
                IWebElement PasswordElement = Driver.FindElement(By.XPath("//*[@id='password']/div[1]/div/div[1]/input"));
                PasswordElement.SendKeys(Password);
                IWebElement PasswordSiguiente = Driver.FindElement(By.XPath("//*[@id='passwordNext']"));
                PasswordSiguiente.Click();

                Console.WriteLine("✔ Iniciando sesión en Gmail");
                var Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                Wait.Until(x => x.Title.Contains(Email));
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("✘Ha ocurrido un error\r\n" + ex.Message);
            }
            #endregion
        }
        [TearDown]
        public void CloseDriver()
        {
            Driver.Quit();
        }
    }
}
