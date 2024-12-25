using System.ComponentModel.DataAnnotations;

namespace WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage ="Lütfen adınızı giriniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyadınızı giriniz.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen şehir giriniz.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Lütfen mail adresinizi giriniz.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen parolanızı giriniz.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen parolanızı doğrulayınız.")]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmamaktadır.")]
        public string ConfirmPassword { get; set; }
    }
}
