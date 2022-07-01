using Sieve.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAnswerBackend.Model;

public class Person : BaseEntity
{
    [Sieve(CanFilter = true, CanSort = true)]
    public string? Name { get; set; }

    [Sieve(CanFilter = true, CanSort = true)]
    public string? Family { get; set; }

    public string FullName => Name + " " + Family;

    public virtual User? User { get; set; }
}
