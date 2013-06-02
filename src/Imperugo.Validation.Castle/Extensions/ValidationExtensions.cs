namespace Castle.Windsor
{
	using Imperugo.Valdation.Castle.Interceptor;

	using global::Castle.DynamicProxy;

	using global::Castle.MicroKernel.Registration;

	using global::Castle.Windsor;

	public static class ValidationExtensions
	{
		#region Public Methods and Operators

		public static ComponentRegistration<T> EnableValidation<T>(this ComponentRegistration<T> component) where T : class
		{
			return component.Interceptors<ValidationInterceptor>();
		}

		public static void InizializeAttributeValidation(this IWindsorContainer container)
		{
			container.Register(Component.For<IInterceptor>().ImplementedBy<ValidationInterceptor>());
		}

		#endregion
	}
}