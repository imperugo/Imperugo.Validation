namespace Imperugo.Validation.Caslte.Sample
{
	using System;

	using Castle.MicroKernel.Registration;
	using Castle.Windsor;

	using Imperugo.Validation.Caslte.Sample.Services;
	using Imperugo.Validation.Common.Exceptions;

	internal class Program
	{
		#region Methods

		private static void Main(string[] args)
		{
			IWindsorContainer container = new WindsorContainer();

			container.InizializeAttributeValidation();

			container.Register(Component.For<IUserService>()
												.ImplementedBy<UserService>()
												.EnableValidation());

			IUserService userService = container.Resolve<IUserService>();

			try
			{
				userService.CreateUser(new CreateUserRequest());
			}
			catch (ImperugoValidatorException e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				Console.ReadLine();
			}
		}

		#endregion
	}
}