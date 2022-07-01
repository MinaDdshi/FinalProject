using FluentValidation;
using QuestionAnswerBackend.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAnswerBackend.Common.Validations;

public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
{
	public LoginViewModelValidator()
	{
		RuleFor(x => x.Username).NotEmpty().MaximumLength(20).MinimumLength(5);
		RuleFor(x => x.Password).NotEmpty().MinimumLength(5);
	}
}