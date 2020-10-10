using CommandAndFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandAndFactory.Commands
{
    public class UpdateQuantityCommand : IOrderCommand, IOrderFactory
    {
        public int NewQuantity { get; set; }
        public string Name => "UpdateQuantity";

        public string Description => "  UpdateQuantity number";

        public void Execute()
        {
            UpdateQuantity(NewQuantity);
        }

        public IOrderCommand MakeInstance(string[] arguments)
        {
            return new UpdateQuantityCommand() { NewQuantity = int.Parse(arguments[1]) };
        }

        public void Rollback()
        {
            UndoUpdate();
        }

        private void UndoUpdate()
        {
            //TODO: Get the old quantity from the DB
            int oldQuantity = 5;
            //TODO: Update the DB with the new quantity
            Console.WriteLine($"Quantity has been updated from {NewQuantity} to {oldQuantity}");
            Console.WriteLine("DB has been updated successfully");
        }

        private void UpdateQuantity(int newQuantity)
        {
            //TODO: Get the old quantity from the DB
            int oldQuantity = 5;
            //TODO: Update the DB with the new quantity
            Console.WriteLine($"Quantity has been updated from {oldQuantity} to {newQuantity}");
            Console.WriteLine("DB has been updated successfully");
        }
    }
}
