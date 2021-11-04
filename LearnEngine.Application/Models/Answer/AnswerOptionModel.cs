using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Application.Models.Answer
{
    public sealed class AnswerOptionModel
    {
        public string Text { get; set; }

        public short HashOrder { get; set; }
    }

    public class AnswerOptionModelValidator : AbstractValidator<AnswerOptionModel>
    {
        public AnswerOptionModelValidator()
        {
            RuleFor(x => x.HashOrder).GreaterThan((short)0);
            RuleFor(x => x.Text).NotEmpty();
        }
    }
}
