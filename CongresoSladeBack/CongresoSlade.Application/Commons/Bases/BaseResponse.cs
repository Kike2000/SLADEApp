using FluentValidation.Results;

namespace CongresoSlade.Application.Commons.Bases
{
    public class BaseResponse<T>
    {
        public bool IsSucessful { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public IEnumerable<ValidationFailure>? Errors { get; set; }
    }
}
