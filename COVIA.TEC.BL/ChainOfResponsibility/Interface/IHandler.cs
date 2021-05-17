
using COVIA.TEC.Domain;

namespace COVIA.TEC.ChainOfResponsibility.Interface
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        AssuredDetail Handle(RequestBo request);
    }
}
