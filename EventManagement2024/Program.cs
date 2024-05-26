using EventManagementLibrary.Models;
using System;
using System.Collections.Generic;

namespace EventManagement2024
{

    /*(Disclaimer)
    I was going to refactor the buy and cancel ticket menu by creating a third 
    list named "soldTicketList" so when a ticket was purchased remove it from the original 
    lists (vipTicketList or standardTicketList) and add it to this "soldTicketList" and the same with
    cancel ticket, so when the ticket is cancelled, remove it from soldTicketList and add it again to its original list. 
    But I already spent too many hours in this app and wasn't willing to spend no more time in it. It accomplish it's purpose already. Lol*/


    internal class Program
    {
        static void Main(string[] args)
        {
            Welcome();

            List<VipTicketModel> vipTicketList = new List<VipTicketModel>();
            List<StandardTicketModel> standardTicketList = new List<StandardTicketModel>();
            List<FullAccessTicketModel> fullAccessTicketList = new List<FullAccessTicketModel>();


            AddBaseTickets(vipTicketList, standardTicketList, fullAccessTicketList);

            AppMenu(vipTicketList, standardTicketList, fullAccessTicketList);

            GoodBye();

            Console.ReadLine();
        }



        private static void Welcome()
        {
            Console.WriteLine("Welcome to the Event Manager for the 2024 Dev Summer meeting!");
            Console.WriteLine("************************************************************\n");
        }
        private static void AddBaseTickets(List<VipTicketModel> vipTicketList, List<StandardTicketModel> standardTicketList, List<FullAccessTicketModel> fullAccessTicketList)
        {
            standardTicketList.Add(new StandardTicketModel("Standard Ticket 2024", 1, 50, TicketStatus.Available));
            vipTicketList.Add(new VipTicketModel("Vip Ticket 2024", 2, 70, TicketStatus.Available));
            fullAccessTicketList.Add(new FullAccessTicketModel("Full Access Ticket 2024", TicketStatus.Available));
        }

        private static void AppMenu(List<VipTicketModel> vipTicketList, List<StandardTicketModel> standardTicketList, List<FullAccessTicketModel> fullAccessTicketList)
        {

            bool isValidNumber;
            int selection;
            string stayInMenu;

            do
            {
                Console.WriteLine("************************************************************\n");
                Console.WriteLine("Select option:");
                Console.WriteLine("1. Display ticket Info    2. Buy Ticket (Shows detailed ticket info)   3. Cancel Ticket    4. Create Ticket (Admin only)\n");
                Console.WriteLine("************************************************************\n");

                isValidNumber = int.TryParse(Console.ReadLine(), out selection);
                string userName;
                string password;


                if (selection == 1)
                {
                    DisplayTicketMenu(vipTicketList, standardTicketList, fullAccessTicketList);

                }


                if (selection == 2)
                {
                    BuyTicketMenu(vipTicketList, standardTicketList, fullAccessTicketList);
                }

                if (selection == 3)
                {
                    CancelTicketMenu(vipTicketList, standardTicketList, fullAccessTicketList);
                }

                if (selection == 4)
                {
                    CreateTicketMenu(vipTicketList, standardTicketList, fullAccessTicketList, out userName, out password);

                }

                Console.WriteLine("Do you want to continue in the menu? Type yes or type any key to exit the menu. ");
                stayInMenu = Console.ReadLine();

            } while (stayInMenu.ToLower() == "yes");
        }

