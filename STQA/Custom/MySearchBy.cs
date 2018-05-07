using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STQA.Custom
{
    class MySearchBy:By
    {
        public MySearchBy(string InputSearch) {

            FindElementMethod = (ISearchContext context) => {
                IWebElement Element = context.FindElement(By.XPath("//*[@id='menu-main']/li[10]/a"));
                Element.Click();
                IWebElement QueryInput = context.FindElement(By.XPath(InputSearch));
                return QueryInput;
            };

            FindElementsMethod = (ISearchContext context) => {
                IWebElement Element = context.FindElement(By.XPath("//*[@id='menu-main']/li[10]/a"));
                Element.Click();
                ReadOnlyCollection<IWebElement> QueryInput = context.FindElements(By.XPath(InputSearch));
                return QueryInput;
            };
        }
    }
}
