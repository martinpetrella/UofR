// See https://aka.ms/new-console-template for more information

using BusinessLayerLibrary;
using System.Runtime.CompilerServices;

MixInManager mixInManager = new MixInManager();
mixInManager.AddMixIn("Reece's Pieces");
printMixIns();

OrderManager orderManager = new OrderManager();

orderManager.StartOrder("Mindy", DateTime.Now, DateTime.Now + TimeSpan.FromHours(4));
orderManager.AddCookies(1, mixInManager.MixIns[0]);
orderManager.AddCookies(2, mixInManager.MixIns[2], mixInManager.MixIns[3]);
orderManager.EndOrder();

orderManager.StartOrder("Marty", DateTime.Now + TimeSpan.FromDays(2), DateTime.Now + TimeSpan.FromDays(4));
orderManager.AddCookies(1, mixInManager.MixIns[3]);
orderManager.AddCookies(1, mixInManager.MixIns[1], mixInManager.MixIns[2]);
orderManager.EndOrder();

orderManager.StartOrder("Marty", DateTime.Now + TimeSpan.FromDays(7), DateTime.Now + TimeSpan.FromDays(8));
orderManager.AddCookies(1, mixInManager.MixIns[3]);
orderManager.EndOrder();

printCustomers();
printOrders();

void printMixIns()
{
    Console.WriteLine("MixIns");
    Console.WriteLine("-----------------------");
    foreach (var mixIn in mixInManager.MixIns)
    {
        System.Console.WriteLine(mixIn.ToString());
    }
    Console.WriteLine("-----------------------");
}

void printOrders()
{
    Console.WriteLine("Orders");
    Console.WriteLine("-----------------------");
    foreach (var order in orderManager.Orders)
    {
        System.Console.WriteLine(order.CustomerName);
        System.Console.WriteLine(order.OrderDateTime);
        System.Console.WriteLine(order.PickupDateTime);

        foreach (CookieDetails cookie in order.Cookies)
        {
            System.Console.WriteLine(cookie.NumberOfDozen);

            foreach (string mixIn in cookie.MixIns)
            {
                System.Console.WriteLine(mixIn);
            }
        }
    }
    Console.WriteLine("-----------------------");
}

void printCustomers()
{
    Console.WriteLine("Customers");
    Console.WriteLine("-----------------------");
    foreach (string customer in orderManager.Customers)
    {
        Console.WriteLine(customer);
    }
    Console.WriteLine("-----------------------");
}

