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
    public class OrderFactory
    {
        private readonly List<IOrderFactory> orderFactory;

        public OrderFactory(List<IOrderFactory> orderFactory)
        {
            this.orderFactory = orderFactory;
        }
        public IOrderCommand CreateInstance(string[] args)
        {
            IOrderCommand cmd = null;
            var commandName = args[0];
            List<IOrderFactory> allCommands = orderFactory;
            var cmdFactory = allCommands.FirstOrDefault(p => p.Name == commandName);
            cmd = cmdFactory.MakeInstance(args) ;
            
            return cmd;
        }

        
    }
}
