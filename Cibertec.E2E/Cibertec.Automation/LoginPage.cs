using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Cibertec.Automation
{
    public class LoginPage
    {
        public static void Go()
        {
            Driver.Instance.Navigate().GoToUrl("http://localhost/Angular/");

            Driver.Instance.FindElement(By.CssSelector("a[href='#!/login']")).Click();

        }


        public static LoginCommand LoginAs(string userName)
        {
            return new LoginCommand(userName);
        }

        public static string GetUrl()
        {
            return Driver.Instance.Url;
        }

        public static bool IsAlertErrorPresent()
        {
            var element = Driver.Instance.FindElement(By.CssSelector("div.alert-danger"));
            return element != null;

        }
        public static void Logout()
        {
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.CssSelector("a[ng-click='vm.logout()']")));
            Driver.Instance.FindElement(By.CssSelector("a[ng-click='vm.logout()']"));

        }
    }

    public class LoginCommand
    {
        private string userName;
        private string password;

        public LoginCommand(string userName)
        {
            this.userName = userName;

        }

        public LoginCommand WithPassword(string password)
        {
            this.password = password;
            return this;
        }

        public void Login()
        {
            Driver.Instance.FindElement(By.Id("email")).Clear();
            Driver.Instance.FindElement(By.Id("email")).SendKeys(userName);

            Driver.Instance.FindElement(By.Id("password")).Clear();
            Driver.Instance.FindElement(By.Id("password")).SendKeys(password);

            Driver.Instance.FindElement(By.CssSelector("button.btn.btn-primary")).Click();

        }

    }

}
