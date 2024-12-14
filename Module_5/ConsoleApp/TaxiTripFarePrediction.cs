using Microsoft.ML.Data;

namespace ConsoleApp;

public class TaxiTripFarePrediction
{
    [ColumnName("Score")]
    public float FareAmount;
}