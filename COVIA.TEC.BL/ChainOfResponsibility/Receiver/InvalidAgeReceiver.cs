
using COVIA.TEC.Domain;

namespace COVIA.TEC.ChainOfResponsibility.Receiver
{
    public class InvalidAgeReceiver : AbstractHandler
    {
        public override AssuredDetail Handle(RequestBo request)
        {
            if (request.Age < 18 || request.Age > 65)
            {
                return new AssuredDetail {
                    Age = request.Age,
                    SumAssured = request.AssuredSum,
                    GrassPermium = 0,
                    Description = $"Invalid age {request.Age}, the correct range is [18-65]"
                };
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
