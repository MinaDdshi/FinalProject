using QuestionAnswerBackend.DataAccess.Base;
using QuestionAnswerBackend.DataAccess.Context;
using QuestionAnswerBackend.Model;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAnswerBackend.DataAccess.Repositories;

public class QuestionRepository : BaseRepository<Question>
{
    private readonly QuestionAnswerBackendContext _context;

    public QuestionRepository(QuestionAnswerBackendContext context, ISieveProcessor sieveProcessor) : base(context, sieveProcessor) =>
        _context = context;

    public async Task UpvoteQuestion(int QuestionId)
    {
        var question = _context.Questions!.FirstOrDefault(x => x.Id == QuestionId);
        question!.Upvote = question.Upvote + 1;
        await Task.FromResult(_context.Questions!.Update(question));
    }

    public async Task DownvoteQuestion(int QuestionId)
    {
        var question = _context.Questions!.FirstOrDefault(x => x.Id == QuestionId);
        question!.Downvote = question.Downvote + 1;
        await Task.FromResult(_context.Questions!.Update(question));
    }
}
