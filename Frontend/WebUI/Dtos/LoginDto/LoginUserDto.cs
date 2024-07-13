using System.ComponentModel.DataAnnotations;

namespace WebUI.Dtos.LoginDto
{
    public record LoginUserDto
    (
        [Required(ErrorMessage ="Kullanıcı adınızı giriniz.")]
        string UserName,

        [Required(ErrorMessage = "Parolanızı giriniz.")]
        string Password
    );
}
