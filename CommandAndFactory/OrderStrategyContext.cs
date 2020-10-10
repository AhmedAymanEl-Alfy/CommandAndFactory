using CommandAndFactory.Enumerations;
using CommandAndFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandAndFactory.OrderStrategies
{
    public class OrderStrategyContext
    {
        Dictionary<ShippingTypes, IOrderStrategy> strategies;
        public OrderStrategyContext()
        {
            strategies = new Dictionary<ShippingTypes, IOrderStrategy>();
            //strategies.Add(ShippingTypes.Aramex, new AramexStrategy());
            //strategies.Add(ShippingTypes.DHL, new DHLStrategy());
            //strategies.Add(ShippingTypes.FedEx, new FedExStrategy());
            var allTypes = Assembly.GetExecutingAssembly().GetTypes(); //Reflection
            foreach (var strategy in allTypes)
            {
                if (strategy.GetInterface("IOrderStrategy") != null)
                {
                    IOrderStrategy st = Activator.CreateInstance(strategy) as IOrderStrategy;
                    strategies.Add(st.ShippingType, st);
                }
            }
        }

        public double? CalculateShippingCost(ShippingTypes shippingType)
        {
            if (strategies.ContainsKey(shippingType))
                return strategies[shippingType].CalculateShippingCost();
            return null;
        }
    }
}
