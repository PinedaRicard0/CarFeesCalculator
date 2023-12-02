using System;
namespace TOTAL_CAR_FEES.APPLICATION.Fees.Models
{
    public class TotalFeesResponse
    {
        public string? VehiclePrice { get; set; }
        public string? VehicleType { get; set; }
        public string? Total { get; set; }
        public List<Fee>? Fees { get; set; }
    }

    public class Fee
    {
        public string? Name { get; set; }
        public string? Value { get; set; }
    }
}