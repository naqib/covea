

using COVIA.TEC.Domain;

namespace COVIA.TEC.ChainOfResponsibility.Receiver
{
    public class AssuredSum25MTo50MReceiver : AbstractHandler
    {
        public override AssuredDetail Handle(RequestBo request)
        {
            if (request.AssuredSum < 25000 || request.AssuredSum > 500000)
            {
                return new AssuredDetail {
                    Age = request.Age,
                    SumAssured = request.AssuredSum,
                    GrassPermium = 0,
                    Description = $"Invalid AssuredSum {request.AssuredSum}, the correct range is [25000-500000]"
                };
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
