using QuestionAnswerBackend.Common.ViewModels;
using QuestionAnswerBackend.Model;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAnswerBackend.Business.Contract;

public interface IBaseBusiness<T> where T : BaseEntity
{
	Task<SamanSalamatResponse?> CreateAsync(T t, CancellationToken cancellationToken);

	Task<SamanSalamatResponse<List<T>>?> LoadAllAsync(SieveModel sieveModel, CancellationToken cancellationToken);

	Task<SamanSalamatResponse?> UpdateAsync(T t, CancellationToken cancellationToken);

	Task<SamanSalamatResponse?> DeleteAsync(int id, CancellationToken cancellationToken);
}
