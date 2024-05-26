using static EventManagementLibrary.Models.VipTicketModel;

namespace EventManagementLibrary.Models

{
    public class FullAccessTicketModel : TicketModel
    {
        public FullAccessTicketModel()
        {

        }

        public FullAccessTicketModel(string ticketName, TicketStatus ticketStatus)
        {
            TicketName = ticketName;
            TicketStatus = ticketStatus;

        }
        public string TicketName { get; set; } = "Full Access Ticket 2024";
        public VipType VipStatus { get; set; } = VipType.FullAccessVIP;

        public string HelloFounder()
        {
            string output = "Welcome founder";
            return output;
        }
        public override string DisplayTicketInfo()
        {
            return $"Ticket information:\n\n Ticket Name: {TicketName} - Status - {TicketStatus}, VIP Status - {VipStatus}, {HelloFounder()} ";
        }

    }
}
