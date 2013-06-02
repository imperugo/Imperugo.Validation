namespace Imperugo.Validation.Common.Attributes
{
	using System;

	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public class ValidateAttribute : Attribute
	{
	}
}