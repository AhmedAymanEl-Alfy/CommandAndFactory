using CommandAndFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandAndFactory.Strategies
{
    public class FedExStrategy : IShippingStrategy
    {
        public double CalculateShippingCost()
        {
            return 4.0;
        }
    }
}
