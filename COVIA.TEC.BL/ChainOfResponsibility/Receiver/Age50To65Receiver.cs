
using COVIA.TEC.Domain;

namespace COVIA.TEC.ChainOfResponsibility.Receiver
{
    public class Age50To65Receiver : AbstractHandler
    {
        public override AssuredDetail Handle(RequestBo request)
        {
            if (request.Age > 50 && request.Age <= 65)
            {
                band.lowerBandRiskRate = 0.2677;
                band.upperBandRiskRate = 02285;
                band.lowerBandSumAssured = 25000;
                band.upperBandSumAssured = 200000;

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
