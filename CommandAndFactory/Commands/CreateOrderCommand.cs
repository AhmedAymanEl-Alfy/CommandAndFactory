using CommandAndFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandAndFactory.Commands
{
    public class CreateOrderCommand : IOrderCommand, IOrderFactory
    {
        public string Name => "CreateOrder";

        public string Description => "  CreateOrder";

        public void Execute()
        {
            CreateOrder();
        }

        public IOrderCommand MakeInstance(string[] arguments)
        {
            return new CreateOrderCommand();
        }

        public void Rollback()
        {
            DeleteOrder();
        }

        private void DeleteOrder()
        {
            Console.WriteLine("Order has been deleted.");
        }

        private void CreateOrder()
        {
            Console.WriteLine("Order has been created");
        }
    }
}
