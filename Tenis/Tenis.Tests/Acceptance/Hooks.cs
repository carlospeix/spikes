using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using TechTalk.SpecFlow;

namespace Tenis.Tests.Acceptance
{
	[Binding]
	public class Hooks
	{
		[BeforeFeature("UI")]
		public static void BeforeFeature()
		{
			//FeatureContext.Current.Add("CurrentDriver",  new FirefoxDriver());
			FeatureContext.Current.Add("CurrentDriver", new ChromeDriver(@"C:\GitHub\spikes\Tenis"));
			//FeatureContext.Current.Add("CurrentDriver", new InternetExplorerDriver(@"C:\GitHub\spikes\Tenis"));
		}

		[AfterFeature("UI")]
		public static void AfterFeature()
		{
			if (!FeatureContext.Current.ContainsKey("CurrentDriver"))
				return;

			var webDriver = (IWebDriver) FeatureContext.Current["CurrentDriver"];
			FeatureContext.Current.Remove("CurrentDriver");
			webDriver.Quit();
		}
	}
}