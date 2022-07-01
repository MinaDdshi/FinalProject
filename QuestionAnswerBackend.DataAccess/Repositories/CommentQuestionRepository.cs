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

public class CommentQuestionRepository : BaseRepository<CommentQuestion>
{
    public CommentQuestionRepository(QuestionAnswerBackendContext context, ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
    {
    }
}