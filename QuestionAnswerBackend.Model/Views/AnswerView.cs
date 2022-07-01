using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAnswerBackend.Model.Views;

public class AnswerView
{
    public string? Username { get; set; }

    public string? AnswerContent { get; set; }

    public int Upvote { get; set; }

    public int Downvote { get; set; }

    public bool IsCorrectAnswer { get; set; }

    public int RankAnswer { get; set; }

    public int RankUser { get; set; }

    public List<CommentAnswerView>? CommentAnswers { get; set; }
}
