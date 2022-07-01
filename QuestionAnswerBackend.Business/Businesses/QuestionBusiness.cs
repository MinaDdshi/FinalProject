using QuestionAnswerBackend.Business.Base;
using QuestionAnswerBackend.Business.Contract;
using QuestionAnswerBackend.Common.ViewModels;
using QuestionAnswerBackend.DataAccess.Contracts;
using QuestionAnswerBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAnswerBackend.Business.Businesses;

public class QuestionBusiness : BaseBusiness<Question>
{
	private readonly IUnitOfWork _unitOfWork;

	public QuestionBusiness(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.QuestionRepository!) =>
		_unitOfWork = unitOfWork;

	public async Task<SamanSalamatResponse?> UpvoteQuestion(int QuestionId, CancellationToken cancellationToken)
	{
		await _unitOfWork.QuestionRepository!.UpvoteQuestion(QuestionId);
		await _unitOfWork.CommitAsync(cancellationToken);
		return new SamanSalamatResponse
		{
			IsSuccess = true,
			ChangedId = QuestionId,
			Message = "Upvote Changed"
		};
	}

	public async Task<SamanSalamatResponse?> DownvoteQuestion(int QuestionId, CancellationToken cancellationToken)
	{
		await _unitOfWork.QuestionRepository!.DownvoteQuestion(QuestionId);
		await _unitOfWork.CommitAsync(cancellationToken);
		return new SamanSalamatResponse
		{
			IsSuccess = true,
			ChangedId = QuestionId,
			Message = "Downvote Changed"
		};
	}
}
	