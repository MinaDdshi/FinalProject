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

public class PersonRepository : BaseRepository<Person>
{
    public PersonRepository(QuestionAnswerBackendContext context, ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
    {
    }
}
