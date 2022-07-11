using QuestionAnswerBackend.DataAccess.Context;
using QuestionAnswerBackend.Model;
using Sieve.Services;

namespace QuestionAnswerBackend.Test.Integration;

public class DummyDataDBInitializer
{
    public void Seed(QuestionAnswerBackendContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        context.Questions?.AddRange(
            new Question() { UserId = 1, QuestionContent = "This is a Question", Upvote = 1, Downvote = 1, RankQuestion = 50, RankUser = 50 },
            new Question() { UserId = 1, QuestionContent = "This is a Question", Upvote = 1, Downvote = 1, RankQuestion = 50, RankUser = 50 },
            new Question() { UserId = 1, QuestionContent = "This is a Question", Upvote = 1, Downvote = 1, RankQuestion = 50, RankUser = 50 },
            new Question() { UserId = 1, QuestionContent = "This is a Question", Upvote = 1, Downvote = 1, RankQuestion = 50, RankUser = 50 }
        );
        context.SaveChanges();
    }
}
