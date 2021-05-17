using System;
using System.Collections.Generic;
using COVIA.TEC.ChainOfResponsibility.Interface;
using COVIA.TEC.Domain;

namespace COVIA.TEC.ChainOfResponsibility
{
    public  class RuleEngine 
    {
        public List<IHandler> _handlers { get; set; }

        public RuleEngine(List<IHandler> handlers)
        {
            _handlers = handlers;
        }
        public  AssuredDetail Start(RequestBo request) {
            try
            {
                for (var counter = 0; counter < _handlers.Count; counter++)
                {
                    var next = counter + 1;
                    if (next >= _handlers.Count)
                        break;

                    _handlers[counter].SetNext(_handlers[next]);
                }

                return _handlers[0].Handle(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
