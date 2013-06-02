namespace Imperugo.Validation.Castle.Test.Helpers
{
	using System.ComponentModel.DataAnnotations;

	using Imperugo.Validation.Common.Attributes;

	public class CreateUserRequest
	{
		#region Public Properties

		[Required]
		public string Username { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Url]
		public string Website { get; set; }

		#endregion
	}

	public interface IUserService
	{
		void CreateUser([Validate] CreateUserRequest request);
	}

	public class UserService : IUserService
	{
		public void CreateUser(CreateUserRequest request)
		{
			//DO SOMETHING
		}
	}
}