using QuestionAnswerBackend.DataAccess.Context;
using QuestionAnswerBackend.DataAccess.Contracts;
using QuestionAnswerBackend.DataAccess.Repositories;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAnswerBackend.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
		private PersonRepository? _personRepository;

		private RoleRepository? _roleRepository;

		private UserRepository? _userRepository;

		private UserRoleRepository? _userRoleRepository;

		private QuestionRepository? _questionRepository;

		private AnswerRepository? _answerRepository;

		private CommentQuestionRepository? _commentQuestionRepository;

		private CommentAnswerRepository? _commentAnswerRepository;

		private readonly QuestionAnswerBackendContext _QAContext;

		private readonly ISieveProcessor _sieveProcessor;

		public UnitOfWork(QuestionAnswerBackendContext context, ISieveProcessor sieveProcessor)
		{
			_QAContext = context;
			_sieveProcessor = sieveProcessor;
		}

		public PersonRepository PersonRepository =>
			_personRepository ??= new PersonRepository(_QAContext, _sieveProcessor);

		public RoleRepository RoleRepository =>
			_roleRepository ??= new RoleRepository(_QAContext, _sieveProcessor);

		public UserRepository UserRepository =>
			_userRepository ??= new UserRepository(_QAContext, _sieveProcessor);

		public UserRoleRepository UserRoleRepository =>
			_userRoleRepository ??= new UserRoleRepository(_QAContext, _sieveProcessor);

		public QuestionRepository QuestionRepository =>
			_questionRepository ??= new QuestionRepository(_QAContext, _sieveProcessor);

		public AnswerRepository AnswerRepository =>
			_answerRepository ??= new AnswerRepository(_QAContext, _sieveProcessor);

		public CommentQuestionRepository CommentQuestionRepository =>
			_commentQuestionRepository ??= new CommentQuestionRepository(_QAContext, _sieveProcessor);

		public CommentAnswerRepository CommentAnswerRepository =>
			_commentAnswerRepository ??= new CommentAnswerRepository(_QAContext, _sieveProcessor);

		public int Commit() =>
			_QAContext.SaveChanges();

		public async Task<int> CommitAsync(CancellationToken cancellationToken) =>
			await _QAContext.SaveChangesAsync(cancellationToken);
	}
}
