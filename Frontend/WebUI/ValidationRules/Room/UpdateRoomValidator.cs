using FluentValidation;
using WebUI.Dtos.RoomDto;

namespace WebUI.ValidationRules.Room
{
    public class UpdateRoomValidator: AbstractValidator<UpdateRoomDto>
    {
        public UpdateRoomValidator() 
        {
            RuleFor(x => x.RoomNumber).NotEmpty().WithMessage("Oda numarası boş geçilemez!");
            RuleFor(x => x.RoomCoverImage).NotEmpty().WithMessage("Oda resmi boş geçilemez!");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Oda fiyatı boş geçilemez!");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez!");
            RuleFor(x => x.BedCount).NotEmpty().WithMessage("Yatak sayısı boş geçilemez!");
            RuleFor(x => x.BathCount).NotEmpty().WithMessage("Banyo sayısı boş geçilemez!");
            RuleFor(x => x.Wifi).NotEmpty().WithMessage("Wifi bilgisi boş geçilemez!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Oda numarası boş geçilemez!");
            RuleFor(x => x.Title).MinimumLength(8).WithMessage("Başlık minimum 10 karakterden oluşmalıdır!");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Başlık maksimum 100 karakterden oluşmalıdır!");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Açıklama minimum 10 karakterden oluşmalıdır!");
            RuleFor(x => x.Description).MaximumLength(200).WithMessage("Açıklama maksimum 200 karakterden oluşmalıdır!");
        }
    }
}
