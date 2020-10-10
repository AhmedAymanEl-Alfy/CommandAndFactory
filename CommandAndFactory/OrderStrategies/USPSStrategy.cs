using CommandAndFactory.Enumerations;
using CommandAndFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandAndFactory.OrderStrategies
{
    public class USPSStrategy : IOrderStrategy
    {
        public ShippingTypes ShippingType => ShippingTypes.USPS;

        public double CalculateShippingCost()
        {
            return 5.5;
        }
    }
}
