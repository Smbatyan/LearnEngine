using LearnEngine.Core.Enums;

namespace LearnEngine.Application.ResponseModels
{
    public record AnswerResponse
    {
        public List<AnswerOptionResponse> Options { get; set; }
        
        public short AnswerTypeId { get; set; }

        public string RightAnswerHash { get; set; }

    }
}
