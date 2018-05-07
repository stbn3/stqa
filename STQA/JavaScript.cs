using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace STQA
{
    class JavaScript
    {
        ChromeDriver Chrome;

        [SetUp]
        public void StartBrowser()
        {
            Chrome = new ChromeDriver();
            Chrome.Manage().Window.Maximize();
            Chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }
        [Test]
        public void HandleElementByJs()
        {
            try
            {
                Console.WriteLine("✔ Navegando a https://www.anaesthetist.com/mnm/javascript/calc.htm");
                Chrome.Navigate().GoToUrl("https://www.anaesthetist.com/mnm/javascript/calc.htm");

                Console.WriteLine("✔ Ocultando botón 7 de la calculadora");

                IJavaScriptExecutor js = (IJavaScriptExecutor)Chrome;
                js.ExecuteScript("document.getElementsByName('seven')[0].style.display = 'none'");

                Console.WriteLine("✔ Comprobando que el botón se haya ocultado correctamente");
                var Wait = new WebDriverWait(Chrome, TimeSpan.FromSeconds(10));
                bool IsElementInVisible = Wait.Until(x => x.FindElement(By.XPath("/html/body/div/table/tbody/tr/td/font/div[2]/form/table/tbody/tr[2]/td[1]/table/tbody/tr[1]/td[1]/input")).Displayed == false);


                Assert.AreEqual(true, IsElementInVisible, "✘ Ha ocurrido un error, el elemento no se ha podido ocultar");
                Console.WriteLine("✔ El elemento se ha ocultado correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        [Test]
        public void ExecuteJs()
        {
            try
            {

                string ButtonSevenName = "seven";
                string ButtonTwoName = "two";
                string BottonAddName = "add";

                string ButtonResultName = "result";

                string ExpectedResult = "9";

                Console.WriteLine("✔ Navegando a https://www.anaesthetist.com/mnm/javascript/calc.htm");
                Chrome.Navigate().GoToUrl("https://www.anaesthetist.com/mnm/javascript/calc.htm");

                Console.WriteLine("✔ Haciendo clic en el botón 7");
                Chrome.ExecuteScript("document.getElementsByName('" + ButtonSevenName + "')[0].click()");

                Console.WriteLine("✔ Haciendo clic en el botón +");
                Chrome.ExecuteScript("document.getElementsByName('" + BottonAddName + "')[0].click()");

                Console.WriteLine("✔ Haciendo clic en el botón 2");
                Chrome.ExecuteScript("document.getElementsByName('" + ButtonTwoName + "')[0].click()");

                Console.WriteLine("✔ Haciendo clic en el botón =");
                Chrome.ExecuteScript("document.getElementsByName('" + ButtonResultName + "')[0].click()");

                /*
                Console.WriteLine("✔ Calculando ejecutando la función Javascript Calculate()");
                Chrome.ExecuteScript("Calculate();");
                */

                Console.WriteLine("✔ Comprobando que el resultado de la operación sea igual a 9");

                // Recordar que si queremos recuperar el valor directamente de Javascript podéis hacerlo como está en el ejemplo de Manu (SumaJs)
                var Wait = new WebDriverWait(Chrome, TimeSpan.FromSeconds(100));
                bool IsSumOk = Wait.Until(x => x.FindElement(By.Name("Display")).GetAttribute("value") == ExpectedResult);

                Assert.AreEqual(true, IsSumOk, "✘ Ha ocurrido un error, la suma no ha sido correcta");
                Console.WriteLine("✔ La suma es correcta");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        [TearDown]
        public void CloseBrowser()
        {
            Chrome.Quit();
        }
    }
}
