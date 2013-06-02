namespace Imperugo.Validation.Castle.Test
{
	using System;

	using Imperugo.Validation.Common.Exceptions;

	using global::Castle.MicroKernel.Registration;

	using global::Castle.Windsor;

	using Imperugo.Validation.Castle.Test.Helpers;

	using SharpTestsEx;

	using Xunit;

	public class ValidationTest : IDisposable
	{
		#region Fields

		private readonly IWindsorContainer container;

		private readonly IUserService sut;

		#endregion

		#region Constructors and Destructors

		public ValidationTest()
		{
			this.container = new WindsorContainer();

			this.container.InizializeAttributeValidation();

			this.container.Register(Component.For<IUserService>().ImplementedBy<UserService>().EnableValidation());

			this.sut = this.container.Resolve<IUserService>();
		}

		#endregion

		#region Public Methods and Operators

		[Fact]
		public void CallMethod_WithAllValidInput_ShouldNotThrowException()
		{
			var request = new CreateUserRequest();
			request.Username = "imperugo";
			request.Email = "imperugo@gmail.com";

			Executing.This(() => this.sut.CreateUser(request))
						.Should()
						.NotThrow();
		}

		[Fact]
		public void CallMethod_WithNullUsername_ShouldNotThrowImperugoValidatorException()
		{
			var request = new CreateUserRequest();
			request.Username = null;
			request.Email = "imperugo@gmail.com";
			request.Website = "http://www.tostring.it";

			Executing.This(() => this.sut.CreateUser(request))
						.Should()
						.Throw<ImperugoValidatorException>()
						.And
						.Exception
						.ParameterName
						.Should()
						.Be
						.EqualTo("Username");
		}

		[Fact]
		public void CallMethod_WithInvalidOptionParamenter_ShouldNotThrowImperugoValidatorException()
		{
			var request = new CreateUserRequest();
			request.Username = "imperugo";
			request.Email = "imperugo@gmail.com";
			request.Website = "this is a wrong url";

			Executing.This(() => this.sut.CreateUser(request))
						.Should()
						.Throw<ImperugoValidatorException>()
						.And
						.Exception
						.ParameterName
						.Should()
						.Be
						.EqualTo("Website");
		}

		public void Dispose()
		{
			this.container.Dispose();
		}

		#endregion
	}
}