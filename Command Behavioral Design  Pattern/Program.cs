using System;
using System.Collections.Generic;

namespace Command.Behavioral.Design.Pattern
{
    // Common Command interface
    interface ICommand
    {
        void Execute();
    }

    // Chef class
    class Chef
    {
        public void Order1()
        {
            Console.WriteLine("Chef: Client 1 order executed");
        }

        public void Order2()
        {
            Console.WriteLine("Chef: Client 2 order executed");
        }
    }

    // Concrete command Client class 1
    class Client1Order : ICommand
    {
        private Chef _chef;

        public Client1Order(Chef chef)
        {
            _chef = chef;
        }

        public void Execute()
        {
            _chef.Order1();
        }
    }

    // Concrete command Client class 2
    class Client2Order : ICommand
    {
        private Chef _chef;

        public Client2Order(Chef chef)
        {
            _chef = chef;
        }

        public void Execute()
        {
            _chef.Order2();
        }
    }

    // Waiter class
    class Waiter
    {
        private List<ICommand> _orders = new List<ICommand>();

        public void SetOrder(ICommand order)
        {
            _orders.Add(order);
        }

        public void ExecuteOrders()
        {
            foreach (var order in _orders)
            {
                order.Execute();
            }
            _orders.Clear();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create the chef
            var chef = new Chef();

            // Create the orders
            var order1 = new Client1Order(chef);
            var order2 = new Client2Order(chef);

            // Create the waiter
            var waiter = new Waiter();

            // Set the order to the waiter
            waiter.SetOrder(order1);
            waiter.SetOrder(order2);

            // Execute the orders
            waiter.ExecuteOrders();
        }
    }
}