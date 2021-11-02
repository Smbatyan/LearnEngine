using LearnEngine.Core.Enums;

namespace LearnEngine.Application.ResponseModels
{
    public record AnswerResponse
    {
        public List<string> Options { get; set; }
        
        public AnswerTypes AnswerTypeId { get; set; }

        public string RightAnswerHash { get; set; }

    }
}
