using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAnswerBackend.Model.Views;

public class QuestionView
{
    public string? Username { get; set; }

    public string? QuestionContent { get; set; }

    public int Upvote { get; set; }

    public int Downvote { get; set; }

    public int RankQuestion { get; set; }

    public int RankUser { get; set; }

    public List<AnswerView>? Answers { get; set; }

    public List<CommentQuestionView>? CommentQuestions { get; set; }
}
