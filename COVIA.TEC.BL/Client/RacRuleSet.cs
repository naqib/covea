using COVIA.TEC.BL.ChainOfResponsibility.Interface;
using COVIA.TEC.ChainOfResponsibility;
using COVIA.TEC.ChainOfResponsibility.Interface;
using COVIA.TEC.ChainOfResponsibility.Receiver;
using COVIA.TEC.Domain;
using System.Collections.Generic;

namespace COVIA.TEC.BL.Client
{
    public class RacRuleSet : IRuleSet
    {
        public AssuredDetail Process(RequestBo request)
        {
            try
            {   // this needs to go to IoC container
                var handlers = new List<IHandler>() {
                 new AssuredSum25MTo50MReceiver(),
                 new InvalidAgeReceiver(),
                 new AgeUpto30Receiver(),
                 new Age31To50Receiver(),
                 new Age50To65Receiver()
                };
                var dispatcher = new RuleEngine(handlers);

                var assuredDetail = dispatcher.Start(request);

                return assuredDetail;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
