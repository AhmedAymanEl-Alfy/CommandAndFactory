using CommandAndFactory.Enums;
using CommandAndFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandAndFactory.Strategies
{
    public class ShippingContext
    {
        readonly Dictionary<ShippingTypes, IShippingStrategy> strategies;
        public ShippingContext()
        {
            strategies = new Dictionary<ShippingTypes, IShippingStrategy>();
            strategies.Add(ShippingTypes.Aramex, new AramexStrategy());
            strategies.Add(ShippingTypes.FEDX, new FedExStrategy());
            strategies.Add(ShippingTypes.USPS, new USPSStrategy());
        }

        public double? CalculateShippingCost(ShippingTypes shippingType)
        {
            if (strategies.ContainsKey(shippingType))
            {
                return strategies[shippingType].CalculateShippingCost(); 
            }
            return null;
        }
    }
}
