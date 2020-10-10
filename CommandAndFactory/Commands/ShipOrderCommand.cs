using CommandAndFactory.Enumerations;
using CommandAndFactory.Interfaces;
using CommandAndFactory.OrderStrategies;
using System;

namespace CommandAndFactory.Commands
{
    public class ShipOrderCommand : IOrderCommand, IOrderFactory
    {
        private readonly OrderStrategyContext orderStrategyContext;

        public ShipOrderCommand(OrderStrategyContext orderStrategyContext)
        {
            this.orderStrategyContext = orderStrategyContext;
        }
        public string Name => "ShipOrder";

        public string Description => "  ShipOrder";
        public ShippingTypes ShippingType { get; private set; }
        public void Execute()
        {
            ShipOrder(ShippingType);
        }

        public IOrderCommand MakeInstance(string[] arguments)
        {
            return new ShipOrderCommand(orderStrategyContext) { ShippingType = (ShippingTypes)Enum.Parse(typeof(ShippingTypes), arguments[1]) };
        }

        public void Rollback()
        {
            CancelShipment();
        }

        private void CancelShipment()
        {
            Console.WriteLine("Shipment has been cancelled");
        }

        private void ShipOrder(ShippingTypes shippingType)
        {
            double? shippingCost = 0.0d;
            //switch (shippingType)
            //{
            //    case ShippingTypes.Aramex:
            //        shippingCost = 4.0;
            //        break;
            //    case ShippingTypes.FedEx:
            //        shippingCost = 3.25;
            //        break;
            //    case ShippingTypes.DHL:
            //        shippingCost = 4.5;
            //        break;
            //    case ShippingTypes.USPS:
            //        shippingCost = 5.5;
            //        break;
            //    default:
            //        throw new Exception("Not Supported Shipping Type");
            //}
            OrderStrategyContext orderStrategyContext = new OrderStrategyContext();
            shippingCost = orderStrategyContext.CalculateShippingCost(shippingType);

            Console.WriteLine($"Shipping Cost Over {ShippingType} is {shippingCost}");
            Console.WriteLine("Order has been shipped");
        }
    }
}
