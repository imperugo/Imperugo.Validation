namespace Ninject
{
	using Imperugo.Validation.Ninject.Interceptor;

	using Ninject.Extensions.Interception.Advice.Syntax;
	using Ninject.Extensions.Interception.Infrastructure.Language;

	public static class ValidationExtensions
	{
		#region Public Methods and Operators

		public static IAdviceOrderSyntax EnableValidation<T>(this IKernel kernel) where T : class
		{
			return kernel.Bind<T>().ToSelf().Intercept().With<ValidationInterceptor>();
		}

		#endregion
	}
}