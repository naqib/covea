

using COVIA.TEC.Domain;

namespace COVIA.TEC.ChainOfResponsibility.Receiver
{
    public class AgeUpto30Receiver : AbstractHandler
    {
        public override AssuredDetail Handle(RequestBo request)
        {
            if (request.Age >= 18 && request.Age <= 30)
            {
                band.lowerBandRiskRate = 0.0172;
                band.upperBandRiskRate = 0.2677;
                band.lowerBandSumAssured = 25000;
                band.upperBandSumAssured = 50000;

                var assuredDetail = this.Compute(request.AssuredSum, request.Age);
                assuredDetail.Description = $"Gross Premium for ({request.Age}) and AssuredSum({request.AssuredSum}) is {assuredDetail.GrassPermium}";
                return assuredDetail;
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
