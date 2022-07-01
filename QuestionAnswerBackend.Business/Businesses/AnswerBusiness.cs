using QuestionAnswerBackend.Business.Base;
using QuestionAnswerBackend.Common.ViewModels;
using QuestionAnswerBackend.DataAccess.Contracts;
using QuestionAnswerBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAnswerBackend.Business.Businesses;

public class AnswerBusiness : BaseBusiness<Answer>
{
	private readonly IUnitOfWork _unitOfWork;

	public AnswerBusiness(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.AnswerRepository!) =>
		_unitOfWork = unitOfWork;

	public async Task<SamanSalamatResponse?> UpvoteAnswer(int AnswerId, CancellationToken cancellationToken)
	{
		await _unitOfWork.AnswerRepository!.UpvoteAnswer(AnswerId);
		await _unitOfWork.CommitAsync(cancellationToken);
		return new SamanSalamatResponse
		{
			IsSuccess = true,
			ChangedId = AnswerId,
			Message = "Upvote Changed"
		};
	}

	public async Task<SamanSalamatResponse?> DownvoteAnswer(int AnswerId, CancellationToken cancellationToken)
	{
		await _unitOfWork.AnswerRepository!.DownvoteAnswer(AnswerId);
		await _unitOfWork.CommitAsync(cancellationToken);
		return new SamanSalamatResponse
		{
			IsSuccess = true,
			ChangedId = AnswerId,
			Message = "Downvote Changed"
		};
	}

	public async Task<SamanSalamatResponse?> IsCorrectAnswer(int AnswerId, CancellationToken cancellationToken)
	{
		await _unitOfWork.AnswerRepository!.IsCorrectAnswer(AnswerId);
		await _unitOfWork.CommitAsync(cancellationToken);
		return new SamanSalamatResponse
		{
			IsSuccess = true,
			ChangedId = AnswerId,
			Message = "Downvote Changed"
		};
	}
}
