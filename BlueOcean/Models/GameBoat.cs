
using System;

public class GameBoat
{
    public Guid Id { get; set; }
    public Guid OwningPlayerId { get; set; }
    public GameBoatType GameBoatType { get; set; }
    public GameCargoType CargoType { get; set; }
    public int CurrentFuel { get; set; }
    public int ConsumptionPerDistance { get; set; }
    public int MaxCapacity { get; set; }
    public int MaxFuel { get; set; }
    public int MaxSpeed { get; set; }
    public int Destination { get; set; }
    public int CurrentPosition { get; set; }
    public string WorldLocation { get; set; }
    public bool Moving { get; set; }
    public int Progression { get; set; }
    public int CurrentDestination { get; set; }
    public int CurrentState { get; set; }
}
