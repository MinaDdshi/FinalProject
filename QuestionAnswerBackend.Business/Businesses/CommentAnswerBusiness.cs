using QuestionAnswerBackend.Business.Base;
using QuestionAnswerBackend.DataAccess.Contracts;
using QuestionAnswerBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAnswerBackend.Business.Businesses;

public class CommentAnswerBusiness : BaseBusiness<CommentAnswer>
{
	public CommentAnswerBusiness(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.CommentAnswerRepository!)
	{
	}
}

