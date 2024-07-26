
using System;

public class GameAvailableContract
{
    public Guid Id { get; set; }
    public GameLocation FromLocation { get; set; }
    public GameLocation ToLocation { get; set; }
    public string For { get; set; }
    public GameCargoType CargoType { get; set; }
    public int PaymentUpFront { get; set; }
    public int PaymentAfter { get; set; }
    public int Distance { get; set; }
    public int TotalPayment { get; set; }
    public DateTime DeliverBefore { get; set; }
    public int CargoAmount { get; set; }
    public int FineForNotCompleting { get; set; }
    public string Cargo { get; set; }
}
