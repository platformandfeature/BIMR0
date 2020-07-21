using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LT
{
    public class Util
    {
        public static IWebElement FluentWaitByName(IWebDriver driver, string NameLocator)
        {

            try
            {
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
                fluentWait.Timeout = TimeSpan.FromSeconds(15);
                fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
                fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                IWebElement searchEelement = fluentWait.Until(x => x.FindElement(By.Name(NameLocator)));
                return searchEelement;

            }
            catch (Exception e)
            {
                Debug.WriteLine("Some Error: " + e.Message);
                return null;
            }

        }

        public static IWebElement ExplicitWaitByName(IWebDriver driver, string NameLocator)
        {

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                wait.PollingInterval = TimeSpan.FromMilliseconds(1500);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException),typeof(ElementNotVisibleException));
                IWebElement searchElement = wait.Until(ExpectedConditions.ElementExists(By.Name(NameLocator)));
                return searchElement;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Some Error: " + e.Message);
                return null;
            }
        }



        public static IWebElement ExplicitWaitByXpath(IWebDriver driver, string XpathLocator)

        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                wait.PollingInterval = TimeSpan.FromMilliseconds(1500);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
                IWebElement searchElement = wait.Until(ExpectedConditions.ElementExists(By.XPath(XpathLocator)));
                return searchElement;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Some Error: " + e.Message);
                return null;
            }
        }



        public static IWebElement ExplicitWaitById(IWebDriver driver, string IdLocator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                wait.PollingInterval = TimeSpan.FromMilliseconds(1500);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
                IWebElement searchElement = wait.Until(ExpectedConditions.ElementExists(By.Id(IdLocator)));
                return searchElement;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Some Error: " + e.Message);
                return null;
            }
        }

        public static IWebElement ExplicitWaitByCss(IWebDriver driver, string CssLocator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                wait.PollingInterval = TimeSpan.FromMilliseconds(1500);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
                IWebElement searchElement = wait.Until(ExpectedConditions.ElementExists(By.Id(CssLocator)));
                return searchElement;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Some Error: " + e.Message);
                return null;
            }
        }

        public static string ExplicitWaitAndWaitPageLoadByPageElementName(IWebDriver driver, string NameIdentifierOfLoadingPage)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                wait.PollingInterval = TimeSpan.FromMilliseconds(1500);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(NameIdentifierOfLoadingPage)));
                return driver.Title;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Some Error: " + e.Message);
                return null;
            }
        }

        public static string ExplicitWaitAndWaitPageLoadByPageElementID(IWebDriver driver, string NameIdentifierOfLoadingPage)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.PollingInterval = TimeSpan.FromMilliseconds(1500);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(NameIdentifierOfLoadingPage)));
                return driver.Title;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Some Error: " + e.Message);
                return null;
            }
        }

        public static string ExplicitWaitAndWaitPageLoadByPageElementXpath(IWebDriver driver, string NameIdentifierOfLoadingPage)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                wait.PollingInterval = TimeSpan.FromMilliseconds(1500);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(NameIdentifierOfLoadingPage)));
                return driver.Title;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Some Error: " + e.Message);
                return null;
            }
        }

        /// <summary>
        /// Generic method for element to load before clicking, 
        /// </summary>
        /// <param name="driver">IWebDriver</param>
        /// <param name="IdentifierType">class, name, id, xpath, cssselector, linktext, partiallink, tagename</param>
        /// <param name="NameIdentifierOfLoadingPage">DOM element</param>
        /// <returns></returns>
        public static IWebElement GetIfElementIsClickable(IWebDriver driver, string IdentifierType, string elementToBeSearched)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.PollingInterval = TimeSpan.FromMilliseconds(1500);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
                switch (IdentifierType)
                {
                    case "class":
                        return wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(elementToBeSearched)));
                    case "name":
                        return wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(elementToBeSearched)));
                    case "id":
                        return wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(elementToBeSearched)));
                    case "xpath":
                        return wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(elementToBeSearched)));
                    case "cssselector":
                        return wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(elementToBeSearched)));
                    case "linktext":
                        return wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(elementToBeSearched)));
                    case "partiallink":
                        return wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText(elementToBeSearched)));
                    case "tagname":
                        return wait.Until(ExpectedConditions.ElementToBeClickable(By.TagName(elementToBeSearched)));
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Some Error: " + e.Message);
            }
            return null;
        }

        public static bool IfElementExistsByClassName(IWebDriver driver, string elementToBeSearched)
        {
            try
            {

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.PollingInterval = TimeSpan.FromMilliseconds(1500);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
                wait.Until(ExpectedConditions.ElementExists(By.ClassName(elementToBeSearched)));
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Some Error: " + e.Message);
                return false;
            }
        }

        public static bool IfElementExistsByIdentifier(IWebDriver driver, string IdentifierType, string elementToBeSearched)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.PollingInterval = TimeSpan.FromMilliseconds(1500);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
                switch (IdentifierType)
                {
                    case "class":
                        wait.Until(ExpectedConditions.ElementExists(By.ClassName(elementToBeSearched)));
                        return true;
                    case "id":
                        wait.Until(ExpectedConditions.ElementExists(By.Id(elementToBeSearched)));
                        return true;
                    case "xpath":
                        wait.Until(ExpectedConditions.ElementExists(By.XPath(elementToBeSearched)));
                        return true;
                    case "cssselector":
                        wait.Until(ExpectedConditions.ElementExists(By.CssSelector(elementToBeSearched)));
                        return true;
                    case "linktext":
                        wait.Until(ExpectedConditions.ElementExists(By.LinkText(elementToBeSearched)));
                        return true;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Some Error: " + e.Message);
            }
            return false;
        }

        public static string Capture(IWebDriver driver, string ScreenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            //string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            //string uptobinPath = path.Substring(0, path.LastIndexOf("bin")) + "Screenshots\\" + ScreenShotName + ".png";
            //string localPath = new Uri(uptobinPath).LocalPath;
            screenshot.SaveAsFile(@"D:\DB\" + ScreenShotName + ".png", ScreenshotImageFormat.Png);
            return @"D:\DB\" + ScreenShotName + ".png";
        }

    }

}

