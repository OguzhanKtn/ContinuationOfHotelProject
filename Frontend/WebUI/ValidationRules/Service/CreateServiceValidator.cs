using FluentValidation;
using WebUI.Dtos.ServiceDto;

namespace WebUI.ValidationRules.Service
{
    public class CreateServiceValidator : AbstractValidator<CreateServiceDto>
    {
        public CreateServiceValidator()
        {
            RuleFor(x => x.ServiceIcon).NotEmpty().WithMessage("Servis ikonu boş geçilemez!");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez!");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Başlık 3 karakterden az olamaz!");
            RuleFor(x => x.Title).MaximumLength(60).WithMessage("Başlık 60 karakterden fazla olamaz!");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Açıklama 10 karakterden az olamaz!");
            RuleFor(x => x.Description).MaximumLength(100).WithMessage("Açıklama 100 karakterden fazla olamaz!");
        }
    }
}
