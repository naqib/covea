using COVIA.TEC.Domain;

namespace COVIA.TEC.ChainOfResponsibility.Receiver
{
    class Age31To50Receiver : AbstractHandler
    {
        public override AssuredDetail Handle(RequestBo request)
        {
            if (request.Age >= 31 && request.Age <= 50)
            {
                band.lowerBandRiskRate = 0.1043;
                band.upperBandRiskRate = 0.0872;
                band.lowerBandSumAssured = 25000;
                band.upperBandSumAssured = 300000;

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
