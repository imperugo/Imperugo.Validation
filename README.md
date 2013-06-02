## Welcome to Imperugo.Validation ##

**Imperugo.Validation** is a free and open source project framework for input validation. It is totally developed with Microsoft technologies and released under [Microsoft Public License (Ms-PL)](https://github.com/imperugo/Imperugo.Validation/blob/master/doc/License.txt).

### How does it work ###

It is really simple. It's based on AOP (Aspect Oriented Programming) and it is based on [Interceptor Pattern](http://en.wikipedia.org/wiki/Interceptor_pattern "Interceptor Pattern"). 
For this reason there are two different packages:

- **Commons** that includes rules validations, exception and son on;
- **Castle Package** that use Castle Windsor for validation.


### Sample ###

Install the framework from NuGet:

> PM>Install-Package Imperugo.Valdation.Castle

Create your validation class and services

```c#
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
```

Enable Castle to validate

```c#
IWindsorContainer container = new WindsorContainer();

container.InizializeAttributeValidation();

container.Register(Component.For<IUserService>()
				.ImplementedBy<UserService>()
				.EnableValidation());


```

That's all

### How to Contribute ###

As all Open Source Project, here we need some helps. If you are using a different Dependency Injection framework and you like this validation, Please Fork the repo, add your framework and create e "Pull Request".
I'll be happy to accept that and create the right NuGet Packages.

### Staff ###
Do you want to know more about me?
Click [here](http://tostring.it)!