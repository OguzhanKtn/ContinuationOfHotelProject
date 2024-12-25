using System.ComponentModel.DataAnnotations;

namespace WebUI.Dtos.ServiceDto
{
    public record CreateServiceDto
    (
        string ServiceIcon,       
        string Title,
        string Description
    );
}
