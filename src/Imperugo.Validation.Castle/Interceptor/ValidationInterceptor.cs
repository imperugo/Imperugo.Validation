namespace Imperugo.Valdation.Castle.Interceptor
{
	using System.Reflection;

	using Imperugo.Validation.Common.Attributes;
	using Imperugo.Validation.Common.Validator;

	using global::Castle.DynamicProxy;

	public class ValidationInterceptor : IInterceptor
	{
		#region Fields

		private readonly IObjectValidator validator;

		#endregion

		#region Constructors and Destructors

		public ValidationInterceptor() : this(new DataAnnotationsValidator())
		{
		}

		public ValidationInterceptor(IObjectValidator validator)
		{
			this.validator = validator;
		}

		#endregion

		#region Public Methods and Operators

		public void Intercept(IInvocation invocation)
		{
			ParameterInfo[] parameters = invocation.Method.GetParameters();
			for (int index = 0; index < parameters.Length; index++)
			{
				ParameterInfo paramInfo = parameters[index];
				object[] attributes = paramInfo.GetCustomAttributes(typeof(ValidateAttribute), false);

				if (attributes.Length == 0)
				{
					continue;
				}

				this.validator.Validate(invocation.Arguments[index]);
			}

			invocation.Proceed();
		}

		#endregion
	}
}