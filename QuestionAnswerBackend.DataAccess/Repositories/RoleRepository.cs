using Microsoft.EntityFrameworkCore;
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

public class RoleRepository : BaseRepository<Role>
{
	private readonly QuestionAnswerBackendContext _context;

	public RoleRepository(QuestionAnswerBackendContext context, ISieveProcessor sieveProcessor) : base(context, sieveProcessor) =>
		_context = context;

	public async Task<List<Role?>> LoadByUserIdAsync(int userId, CancellationToken cancellationToken = new()) =>
		await _context.UserRoles!
			.Where(x => x.UserId == userId)
			.Include(x => x.Role)
			.Select(x => x.Role)
			.ToListAsync(cancellationToken);
}
