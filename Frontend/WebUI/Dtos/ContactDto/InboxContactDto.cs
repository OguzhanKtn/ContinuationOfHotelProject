using EntityLayer.Concrete;

namespace WebUI.Dtos.ContactDto
{
    public record InboxContactDto
    (
         int Id,
         string Name, 
         string Mail,
         string Subject,
         string Message, 
         DateTime Date
    );
}
