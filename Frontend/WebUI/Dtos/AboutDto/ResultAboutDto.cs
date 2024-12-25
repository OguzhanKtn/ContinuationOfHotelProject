namespace WebUI.Dtos.AboutDto
{
    public record ResultAboutDto
    (
         int Id,
         string Title1,
         string Title2,
         string Content,
         int RoomCount,
         int StaffCount,
         int CustomerCount
    );
}
