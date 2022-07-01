using Sieve.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAnswerBackend.Model;

public class Answer : BaseEntity
{
    [Sieve(CanFilter = true, CanSort = true)]
    public int QuestionId { get; set; }

    [ForeignKey("QuestionId")]
    public Question? Question { get; set; }

    [ForeignKey("User")]
    [Sieve(CanFilter = true, CanSort = true)]
    public int UserId { get; set; }

    public string? AnswerContent { get; set; }

    public int Upvote { get; set; }

    public int Downvote { get; set; }

    public bool IsCorrectAnswer { get; set; }

    [Sieve(CanFilter = true, CanSort = true)]
    public int RankAnswer { get; set; }

    [Sieve(CanFilter = true, CanSort = true)]
    public int RankUser { get; set; }

    public ICollection<CommentAnswer>? CommentAnswers { get; set; }
}
