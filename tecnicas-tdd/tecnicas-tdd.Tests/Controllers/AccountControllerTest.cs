using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tecnicas_tdd;
using tecnicas_tdd.Controllers;
using tecnicas_tdd.Models;
using tecnicas_tdd.Tests.Builders;
using Moq;

namespace tecnicas_tdd.Tests.Controllers
{

	[TestClass]
	public class AccountControllerTest
	{

		[TestMethod]
		public void ChangePassword_Get_ReturnsView()
		{
			// Arrange
			AccountController controller = GetAccountController();

			// Act
			ActionResult result = controller.ChangePassword();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			Assert.AreEqual(10, ((ViewResult)result).ViewData["PasswordLength"]);
		}

		[TestMethod]
		public void ChangePassword_Post_ReturnsRedirectOnSuccess()
		{
			// Arrange
			AccountController controller = GetAccountController();
			ChangePasswordModel model = new ChangePasswordModel()
			{
				OldPassword = "goodOldPassword",
				NewPassword = "goodNewPassword",
				ConfirmPassword = "goodNewPassword"
			};

			// Act
			ActionResult result = controller.ChangePassword(model);

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
			RedirectToRouteResult redirectResult = (RedirectToRouteResult)result;
			Assert.AreEqual("ChangePasswordSuccess", redirectResult.RouteValues["action"]);
		}

		[TestMethod]
		public void ChangePassword_Post_ReturnsViewIfChangePasswordFails()
		{
			// Arrange
			AccountController controller = GetAccountController();
			ChangePasswordModel model = new ChangePasswordModel()
			{
				OldPassword = "goodOldPassword",
				NewPassword = "badNewPassword",
				ConfirmPassword = "badNewPassword"
			};

			// Act
			ActionResult result = controller.ChangePassword(model);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.AreEqual(model, viewResult.ViewData.Model);
			Assert.AreEqual("The current password is incorrect or the new password is invalid.", controller.ModelState[""].Errors[0].ErrorMessage);
			Assert.AreEqual(10, viewResult.ViewData["PasswordLength"]);
		}

		[TestMethod]
		public void ChangePassword_Post_ReturnsViewIfModelStateIsInvalid()
		{
			// Arrange
			AccountController controller = GetAccountController();
			ChangePasswordModel model = new ChangePasswordModel()
			{
				OldPassword = "goodOldPassword",
				NewPassword = "goodNewPassword",
				ConfirmPassword = "goodNewPassword"
			};
			controller.ModelState.AddModelError("", "Dummy error message.");

			// Act
			ActionResult result = controller.ChangePassword(model);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.AreEqual(model, viewResult.ViewData.Model);
			Assert.AreEqual(10, viewResult.ViewData["PasswordLength"]);
		}

		[TestMethod]
		public void ChangePasswordSuccess_ReturnsView()
		{
			// Arrange
			AccountController controller = GetAccountController();

			// Act
			ActionResult result = controller.ChangePasswordSuccess();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
		}

		[TestMethod]
		public void LogOff_LogsOutAndRedirects()
		{
			// Arrange
			AccountController controller = GetAccountController();

			var mock = new Mock<IFormsAuthenticationService>();
			//mock.Setup(s => s.SignIn("someUser", false));
			mock.Setup(s => s.SignOut());
			controller.FormsService = mock.Object;

			// Act
			ActionResult result = controller.LogOff();

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
			RedirectToRouteResult redirectResult = (RedirectToRouteResult)result;
			Assert.AreEqual("Home", redirectResult.RouteValues["controller"]);
			Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
			//Assert.IsTrue(((StubFormsAuthenticationService)controller.FormsService).SignOut_WasCalled);
			mock.VerifyAll();
		}

		[TestMethod]
		public void LogOn_Get_ReturnsView()
		{
			// Arrange
			AccountController controller = GetAccountController();

			// Act
			ActionResult result = controller.LogOn();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
		}

		[TestMethod]
		public void LogOn_Post_ReturnsRedirectOnSuccess_WithoutReturnUrl()
		{
			// Arrange
			AccountController controller = GetAccountController();
			LogOnModel model = new LogOnModel()
			{
				UserName = "someUser",
				Password = "goodPassword",
				RememberMe = false
			};

			// Act
			ActionResult result = controller.LogOn(model, null);

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
			RedirectToRouteResult redirectResult = (RedirectToRouteResult)result;
			Assert.AreEqual("Home", redirectResult.RouteValues["controller"]);
			Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
			Assert.IsTrue(((StubFormsAuthenticationService)controller.FormsService).SignIn_WasCalled);
		}

