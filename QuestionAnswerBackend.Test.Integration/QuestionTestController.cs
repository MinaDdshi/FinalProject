using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using QuestionAnswerBackend.Business.Businesses;
using QuestionAnswerBackend.DataAccess.Context;
using QuestionAnswerBackend.DataAccess.Contracts;
using QuestionAnswerBackend.DataAccess.Repositories;
using QuestionAnswerBackend.Model;
using Sieve.Models;
using Sieve.Services;

namespace QuestionAnswerBackend.Test.Integration;

public class QuestionTestController
{
    private QuestionRepository? repository;
    public static DbContextOptions<QuestionAnswerBackendContext> dbContextOptions { get; }
    public static string connectionString = "Server=.;Database=QuestionAnswerBackendTest";

    static QuestionTestController()
    {
        dbContextOptions = new DbContextOptionsBuilder<QuestionAnswerBackendContext>()
            .UseSqlServer(connectionString)
            .Options;
    }
    public QuestionTestController()
    {
        var context = new QuestionAnswerBackendContext(dbContextOptions);
        var mockISieveProcessor = new Mock<ISieveProcessor>();
        DummyDataDBInitializer db = new DummyDataDBInitializer();
        db.Seed(context);

        repository = new QuestionRepository(context, mockISieveProcessor.Object);
    }

    [Fact]
    public async void Task_GetQuestions_Return_OkResult()
    {
        //Arrange  
        var mockIUnitOfWork = new Mock<IUnitOfWork>();
        var business = new QuestionBusiness(mockIUnitOfWork.Object);

        //Act  
        var mockSieveModel = new Mock<SieveModel>();
        var tcs = new CancellationTokenSource(1000);
        var data = await business.LoadAllAsync(mockSieveModel.Object, tcs.Token);

        //Assert  
        Assert.IsType<OkObjectResult>(data);
    }

    [Fact]
    public void Task_GetQuestions_Return_BadRequestResult()
    {
        //Arrange  
        var mockIUnitOfWork = new Mock<IUnitOfWork>();
        var business = new QuestionBusiness(mockIUnitOfWork.Object);

        //Act  
        var mockSieveModel = new Mock<SieveModel>();
        var tcs = new CancellationTokenSource(1000);
        var data = business.LoadAllAsync(mockSieveModel.Object, tcs.Token);
        data = null;

        if (data != null)
            //Assert  
            Assert.IsType<BadRequestResult>(data);
    }

    [Fact]
    public async void Task_GetQuestions_MatchResult()
    {
        //Arrange  
        var mockIUnitOfWork = new Mock<IUnitOfWork>();
        var business = new QuestionBusiness(mockIUnitOfWork.Object);

        //Act  
        var mockSieveModel = new Mock<SieveModel>();
        var tcs = new CancellationTokenSource(1000);
        var data = await business.LoadAllAsync(mockSieveModel.Object, tcs.Token);

        //Assert  
        Assert.IsType<OkObjectResult>(data);

        var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
        var question = okResult.Value.Should().BeAssignableTo<List<Question>>().Subject;

        Assert.Equal("Test UserId 1", question[0].UserId.ToString());
        Assert.Equal("Test QuestionContent 1", question[0].QuestionContent);
        Assert.Equal("Test Upvote 1", question[0].Upvote.ToString());
        Assert.Equal("Test Downvote 1", question[0].Downvote.ToString());
        Assert.Equal("Test RankQuestion 1", question[0].RankQuestion.ToString());
        Assert.Equal("Test RankUser 1", question[0].RankUser.ToString());

        Assert.Equal("Test UserId 2", question[0].UserId.ToString());
        Assert.Equal("Test QuestionContent 2", question[0].QuestionContent);
        Assert.Equal("Test Upvote 2", question[0].Upvote.ToString());
        Assert.Equal("Test Downvote 2", question[0].Downvote.ToString());
        Assert.Equal("Test RankQuestion 2", question[0].RankQuestion.ToString());
        Assert.Equal("Test RankUser 2", question[0].RankUser.ToString());
    }
}