namespace Imperugo.Validation.Common.Validator
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public interface IObjectValidator
	{
		#region Public Methods and Operators

		bool TryValidate(object @object, out ICollection<ValidationResult> results);

		void Validate(object @object);

		#endregion
	}
}