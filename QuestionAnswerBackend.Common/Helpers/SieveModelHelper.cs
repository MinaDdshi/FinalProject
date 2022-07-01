using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAnswerBackend.Common.Helpers;

public static class SieveModelValidator
{
	public static SieveModel Validate(this SieveModel sieveModel)
	{
		sieveModel.Page ??= 1;
		sieveModel.PageSize ??= 10;
		if (string.IsNullOrWhiteSpace(sieveModel.Sorts))
			sieveModel.Sorts = "-id";
		if (sieveModel.PageSize > 100) sieveModel.PageSize = 10;
		return sieveModel;
	}
}