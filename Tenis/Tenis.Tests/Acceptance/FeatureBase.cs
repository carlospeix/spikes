using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Tenis.Tests.Acceptance
{
	public class FeatureBase
	{
		protected static IWebDriver CurrentDriver
		{
			get
			{
				if (FeatureContext.Current.ContainsKey("CurrentDriver"))
					return (IWebDriver)FeatureContext.Current["CurrentDriver"];

				if (ScenarioContext.Current.ContainsKey("CurrentDriver"))
					return (IWebDriver)ScenarioContext.Current["CurrentDriver"];

				throw new InvalidOperationException("Acceso a CurrentDriver no inicializado");
			}
		}
	}
}