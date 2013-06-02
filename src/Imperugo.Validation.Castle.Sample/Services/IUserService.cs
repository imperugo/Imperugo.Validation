namespace Imperugo.Validation.Caslte.Sample.Services
{
	using System.ComponentModel.DataAnnotations;
	using System.Text.RegularExpressions;

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
		public string Url { get; set; }

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