using FluentValidation;
using QuestionAnswerBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAnswerBackend.Common.Validations;

public class UserValidator : AbstractValidator<User>
{
	public UserValidator()
	{
		RuleFor(x => x.Username).NotEmpty().MaximumLength(20).MinimumLength(8);
		RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
	}
}