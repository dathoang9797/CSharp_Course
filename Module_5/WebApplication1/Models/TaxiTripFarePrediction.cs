using Microsoft.ML.Data;

namespace WebApplication1.Models;

public class TaxiTripFarePrediction
{
    [ColumnName("Score")] public float FareAmount;
}