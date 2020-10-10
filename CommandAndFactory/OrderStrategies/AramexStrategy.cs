using CommandAndFactory.Enumerations;
using CommandAndFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandAndFactory.OrderStrategies
{
    public class AramexStrategy : IOrderStrategy
    {
        public ShippingTypes ShippingType => ShippingTypes.Aramex;

        public double CalculateShippingCost()
        {
            //TODO: Add Shipping Business Logic

            return 4.0;
        }
    }
}
