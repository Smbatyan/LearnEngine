using FluentValidation;
using LearnEngine.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEngine.Application.Models.Answer
{
    public sealed class AnswerModel
    {
        public List<AnswerOptionModel> Options { get; set; }

        public AnswerTypes AnswerTypeId { get; set; }

        //public string RightAnswerHash { get; set; }
    }

    public class AnswerModelValidator : AbstractValidator<AnswerModel>
    {
        public AnswerModelValidator()
        {
            RuleFor(x => x.AnswerTypeId).IsInEnum();
            //RuleFor(x => x.RightAnswerHash).NotEmpty();
            RuleFor(x => x.Options).NotNull();
        }
    }
}
