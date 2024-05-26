namespace EventManagementLibrary.Models

{
    public partial class VipTicketModel : TicketModel
    {
        public VipTicketModel()
        {

        }

        public VipTicketModel(string ticketName, int ticketID, int ticketPrice, TicketStatus ticketStatus)
        {
            TicketName = ticketName;
            TicketID = ticketID;
            TicketPrice = ticketPrice;
            TicketStatus = ticketStatus;

        }
        public string TicketName { get; set; } = "VIP Ticket 2024";
        public VipType VipStatus { get; set; } = VipType.RegularVIP;

        public override string DisplayTicketInfo()
        {
            return $"Ticket information:\n\n Ticket Name: {TicketName} - Price - {TicketPrice}$, Status - {TicketStatus}, VIP Status - {VipStatus} - Grants partial Access to the event and VIP Status (Applies to recieve free merch from the event and more!)";
        }
    }
}
