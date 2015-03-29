using System;
using OpenQA.Selenium;

namespace Tenis.Tests.Pages
{
	public class HomePage : TenisPage
	{
		public HomePage(IWebDriver webDriver) : base(webDriver)
		{
			WebDriver.Navigate().GoToUrl("http://localhost:7607/");
		}

		public TenisPage StartWith(string player1, string player2)
		{
			WebDriver.FindElement(By.Name("player1")).SendKeys(player1);
			WebDriver.FindElement(By.Name("player2")).SendKeys(player2);
			WebDriver.FindElement(By.Name("player1")).Submit();
			return new GamePage(WebDriver);
		}
	}
}