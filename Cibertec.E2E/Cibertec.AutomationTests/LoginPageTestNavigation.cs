using Cibertec.Automation;
using FluentAssertions;
using System;
using System.Threading;
using Xunit;

namespace Cibertec.AutomationTests
{
    public class LoginPageTestNavigation
    {
        public LoginPageTestNavigation()
        {
            Driver.GetInstance(DriversOption.Chrome);
        }

        [Fact]
        public void LoginTest()
        {
            LoginPage.Go();
            LoginPage.LoginAs("juvega@gmail.com").WithPassword("12345678").Login();

            Thread.Sleep(TimeSpan.FromSeconds(2));
            LoginPage.GetUrl().Should().Be("http://localhost/Angular/#!/home");
            LoginPage.Logout();
            Driver.CloseInstance();
        }

        [Fact]
        public void LoginWrongTest()
        {
            LoginPage.Go();
            LoginPage.LoginAs("juvega@gmail.com").WithPassword("87654321").Login();

            Thread.Sleep(TimeSpan.FromSeconds(2));
            LoginPage.IsAlertErrorPresent().Should().BeTrue();
            Driver.CloseInstance();
        }

    }
}
