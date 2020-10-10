using CommandAndFactory.Commands;
using CommandAndFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandAndFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = GetAvailableCommands();
            if (args.Length == 0)
            {
                ShowAvailableCommands(commands);
                return;
            }

            //ExecuteCommand(args);
            OrderFactory factory = new OrderFactory(commands);
            var cmd = factory.CreateInstance(args);

            OrderInvoker invoker = new OrderInvoker();
            invoker.Invoke(cmd);

            //cmd = factory.CreateInstance(new string[] { "ShipOrder" });
            //invoker.Invoke(cmd);

            //cmd = factory.CreateInstance(new string[] { "UpdateQuantity", "22" });
            //invoker.Invoke(cmd);

            //invoker.Undo();
            //invoker.Undo();
            //invoker.Undo();


            //cmd.Execute();
        }

        //private static void ExecuteCommand(string[] args)
        //{
        //    IOrderCommand cmd = null;
        //    switch (args[0])
        //    {
        //        case "CreateOrder":
        //            cmd = new CreateOrderCommand();
        //            break;
        //        case "UpdateQuantity":
        //            //UpdateQuantity(int.Parse(args[1]));
        //            cmd = new UpdateQuantityCommand();
        //            (cmd as UpdateQuantityCommand).NewQuantity = int.Parse(args[1]);
        //            break;
        //        case "ShipOrder":
        //            //ShipOrder();
        //            cmd = new ShipOrderCommand();
        //            break;
        //        default:
        //            break;
        //    }
        //    cmd.Execute();
        //}

        //private static void ShipOrder()
        //{
        //    Console.WriteLine("Order has been shipped");
        //}

        //private static void UpdateQuantity(int newQuantity)
        //{
        //    //TODO: Get the old quantity from the DB
        //    int oldQuantity = 5;
        //    //TODO: Update the DB with th enew quantity
        //    Console.WriteLine($"Quantity has been updated from {oldQuantity} to {newQuantity}");
        //    Console.WriteLine("DB has been updated successfully");
        //}

        //private static void CreateOrder()
        //{
        //    Console.WriteLine("Order has been created");
        //}

        private static void ShowAvailableCommands(List<IOrderFactory> commands)
        {
            Console.WriteLine("Executable <command> <arguments>");
            Console.WriteLine("Commands: ");
            foreach (var cmd in commands)
            {
                Console.WriteLine(cmd.Description);
            }
            //Console.WriteLine("     CreateOrder");
            //Console.WriteLine("     UpdateQuantity number");
            //Console.WriteLine("     ShipOrder");

        }

        private static List<IOrderFactory> GetAvailableCommands()
        {
            List<IOrderFactory> orderCommands = new List<IOrderFactory>();
            var allTypes = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var t in allTypes)
            {
                if (t.GetInterface(typeof(IOrderFactory).Name) != null)
                {
                    orderCommands.Add(Activator.CreateInstance(t) as IOrderFactory);
                }
            }
            return orderCommands;
        }
    }
}
