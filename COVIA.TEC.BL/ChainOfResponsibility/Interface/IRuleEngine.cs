using COVIA.TEC.Domain;

namespace COVIA.TEC.BL.ChainOfResponsibility.Interface
{
    public interface IRuleEngine
    {
        AssuredDetail Start(RequestBo request);
    }
}
