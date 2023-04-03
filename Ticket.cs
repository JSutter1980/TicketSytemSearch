public class Ticket
{
    public int ticketId { get; set; }
    public string summary { get; set; }
    public string status { get; set; }
    public string priority { get; set; }
    public string owner { get; set; }
    public string assign { get; set; }
    public string watch { get; set; }
    public string severity { get; set;}

    public virtual string Display()
    {
        return $"Id: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitted by: {owner}\nAssigned to: {assign}\nWatched by: {watch}\nSeverity Level:{severity}";
    }
}

public class Enhancement : Ticket
{
    public string software { get; set;}
    public string cost { get; set;}
    public string reason {get; set;}
    public string estimate { get; set;}

    public override string Display()
    {
        return $"Id: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitted by: {owner}\nAssigned to: {assign}\nWatched by: {watch}\nSoftware Enhanced: {software}\nCost: {cost}\nReason: {reason}\nEstimate: {estimate}\n";
    }

}

public class Task : Ticket
{
    public string project {get; set;}
    public string dueDate {get; set;}

    public override string Display()
    {
        return $"Id: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitted by: {owner}\nAssigned to: {assign}\nWatched by: {watch}\nProject Name: {project}\nDue Date: {dueDate}\n";
    }
}



