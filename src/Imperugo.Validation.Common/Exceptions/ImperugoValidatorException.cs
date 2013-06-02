namespace Imperugo.Validation.Common.Exceptions
{
	using System;

	/// <summary>
	/// The base exception for object validation.
	/// </summary>
	public class ImperugoValidatorException : ApplicationException
	{
		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="v"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="parameterName">Name of the parameter.</param>
		public ImperugoValidatorException(string message, string parameterName)
			: base(message)
		{
			this.ParameterName = parameterName;
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets the name of the parameter.
		/// </summary>
		/// <value>
		/// The name of the parameter.
		/// </value>
		public string ParameterName { get; private set; }

		#endregion
	}
}