        private static void DisplayTicketMenu(List<VipTicketModel> vipTicketList, List<StandardTicketModel> standardTicketList, List<FullAccessTicketModel> fullAccessTicketList)
        {
            Console.Clear();
            Console.WriteLine("The available tickets are: \n");



            foreach (var ticket in standardTicketList)
            {
                Console.WriteLine(ticket.DisplayTicketInfo());
            }
            Console.WriteLine();

            foreach (var ticket in vipTicketList)

            {
                Console.WriteLine(ticket.DisplayTicketInfo());

            }
            Console.WriteLine();

            foreach (var ticket in fullAccessTicketList)
            {
                Console.WriteLine(ticket.DisplayTicketInfo());
            }
            Console.WriteLine();
        }
        private static void BuyTicketMenu(List<VipTicketModel> vipTicketList, List<StandardTicketModel> standardTicketList, List<FullAccessTicketModel> fullAccessTicketList)
        {
            string keepBuying;
            string ticketElection;
            do
            {

                Console.Clear();

                Console.WriteLine("Wich ticket do you want to buy?\n Type STANDARD to buy a Standard Ticket " +
                    "or type VIP to buy a VIP ticket.\n");

                foreach (var ticket in standardTicketList)
                {
                    Console.WriteLine(ticket.DisplayTicketInfo());
                }
                Console.WriteLine();

                foreach (var ticket in vipTicketList)

                {
                    Console.WriteLine(ticket.DisplayTicketInfo());

                }
                Console.WriteLine();


                Console.WriteLine("*Disclaimer: Full Access Pass is not available for purchase.*\n");


                ticketElection = Console.ReadLine();

                if (ticketElection.ToLower() == "standard")
                {
                    StandardTicketModel standardTicket1 = standardTicketList[0];
                    standardTicket1.BuyTicket();
                    standardTicket1.CheckStatus();
                    Console.WriteLine($"Your TicketID is: {standardTicket1.TicketID} . You must save this ID to cancel your ticket" +
                        $" if you ever want to.");

                    Console.ReadLine();

                }


                if (ticketElection.ToLower() == "vip")
                {
                    VipTicketModel vipTicket1 = vipTicketList[0];
                    vipTicket1.BuyTicket();
                    vipTicket1.CheckStatus();
                    Console.WriteLine($"Your TicketID is: {vipTicket1.TicketID} . You must save this ID to cancel your ticket" +
                        $" if you ever want to.");
                    Console.ReadLine();

                }

                else
                {
                    Console.WriteLine("\nThat is an invalid input.\n");
                }
                Console.WriteLine("Do you want to continue buying tickets? Type yes or type any key to exit buying menu.");
                keepBuying = Console.ReadLine();

            } while (keepBuying.ToLower() == "yes");
        }
        private static void CancelTicketMenu(List<VipTicketModel> vipTicketList, List<StandardTicketModel> standardTicketList, List<FullAccessTicketModel> fullAccessTicketList)
        {
            string keepCancelling;

            do
            {
                Console.Clear();
                Console.WriteLine("Please enter the ID of the ticket you want to cancel.");

                string input = Console.ReadLine();
                bool validInput = int.TryParse(input, out int output);

                foreach (var ticket in vipTicketList)
                {
                    if (ticket.TicketID == output)
                    {
                        ticket.CancelTicket();
                        ticket.CheckStatus();
                    }

                    else
                    {
                        Console.WriteLine("\nThat is an invalid input.\n");
                    }

                }

                Console.WriteLine("Do you want to cancel another ticket? Type yes or type any key to exit Cancelling menu.");
                keepCancelling = Console.ReadLine();

            } while (keepCancelling.ToLower() == "yes");
        }
        private static void CreateTicketMenu(List<VipTicketModel> vipTicketList, List<StandardTicketModel> standardTicketList, List<FullAccessTicketModel> fullAccessTicketList, out string userName, out string password)
        {
            Console.Clear();
            string keepAddingTickets;

            do
            {
                Console.WriteLine("Please enter admin username:\n");
                Console.WriteLine("Username:"); // admin
                userName = Console.ReadLine();
                Console.WriteLine("Password:"); // admin                        
                password = Console.ReadLine();
                string ticketType;

                if (userName.ToLower() == "admin" && password.ToLower() == "admin")
                {
                    Console.Clear();
                    Console.WriteLine("Welcome Administrator.\n");
                    ticketType = Console.ReadLine();

                    if (ticketType.ToLower() == "vip")
                    {
                        CreateNewVIPTicket(vipTicketList);

                    }

                    if (ticketType.ToLower() == "standard")
                    {
                        CreateNewStandardTicket(standardTicketList);

                    }

                    if (ticketType.ToLower() == "full")
                    {
                        CreateNewFullAccessTicket(fullAccessTicketList);
                    }

                    else
                    {
                        Console.WriteLine("\nInvalid ticket type.\n");
                    }

                }
                else
                {
                    Console.WriteLine("You need to be an admin to do this.");
                    break;
                }


                Console.WriteLine("Do you want to keep adding tickets?");
                keepAddingTickets = Console.ReadLine();
            } while (keepAddingTickets.ToLower() == "yes");
        }
        private static void CreateNewStandardTicket(List<StandardTicketModel> standardTicketList)
        {
            StandardTicketModel ticket = new StandardTicketModel();
            Random rnd = new Random();

            ticket.TicketName = "Standard Ticket 2024";
            ticket.TicketPrice = 50;
            ticket.TicketStatus = TicketStatus.Available;
            ticket.TicketID = rnd.Next(1, 50);

            standardTicketList.Add(ticket);
            Console.WriteLine($"New standard ticket ID was created : {ticket.TicketID}");
        }
        private static void CreateNewVIPTicket(List<VipTicketModel> vipTicketList)
        {
            VipTicketModel ticket = new VipTicketModel();
            Random rnd = new Random();

            ticket.TicketName = "Vip Ticket 2024";
            ticket.TicketPrice = 70;
            ticket.TicketStatus = TicketStatus.Available;
            ticket.TicketID = rnd.Next(1, 50);

            vipTicketList.Add(ticket);
            Console.WriteLine($"New VIP ticket ID was created : {ticket.TicketID}");
        }
        private static void CreateNewFullAccessTicket(List<FullAccessTicketModel> fullAccessTicketList)
        {
            FullAccessTicketModel ticket = new FullAccessTicketModel();
            Random rnd = new Random();

            ticket.TicketName = "Full Access Ticket 2024";
            ticket.TicketStatus = TicketStatus.Available;
            ticket.TicketID = rnd.Next(1, 50);

            fullAccessTicketList.Add(ticket);
            Console.WriteLine($"New Full Access ticket ID was created : {ticket.TicketID}");
        }
        private static void GoodBye()
        {
            Console.WriteLine("Thank you for using the app. See you in the next one!");
        }

    }
}
