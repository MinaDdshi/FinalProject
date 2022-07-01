using Microsoft.AspNetCore.Mvc;
using QuestionAnswerBackend.Api.Base;
using QuestionAnswerBackend.Business.Businesses;
using QuestionAnswerBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAnswerBackend.Api.Controllers;

public class AnswerController : BaseController<Answer>
{
    private readonly AnswerBusiness? _answerBusiness;

    public AnswerController(AnswerBusiness answerBusiness) : base(answerBusiness) =>

    _answerBusiness = answerBusiness;

    [HttpPut("UpvoteAnswer")]
    public async Task<ActionResult> UpvoteAnswer(int AnswerId, CancellationToken cancellationToken)
    {
        await _answerBusiness!.UpvoteAnswer(AnswerId, cancellationToken);
        return Ok();
    }

    [HttpPut("DownvoteAnswer")]
    public async Task<ActionResult> DownvoteAnswer(int AnswerId, CancellationToken cancellationToken)
    {
        await _answerBusiness!.DownvoteAnswer(AnswerId, cancellationToken);
        return Ok();
    }

    [HttpPut("IsCorrectAnswer")]
    public async Task<ActionResult> IsCorrectAnswer(int AnswerId, CancellationToken cancellationToken)
    {
        await _answerBusiness!.IsCorrectAnswer(AnswerId, cancellationToken);
        return Ok();
    }
}
