using Microsoft.EntityFrameworkCore;
using QuestionAnswerBackend.Common.Helpers;
using QuestionAnswerBackend.Model;
using QuestionAnswerBackend.Model.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAnswerBackend.DataAccess.Context;

public class QuestionAnswerBackendContext : DbContext
{
    public QuestionAnswerBackendContext(DbContextOptions options) : base(options) { }

    public DbSet<Role>? Roles { get; set; }

    public DbSet<User>? Users { get; set; }

    public DbSet<Person>? Persons { get; set; }

    public DbSet<UserRole>? UserRoles { get; set; }

    public DbSet<Question>? Questions { get; set; }

    public DbSet<Answer>? Answers { get; set; }

    public DbSet<CommentQuestion>? CommentQuestions { get; set; }

    public DbSet<CommentAnswer>? CommentAnswers { get; set; }

    public DbSet<QuestionView>? QuestionViews { get; set; }

    public DbSet<AnswerView>? AnswerViews { get; set; }

    public DbSet<CommentQuestionView>? CommentQuestionViews { get; set; }

    public DbSet<CommentAnswerView>? CommentAnswerViews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserRolesView>().ToView(nameof(UserRolesView)).HasNoKey();

        modelBuilder.Entity<QuestionView>().ToView(nameof(QuestionView)).HasNoKey();

        modelBuilder.Entity<AnswerView>().ToView(nameof(AnswerView)).HasNoKey();

        modelBuilder.Entity<CommentQuestionView>().ToView(nameof(CommentQuestionView)).HasNoKey();

        modelBuilder.Entity<CommentAnswerView>().ToView(nameof(CommentAnswerView)).HasNoKey();

        modelBuilder.Entity<Role>().HasData(new List<Role>
        {
            new()
            {
                Id = 1,
                Title = "Admin",
                Description = "Admin of Application"
            },
            new()
            {
                Id = 2,
                Title = "User",
                Description = "User of Application"
            },
            new()
            {
                Id = 3,
                Title = "User",
                Description = "User of Application"
            }
        });

        modelBuilder.Entity<Person>().HasData(new List<Person>
        {
            new()
            {
                Id = 1,
                Name = "Mina",
                Family = "Dadashi"
            },
            new()
            {
                Id = 2,
                Name = "Mahsa",
                Family = "Mousavi"
            },
            new()
            {
                Id = 3,
                Name = "Zahra",
                Family = "Abedi"
            }
        });

        modelBuilder.Entity<User>().HasData(new List<User>
        {
            new()
            {
                Id = 1,
                Username = "admin",
                Password = "admin".GetHashStringAsync().Result,
                PersonId = 1
            },
            new()
            {
                Id = 2,
                Username = "m.mousavi",
                Password = "mousavi".GetHashStringAsync().Result,
                PersonId = 2
            },
            new()
            {
                Id = 3,
                Username = "z.abedi",
                Password = "abedi".GetHashStringAsync().Result,
                PersonId = 2
            }
        });

        modelBuilder.Entity<UserRole>().HasData(new List<UserRole>
        {
            new()
            {
                Id = 1,
                UserId = 1,
                RoleId = 1
            },
            new()
            {
                Id = 2,
                UserId = 2,
                RoleId = 2
            },
            new()
            {
                Id = 3,
                UserId = 3,
                RoleId = 2
            }
        });

        modelBuilder.Entity<Question>().HasData(new List<Question>
        {
            new ()
            {
                Id = 1,
                UserId = 2,
                QuestionContent = "This is a Question",
                Upvote = 1,
                Downvote = 1,
                RankQuestion = 5,
                RankUser = 5,
            },
            new ()
            {
                Id = 2,
                UserId = 3,
                QuestionContent = "This is a Question",
                Upvote = 1,
                Downvote = 1,
                RankQuestion = 5,
                RankUser = 5,
            }
        });

        modelBuilder.Entity<Answer>().HasData(new List<Answer>
        {
            new ()
            {
                Id = 1,
                UserId = 2,
                AnswerContent = "This is an Answer",
                Upvote = 1,
                Downvote = 1,
                RankAnswer = 5,
                RankUser = 5,
            },
            new ()
            {
                Id = 2,
                UserId = 3,
                AnswerContent = "This is an Answer",
                Upvote = 1,
                Downvote = 1,
                RankAnswer = 5,
                RankUser = 5
            }
        });

        modelBuilder.Entity<CommentQuestion>().HasData(new List<CommentQuestion>
        {
            new()
            {
                Id = 1,
                Content = "This is a Comment",
                QuestionId = 1
            },
            new()
            {
                Id = 2,
                Content = "This is a Comment",
                QuestionId = 1,
            },
        });

        modelBuilder.Entity<CommentAnswer>().HasData(new List<CommentAnswer>
        {
            new()
            {
                Id = 1,
                Content = "This is a Comment",
                AnswerId = 1
            },
            new()
            {
                Id = 2,
                Content = "This is a Comment",
                AnswerId = 1,
            },
        });
    }
}
