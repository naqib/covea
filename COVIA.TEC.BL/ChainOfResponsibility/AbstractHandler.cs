using COVIA.TEC.ChainOfResponsibility.Interface;
using COVIA.TEC.Domain;

namespace COVIA.TEC.ChainOfResponsibility
{
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;
        protected BandBo band;

        public AbstractHandler()
        {
            band = new BandBo();
        }
        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }

        public virtual AssuredDetail Handle(RequestBo request)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }

        public AssuredDetail Compute(double assuredSum, int age)
        {
            var riskRate = ((assuredSum - band.lowerBandRiskRate) / (band.upperBandSumAssured - band.lowerBandSumAssured) *
                      band.upperBandRiskRate + (band.upperBandSumAssured - assuredSum) /
                      (band.upperBandSumAssured - band.lowerBandSumAssured) * band.lowerBandRiskRate);

            var riskPremium = riskRate * (assuredSum / 1000);
            var renewalCommission = (3 * riskPremium) / 100;
            var netPremium = riskPremium + renewalCommission;
            var initalCommission = (netPremium * 205) / 100;
            var grassPermium = netPremium + initalCommission;

            return new AssuredDetail { Age = age, SumAssured = assuredSum, GrassPermium = grassPermium };
        }
    }
}
