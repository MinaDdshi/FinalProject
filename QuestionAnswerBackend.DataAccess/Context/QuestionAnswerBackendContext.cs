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
    }
}