		[TestMethod]
		public void LogOn_Post_ReturnsRedirectOnSuccess_WithReturnUrl()
		{
			// Arrange
			AccountController controller = GetAccountController();
			LogOnModel model = new LogOnModel()
			{
				UserName = "someUser",
				Password = "goodPassword",
				RememberMe = false
			};

			// Act
			ActionResult result = controller.LogOn(model, "/someUrl");

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectResult));
			RedirectResult redirectResult = (RedirectResult)result;
			Assert.AreEqual("/someUrl", redirectResult.Url);
			Assert.IsTrue(((StubFormsAuthenticationService)controller.FormsService).SignIn_WasCalled);
		}

		[TestMethod]
		public void LogOn_Post_ReturnsViewIfModelStateIsInvalid()
		{
			// Arrange
			AccountController controller = GetAccountController();
			LogOnModel model = new LogOnModel()
			{
				UserName = "someUser",
				Password = "goodPassword",
				RememberMe = false
			};
			controller.ModelState.AddModelError("", "Dummy error message.");

			// Act
			ActionResult result = controller.LogOn(model, null);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.AreEqual(model, viewResult.ViewData.Model);
		}

		[TestMethod]
		public void LogOn_Post_ReturnsViewIfValidateUserFails()
		{
			// Arrange
			AccountController controller = GetAccountController();
			LogOnModel model = new LogOnModel()
			{
				UserName = "someUser",
				Password = "badPassword",
				RememberMe = false
			};

			// Act
			ActionResult result = controller.LogOn(model, null);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.AreEqual(model, viewResult.ViewData.Model);
			Assert.AreEqual("The user name or password provided is incorrect.", controller.ModelState[""].Errors[0].ErrorMessage);
		}

		[TestMethod]
		public void Register_Get_ReturnsView()
		{
			// Arrange
			AccountController controller = GetAccountController();

			// Act
			ActionResult result = controller.Register();

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			Assert.AreEqual(10, ((ViewResult)result).ViewData["PasswordLength"]);
		}

		[TestMethod]
		public void Register_Post_ReturnsRedirectOnSuccess()
		{
			// Arrange
			AccountController controller = GetAccountController();
			//RegisterModel model = new RegisterModel()
			//{
			//  UserName = "someUser",
			//  Email = "goodEmail",
			//  Password = "goodPassword",
			//  ConfirmPassword = "goodPassword"
			//};

			var model = new RegisterModelBuilder().
				withUserName("someUser").
				withEmail("goodEmail").
				withPassword("goodPassword").
				withConfirmPassword("goodPassword").build();

			// Act
			ActionResult result = controller.Register(model);

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
			RedirectToRouteResult redirectResult = (RedirectToRouteResult)result;
			Assert.AreEqual("Home", redirectResult.RouteValues["controller"]);
			Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
		}

		[TestMethod]
		public void Register_Post_ReturnsViewIfRegistrationFails()
		{
			// Arrange
			AccountController controller = GetAccountController();
			RegisterModel model = new RegisterModel()
			{
				UserName = "duplicateUser",
				Email = "goodEmail",
				Password = "goodPassword",
				ConfirmPassword = "goodPassword"
			};

			// Act
			ActionResult result = controller.Register(model);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.AreEqual(model, viewResult.ViewData.Model);
			Assert.AreEqual("Username already exists. Please enter a different user name.", controller.ModelState[""].Errors[0].ErrorMessage);
			Assert.AreEqual(10, viewResult.ViewData["PasswordLength"]);
		}

		[TestMethod]
		public void Register_Post_ReturnsViewIfModelStateIsInvalid()
		{
			// Arrange
			AccountController controller = GetAccountController();
			RegisterModel model = new RegisterModel()
			{
				UserName = "someUser",
				Email = "goodEmail",
				Password = "goodPassword",
				ConfirmPassword = "goodPassword"
			};
			controller.ModelState.AddModelError("", "Dummy error message.");

			// Act
			ActionResult result = controller.Register(model);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.AreEqual(model, viewResult.ViewData.Model);
			Assert.AreEqual(10, viewResult.ViewData["PasswordLength"]);
		}

		private static AccountController GetAccountController()
		{
			AccountController controller = new AccountController()
			{
				FormsService = new StubFormsAuthenticationService(),
				MembershipService = new FakeMembershipService()
			};
			controller.ControllerContext = new ControllerContext()
			{
				Controller = controller,
				RequestContext = new RequestContext(new FakeHttpContext(), new RouteData())
			};
			return controller;
		}

		// Mocks y Stubs: MockFormsAuthenticationService
		private class StubFormsAuthenticationService : IFormsAuthenticationService
		{
			public bool SignIn_WasCalled;
			public bool SignOut_WasCalled;

			public void SignIn(string userName, bool createPersistentCookie)
			{
				// verify that the arguments are what we expected
				Assert.AreEqual("someUser", userName);
				Assert.IsFalse(createPersistentCookie);

				SignIn_WasCalled = true;
			}

			public void SignOut()
			{
				SignOut_WasCalled = true;
			}
		}

		private class FakeHttpContext : HttpContextBase
		{
			private readonly IPrincipal _user = new GenericPrincipal(new GenericIdentity("someUser"), null /* roles */);

			public override IPrincipal User
			{
				get { return _user; }
				set { base.User = value; }
			}
		}

		private class FakeMembershipService : IMembershipService
		{
			public int MinPasswordLength
			{
				get { return 10; }
			}

			public bool ValidateUser(string userName, string password)
			{
				return (userName == "someUser" && password == "goodPassword");
			}

			public MembershipCreateStatus CreateUser(string userName, string password, string email)
			{
				if (userName == "duplicateUser")
				{
					return MembershipCreateStatus.DuplicateUserName;
				}

				// verify that values are what we expected
				Assert.AreEqual("goodPassword", password);
				Assert.AreEqual("goodEmail", email);

				return MembershipCreateStatus.Success;
			}

			public bool ChangePassword(string userName, string oldPassword, string newPassword)
			{
				return (userName == "someUser" && oldPassword == "goodOldPassword" && newPassword == "goodNewPassword");
			}
		}

	}
}