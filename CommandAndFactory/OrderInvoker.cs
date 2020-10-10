using CommandAndFactory.Interfaces;
using System;
using System.Collections.Generic;

namespace CommandAndFactory
{
    internal class OrderInvoker
    {
        Stack<IOrderCommand> commandsStack;
        public OrderInvoker()
        {
            commandsStack = new Stack<IOrderCommand>();
        }

        internal void Invoke(IOrderCommand cmd)
        {
            cmd.Execute();
            commandsStack.Push(cmd);
        }

        internal void Undo()
        {
            var cmd = commandsStack.Pop();
            cmd.Rollback();
        }
    }
}