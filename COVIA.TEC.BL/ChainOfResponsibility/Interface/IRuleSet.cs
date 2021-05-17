using COVIA.TEC.Domain;

namespace COVIA.TEC.BL.ChainOfResponsibility.Interface
{
    public interface IRuleSet
    {
        AssuredDetail Process(RequestBo request);
    }
}
