using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace Cibertec.Automation
{
    public enum DriversOption
    {
        Chrome,
        InternetExplorer
    }

    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static void GetInstance(DriversOption option)
        {
            switch (option)
            {
                case DriversOption.Chrome:
                    Instance = ChromeInstance();
                    break;
                case DriversOption.InternetExplorer:
                    Instance = InternetExplorerInstance();
                    break;

                default:
                    Instance = null;
                    break;
            }

        }

        private static IWebDriver InternetExplorerInstance()
        {
            return new InternetExplorerDriver();
        }

        private static IWebDriver ChromeInstance()
        {
            var options = new ChromeOptions();
            options.AddArguments("chrome.switches", "--disable-extensions --disable ---enable-automation --start-maximized");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);

            return new ChromeDriver(options);
        }

        public static void CloseInstance()
        {
            Instance.Close();
            Instance.Quit();
            Instance = null;
        }


    }

}
