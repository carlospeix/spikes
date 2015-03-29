using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using Tenis.Controllers;
using Tenis.Tests.Pages;

namespace Tenis.Tests.Acceptance
{
	[Binding]
	public class StepsDefinitions : FeatureBase
	{
		//private ViewResult _result;
		private TenisPage _page;

		[Given(@"I start the application")]
		public void GivenIStartTheApplication()
		{
			//var controller = new HomeController();
			//_result = controller.Index();
			_page = new HomePage(CurrentDriver);
		}

		[Then(@"I should see the message ""(.*)""")]
		public void ThenIShouldSeeTheText(string message)
		{
			//Assert.AreEqual(message, _result.ViewBag.Message);
			Assert.AreEqual(message, _page.Message);
		}

		[Then(@"I should see the error message ""(.*)""")]
		public void ThenIShouldSeeTheErrorMessage(string message)
		{
			Assert.AreEqual(message, _page.ErrorMessage);
		}

		[When(@"I start the game with ""(.*)"" and ""(.*)""")]
		public void WhenIStartTheGameWithAnd(string player1, string player2)
		{
			//var controller = new HomeController();
			//_result = controller.Start(player1, player2);
			_page = _page.As<HomePage>().StartWith(player1, player2);
		}

		[Given(@"I start the game with two players")]
		public void GivenIStartTheGameWithTwoPlayers()
		{
			_page = new GamePage(CurrentDriver);
			_page.As<GamePage>().Start();
		}

		[Then(@"the result should be ""(.*)""")]
		public void ThenTheResultShouldBe(string expectedresult)
		{
			Assert.AreEqual(expectedresult, _page.As<GamePage>().Result);
		}
	}
}