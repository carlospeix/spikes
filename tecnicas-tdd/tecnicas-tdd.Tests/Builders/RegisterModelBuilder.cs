
using tecnicas_tdd.Models;
namespace tecnicas_tdd.Tests.Builders
{
	public class RegisterModelBuilder
	{
		string userName;
		string email;
		string password;
		string confirmPassword;

		public RegisterModelBuilder withUserName(string userName)
		{
			this.userName = userName;
			return this;
		}

		public RegisterModelBuilder withEmail(string email)
		{
			this.email = email;
			return this;
		}

		public RegisterModelBuilder withPassword(string password)
		{
			this.password = password;
			return this;
		}

		public RegisterModelBuilder withConfirmPassword(string confirmPassword)
		{
			this.confirmPassword = confirmPassword;
			return this;
		}

		public RegisterModel build()
		{
			return new RegisterModel()
									{
										UserName = userName,
										Email = email,
										Password = password,
										ConfirmPassword = confirmPassword
									};
		}
	}

	//var model = new RegisterModelBuilder().
	//  withUserName("someUser").
	//  withEmail("goodEmail").
	//  withPassword("goodPassword").
	//  withConfirmPassword("goodPassword").build();
}