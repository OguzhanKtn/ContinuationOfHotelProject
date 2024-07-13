using System.ComponentModel.DataAnnotations;

namespace WebUI.Dtos.ServiceDto
{
    public record UpdateServiceDto
    (
        int Id,

        [Required(ErrorMessage = "Hizmet ikon linki giriniz.")]
        string ServiceIcon,

        [Required(ErrorMessage = "Hizmet başlığı giriniz.")]
        [StringLength(100, ErrorMessage = "Hizmet başlığı en fazla 100 karakter olabilir.")]
        string Title,

        [Required(ErrorMessage = "Hizmet açıklaması giriniz.")]
        [StringLength(100, ErrorMessage = "Hizmet başlığı en fazla 500 karakter olabilir.")]
        string Description
    );
}
