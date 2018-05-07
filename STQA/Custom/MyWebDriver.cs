using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STQA.Custom
{
    class MyWebDriver:IWebDriver
    {
        private IWebDriver WebDriver;

        public MyWebDriver(IWebDriver WebDriver) {
            this.WebDriver = WebDriver;
        }

        public string Url { get => WebDriver.Url; set => WebDriver.Url = value; }
        public string Title => WebDriver.Title;
        public string PageSource => WebDriver.PageSource;
        public string CurrentWindowHandle => WebDriver.CurrentWindowHandle;
        public ReadOnlyCollection<string> WindowHandles => WebDriver.WindowHandles;

        public void Close()
        {
            WebDriver.Close();
        }
        public void Dispose() {
            this.WebDriver.Dispose();
        }
        public IWebElement FindElement(By by)
        {
            return WebDriver.FindElement(by);
        }
        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return WebDriver.FindElements(by);
        }
        public IOptions Manage()
        {
            return WebDriver.Manage();
        }
        public INavigation Navigate()
        {
            return WebDriver.Navigate();
        }
        public void Quit()
        {
            WebDriver.Quit();
        }
        public ITargetLocator SwitchTo()
        {
            return WebDriver.SwitchTo();
        }

        #region Funciones personalizadas
        /// <summary>
        /// Take Screenshot to current Window, overwriting the file if it already exists.
        /// </summary>
        /// <param name="FilePath">The full path and the filename to save the screenshot to </param>
        /// <param name="Format">A ScreenshotImageFormat value indicating the format to save the image to</param>
        public void TakeScreenshot(string FilePath,ScreenshotImageFormat Format) {

            ITakesScreenshot ScreenshotDriver = (ITakesScreenshot)this.WebDriver;
            Screenshot ScreenShot = ScreenshotDriver.GetScreenshot();
            ScreenShot.SaveAsFile(FilePath, Format);
        }
        #endregion
    }
}
