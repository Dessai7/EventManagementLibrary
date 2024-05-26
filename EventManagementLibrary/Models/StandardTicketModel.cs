namespace EventManagementLibrary.Models

{
    public class StandardTicketModel : TicketModel
    {
        public StandardTicketModel()
        {

        }

        public StandardTicketModel(string ticketName, int ticketID, int ticketPrice, TicketStatus ticketStatus)
        {
            TicketName = ticketName;
            TicketID = ticketID;
            TicketPrice = ticketPrice;
            TicketStatus = ticketStatus;

        }
        public string TicketName { get; set; } = "Standard Ticket 2024";

        public override string DisplayTicketInfo()
        {
            return $"Ticket information:\n\n Ticket Name: {TicketName} - Price - {TicketPrice}$, Status {TicketStatus} - Grants partial access to the event. ";
        }
    }
}
