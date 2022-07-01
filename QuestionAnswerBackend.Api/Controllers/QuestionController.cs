using Microsoft.AspNetCore.Mvc;
using QuestionAnswerBackend.Api.Base;
using QuestionAnswerBackend.Business.Businesses;
using QuestionAnswerBackend.Business.Contract;
using QuestionAnswerBackend.Common.ViewModels;
using QuestionAnswerBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAnswerBackend.Api.Controllers;

public class QuestionController : BaseController<Question>
{
	private readonly QuestionBusiness? _questionBusiness;

	public QuestionController(QuestionBusiness questionBusiness) : base(questionBusiness) =>

	_questionBusiness = questionBusiness;

    [HttpPut("UpvoteQuestion")]
    public async Task<ActionResult> UpvoteQuestion(int QuestionId, CancellationToken cancellationToken)
    {
        await _questionBusiness!.UpvoteQuestion(QuestionId, cancellationToken);
        return Ok();
    }

    [HttpPut("DownvoteQuestion")]
    public async Task<ActionResult> DownvoteQuestion(int QuestionId, CancellationToken cancellationToken)
    {
        await _questionBusiness!.DownvoteQuestion(QuestionId, cancellationToken);
        return Ok();
    }
}
