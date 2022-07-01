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

public class AnswerRepository : BaseRepository<Answer>
{
    private readonly QuestionAnswerBackendContext _context;

    public AnswerRepository(QuestionAnswerBackendContext context, ISieveProcessor sieveProcessor) : base(context, sieveProcessor) =>
        _context = context;

    public async Task UpvoteAnswer(int AnswerId)
    {
        var answer = _context.Answers!.FirstOrDefault(x => x.Id == AnswerId);
        answer!.Upvote = answer.Upvote + 1;
        await Task.FromResult(_context.Answers!.Update(answer));
    }

    public async Task DownvoteAnswer(int AnswerId)
    {
        var answer = _context.Answers!.FirstOrDefault(x => x.Id == AnswerId);
        answer!.Downvote = answer.Downvote + 1;
        await Task.FromResult(_context.Answers!.Update(answer));
    }

    public async Task IsCorrectAnswer(int AnswerId)
    {
        var answer = _context.Answers!.FirstOrDefault(x => x.Id == AnswerId);
        answer!.IsCorrectAnswer = true;
        await Task.FromResult(_context.Answers!.Update(answer));
    }
} 
