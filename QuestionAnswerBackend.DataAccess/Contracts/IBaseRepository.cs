using Microsoft.EntityFrameworkCore.Query;
using QuestionAnswerBackend.Model;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAnswerBackend.DataAccess.Contracts;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T> CreateAsync(T t, CancellationToken cancellationToken);

    Task<List<T>> LoadAllAsync(SieveModel sieveModel, Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null, CancellationToken cancellationToken = new());

    Task<T> UpdateAsync(T t, CancellationToken cancellationToken);

    Task<T> DeleteAsync(T t, CancellationToken cancellationToken);

    Task<T> DeleteAsync(int id, CancellationToken cancellationToken);
}
