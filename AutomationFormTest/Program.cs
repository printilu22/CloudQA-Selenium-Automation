using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using OpenQA.Selenium.Support.Extensions;

class InternshipAutomationTest
{
    static void Main()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        try
        {
            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

            // ==== 1. Fill FIRST NAME in Normal HTML ====
            IWebElement firstNameField = wait.Until(drv => drv.FindElement(
                By.XPath("//div[contains(@class, 'form-group')]//input[contains(@placeholder, 'First Name') or contains(@name, 'fname') or @id='fname']")));
            firstNameField.SendKeys("Iliyas");
            if (firstNameField.GetAttribute("value") == "Iliyas")
                Console.WriteLine("✅ First Name entered and verified");
            else
                Console.WriteLine("❌ First Name verification failed");

            Screenshot ss1 = ((ITakesScreenshot)driver).GetScreenshot();
            ss1.SaveAsFile($"screenshot_after_name_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            Console.WriteLine("✅ Screenshot taken after name entry");

            // ==== 2. Switch to IFRAME and enter MOBILE NUMBER ====
            IWebElement iframe = wait.Until(drv => drv.FindElement(
                By.CssSelector("iframe[id*='iframe'], iframe[name*='iframe'], iframe[src*='AutomationPracticeForm']")));
            driver.SwitchTo().Frame(iframe);

            IWebElement mobileField = wait.Until(drv => drv.FindElement(
                By.XPath("//input[contains(@placeholder, 'Mobile') or @type='tel' or contains(@name, 'mobile')]")));
            mobileField.SendKeys("9876543210");
            if (mobileField.GetAttribute("value") == "9876543210")
                Console.WriteLine("✅ Mobile Number entered and verified");
            else
                Console.WriteLine("❌ Mobile Number verification failed");

            Screenshot ss2 = ((ITakesScreenshot)driver).GetScreenshot();
            ss2.SaveAsFile($"screenshot_after_mobile_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            Console.WriteLine("✅ Screenshot taken after mobile entry");

            // ==== 3. Select STATE inside the same IFRAME ====
            IWebElement stateDropdown = wait.Until(drv => drv.FindElement(
                By.XPath("//select[contains(@name, 'state') or .//option[contains(text(), 'India')]]")));
            SelectElement select = new SelectElement(stateDropdown);
            select.SelectByText("India");
            if (select.SelectedOption.Text == "India")
                Console.WriteLine("✅ State selected and verified");
            else
                Console.WriteLine("❌ State verification failed");

            Screenshot ss3 = ((ITakesScreenshot)driver).GetScreenshot();
            ss3.SaveAsFile($"screenshot_after_state_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            Console.WriteLine("✅ Screenshot taken after state selection");

            // ==== Back to main content ====
            driver.SwitchTo().DefaultContent();

            // Wait to observe results
            Thread.Sleep(3000);
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error occurred: " + ex.Message);
            try
            {
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile($"screenshot_error_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                Console.WriteLine("✅ Screenshot taken on error");
            }
            catch (Exception screenshotEx)
            {
                Console.WriteLine("⚠ Could not take error screenshot: " + screenshotEx.Message);
            }
        }
        finally
        {
            driver.Quit();
        }
    }
}