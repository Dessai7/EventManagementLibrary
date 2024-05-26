using System;

namespace EventManagementLibrary.Models

{
    public abstract class TicketModel
    {
        public int TicketID { get; set; }
        public int TicketPrice { get; set; }
        public TicketStatus TicketStatus { get; set; } = TicketStatus.Available;



        public void BuyTicket()
        {
            TicketStatus = TicketStatus.Sold;
            Console.WriteLine("You have bought an event ticket.");
        }
        public void CancelTicket()
        {
            TicketStatus = TicketStatus.Cancelled;
            Console.WriteLine("You have cancelled your event ticket.");
        }
        public virtual string DisplayTicketInfo()
        {
            return string.Empty;
        }
        public void CreateTicket()
        {

        }

        public void CheckStatus()
        {
            Console.WriteLine($"{TicketStatus}");
        }

    }
}
