
using System;
using System.Collections.Generic;

public class CompanyResultData
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public string Name { get; set; }
    public double Cash { get; set; }
    public List<GameBoat> GameBoats { get; set; }
    public string PlayerName { get; set; }
}
