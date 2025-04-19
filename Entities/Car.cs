using Core.Entities;
using Entities.Enums;

namespace Entities;

public class Car:BaseEntity<Guid>
{
    public Guid ModelId { get; set; }
    public int ModelYear { get; set; }
    public string Plate { get; set; }
    public CarState State { get; set; }
    public double DailyPrice { get; set; }

    public virtual Model? Model { get; set; } //ManyToOne


    public Car()
    {
        
    }

    public Car(Guid id,Guid modelId, int modelYear, string plate, CarState state, double dailyPrice)
    {
        Id = id;
        ModelId = modelId;
        ModelYear = modelYear;
        Plate = plate;
        State = state;
        DailyPrice = dailyPrice;
    }
}
