using Microsoft.EntityFrameworkCore;
using QuestionAnswerBackend.DataAccess.Context;
using QuestionAnswerBackend.DataAccess.Repositories;

namespace QuestionAnswerBackend.Test.Integration;

public class QuestionAnswerBackendTestController
{
    private QuestionRepository? repository;
    public static DbContextOptions<QuestionAnswerBackendContext> dbContextOptions { get; }
    public static string connectionString = "Server=.;Database=QuestionAnswerBackendTest";

    static QuestionAnswerBackendTestController()
    {
        dbContextOptions = new DbContextOptionsBuilder<QuestionAnswerBackendContext>()
            .UseSqlServer(connectionString)
            .Options;
    }
    public QuestionAnswerBackendTestController()
    {
        var context = new QuestionAnswerBackendContext(dbContextOptions);
        DummyDataDBInitializer db = new DummyDataDBInitializer();
        db.Seed(context);

        repository = new QuestionRepository(context);

    }
}