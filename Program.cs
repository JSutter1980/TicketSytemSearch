using System.Linq;
using NLog;
string path = Directory.GetCurrentDirectory() + "\\nlog.config";

string choice;

List<Ticket> ticketList = new List<Ticket>();

do
{
    
    Console.WriteLine("1) Create New Ticket.");
    Console.WriteLine("2) View Ticket Information");
    Console.WriteLine("3) Search Ticket.");
    Console.WriteLine("Enter any other key to exit.");

    choice = Console.ReadLine();

    if (choice == "1")

    {

        Console.WriteLine("Enter the number for the type of ticket:\n 1.Bug/Defect\n 2.Enhancement\n 3.Task ");
        string type = Console.ReadLine();


        Ticket ticket = new Ticket();

        ticket.ticketId = ticketList.Count == 0 ? 1 : ticketList.Max(t => t.ticketId) + 1;

        Console.WriteLine("Ticket Summery");
        ticket.summary = Console.ReadLine().ToUpper();

        Console.WriteLine("Enter Ticket Status");
        ticket.status = Console.ReadLine().ToUpper();

        Console.WriteLine("Enter Ticket Priority(High,Medium,Low)");
        ticket.priority = Console.ReadLine().ToUpper();

        Console.WriteLine("Who Submitted Ticket?");
        ticket.owner = Console.ReadLine().ToUpper();

        Console.WriteLine("Who To Assign to Ticket?");
        ticket.assign = Console.ReadLine().ToUpper();

        Console.WriteLine("Who is Watching Ticket?");
        ticket.watch = Console.ReadLine().ToUpper();

        if (type == "1")

        {

            StreamWriter swTicket = new StreamWriter("Tickets.csv", append: true);

            Console.WriteLine("What is the Severity of the ticket?(High,Medium,Low)");
            ticket.severity = Console.ReadLine().ToUpper();

            swTicket.WriteLine($"{ticket.ticketId},{ticket.summary},{ticket.status},{ticket.priority},{ticket.owner},{ticket.assign},{ticket.watch},{ticket.severity}");

            swTicket.Close();
        }

        else if (type == "2")

        {

            StreamWriter swEnhance = new StreamWriter("Enhancements.csv", append: true);

            Console.WriteLine("What is the software you are editing?");
            string edit = Console.ReadLine();

            Console.WriteLine("What is the cost?");
            string dollars = Console.ReadLine();

            Console.WriteLine("What is the reason for the enhancement?");
            string why = Console.ReadLine();

            Console.WriteLine("What is the estimated cost?");
            string estimatedCost = Console.ReadLine();

            Enhancement enhancement = new Enhancement
            {
                software = edit,
                cost = dollars,
                reason = why,
                estimate = estimatedCost

            };

            swEnhance.WriteLine($"{ticket.ticketId},{ticket.summary},{ticket.status},{ticket.priority},{ticket.owner},{ticket.assign},{ticket.watch},{enhancement.software},{enhancement.cost},{enhancement.reason},{enhancement.estimate}");

            swEnhance.Close();

        }


        else if (type == "3")
        {

            StreamWriter swTask = new StreamWriter("Tasks.csv", append: true);

            Console.WriteLine("What is the Project Name?");
            string name = Console.ReadLine();

            Console.WriteLine("What is the due date of the project?");
            string date = Console.ReadLine();

            Task task = new Task
            {
                project = name,
                dueDate = date
            };

            swTask.WriteLine($"{ticket.ticketId},{ticket.summary},{ticket.status},{ticket.priority},{ticket.owner},{ticket.assign},{ticket.watch},{task.project},{task.dueDate}");

            swTask.Close();
        }
        ticketList.Add(ticket);
    }


   else if (choice == "2")
    

        if (File.Exists("Tickets.csv"))
        {
            StreamReader srTicket = new StreamReader("Tickets.csv");
            while (!srTicket.EndOfStream)
            {
                string line = srTicket.ReadLine();
                string[] arr = line.Split(',');

                foreach (Ticket ticket in ticketList)
                {
                    Console.WriteLine(ticket.Display());
                }

            }

            srTicket.Close();
        }

        if (File.Exists("Enhancements.csv"))
        {
            StreamReader srEnhance = new StreamReader("Enhancements.csv");
            while (!srEnhance.EndOfStream)
            {
                string line = srEnhance.ReadLine();
                string[] arr = line.Split(',');

                foreach (Ticket ticket in ticketList)
                {
                    Console.WriteLine(ticket.Display());
                }

            }

            srEnhance.Close();

        }

        if (File.Exists("Task.csv"))
        {
            StreamReader srTask = new StreamReader("Task.csv");
            while (!srTask.EndOfStream)
            {
                string line = srTask.ReadLine();
                string[] arr = line.Split(',');

                foreach (Ticket ticket in ticketList)
                {
                    Console.WriteLine(ticket.Display());
                }

            }

            srTask.Close();

        } 

        else if (choice == "3")

        {

            Console.WriteLine("How would you like to refine your search?\n 1.Status\n 2.Priority\n 3.Submitter");

            var answer = Console.ReadLine();

            if (answer == "1")
            {
                Console.WriteLine("What status are you searching for?:");
                var statusAnswer = Console.ReadLine();

                var statusList = ticketList.Where(t => t.status.Contains(statusAnswer, StringComparison.OrdinalIgnoreCase));

                Console.WriteLine($"There are {statusList.Count()} tickets with the status {statusAnswer}");

                foreach(Ticket t in ticketList)
                {
                    Console.WriteLine( $"Id: {t.ticketId}\nSummary: {t.summary}\nStatus: {t.status}\nPriority: {t.priority}\nSubmitted by: {t.owner}\nAssigned to: {t.assign}\nWatched by: {t.watch}\n");
                }
            }

            else if (answer == "2")
            {

                Console.WriteLine("What priority are you searching for?:");
                var statusAnswer = Console.ReadLine();

                var statusList = ticketList.Where(t => t.priority.Contains(statusAnswer, StringComparison.OrdinalIgnoreCase));

                Console.WriteLine($"There are {statusList.Count()} tickets with the priority {statusAnswer}");

                foreach(Ticket t in statusList)
                {
                    Console.WriteLine( $"Id: {t.ticketId}\nSummary: {t.summary}\nStatus: {t.status}\nPriority: {t.priority}\nSubmitted by: {t.owner}\nAssigned to: {t.assign}\nWatched by: {t.watch}\n");
                }

            }

            else if (answer == "3")
            {

                Console.WriteLine("What status are you searching for?:");
                var statusAnswer = Console.ReadLine();

                var statusList = ticketList.Where(t => t.owner.Contains(statusAnswer, StringComparison.OrdinalIgnoreCase));

                Console.WriteLine($"There are {statusList.Count()} tickets submitted by: {statusAnswer}");

                foreach(Ticket t in statusList)
                {
                    Console.WriteLine( $"Id: {t.ticketId}\nSummary: {t.summary}\nStatus: {t.status}\nPriority: {t.priority}\nSubmitted by: {t.owner}\nAssigned to: {t.assign}\nWatched by: {t.watch}\n");
                }

            }

        }

} while (choice == "1" || choice == "2" || choice == "3");
