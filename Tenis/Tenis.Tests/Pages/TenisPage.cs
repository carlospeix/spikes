using System;
using OpenQA.Selenium;

namespace Tenis.Tests.Pages
{
	public abstract class TenisPage
	{
		// WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
		// wait.Until((d) => { return d.Title.ToLower().StartsWith("cheese"); });

		// IWebElement element = (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return $('.cheese')[0]");

		// IList<IWebElement> labels = driver.FindElements(By.TagName("label"));
		// IList<IWebElement> inputs = (IList<IWebElement>)((IJavaScriptExecutor)driver).ExecuteScript(
		// 		"var labels = arguments[0], inputs = []; for (var i=0; i < labels.length; i++){" +
		// 		"inputs.push(document.getElementById(labels[i].getAttribute('for'))); } return inputs;", labels);

		protected IWebDriver WebDriver;

		protected TenisPage(IWebDriver webDriver)
		{
			WebDriver = webDriver;
		}

		public string Message
		{
			get { return WebDriver.FindElement(By.Id("message")).Text; }
		}

		public string ErrorMessage
		{
			get { return WebDriver.FindElement(By.Id("errorMessage")).Text; }
		}

		public TPage As<TPage>() where TPage : TenisPage
		{
			return (TPage)this;
		}
	}
}