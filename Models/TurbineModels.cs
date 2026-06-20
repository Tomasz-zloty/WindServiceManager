namespace WindServiceManager.Models;

public enum TurbineStatus { Operational, Failure, Maintenance }
public enum TicketPriority { Low, Medium, High }

public class WindTurbine
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public TurbineStatus Status { get; set; } = TurbineStatus.Operational;
    
    public List<ServiceTicket> ServiceTickets { get; set; } = new();
}

public class ServiceTicket
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public TicketPriority Priority { get; set; } = TicketPriority.Medium;
    public bool IsClosed { get; set; }

    public int WindTurbineId { get; set; }
    public WindTurbine? WindTurbine { get; set; }
}