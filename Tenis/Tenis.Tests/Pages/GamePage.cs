using OpenQA.Selenium;

namespace Tenis.Tests.Pages
{
	public class GamePage : TenisPage
	{
		public GamePage(IWebDriver webDriver) : base(webDriver)
		{
		}

		public void Start()
		{
			WebDriver.Navigate().GoToUrl("http://localhost:7607/Home/Start?player1=X&player2=Y");
		}

		public string Result
		{
			get { return WebDriver.FindElement(By.Id("result")).Text; }
		}
	}
}