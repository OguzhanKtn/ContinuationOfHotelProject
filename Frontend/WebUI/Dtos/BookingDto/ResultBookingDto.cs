namespace WebUI.Dtos.BookingDto
{
    public record ResultBookingDto 
    (
         int id,
         string Name, 
         string Mail, 
         DateTime CheckIn, 
         DateTime CheckOut,
         string AdultCount, 
         string ChildCount, 
         string RoomCount, 
         string SpecialRequest, 
         string Status     
    );
}
