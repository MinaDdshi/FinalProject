using FluentValidation;
using QuestionAnswerBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAnswerBackend.Common.Validations;

public class PersonValidator : AbstractValidator<Person>
{
	public PersonValidator()
	{
		RuleFor(x => x.Name).NotEmpty().MaximumLength(20);
		RuleFor(x => x.Family).NotEmpty().MaximumLength(20);
	}
}