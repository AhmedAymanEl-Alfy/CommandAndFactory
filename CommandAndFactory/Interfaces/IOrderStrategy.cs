using CommandAndFactory.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandAndFactory.Interfaces
{
    public interface IOrderStrategy
    {
        ShippingTypes ShippingType { get; }
        double CalculateShippingCost(/*Order order*/);
    }
}
