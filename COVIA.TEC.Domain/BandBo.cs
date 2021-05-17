namespace COVIA.TEC.Domain
{
    public class BandBo
    {
        public double lowerBandSumAssured { get; set; } = 25000;
        public double upperBandSumAssured { get; set; } = 50000;
        public double lowerBandRiskRate { get; set; }
        public double upperBandRiskRate { get; set; }
    }
}

