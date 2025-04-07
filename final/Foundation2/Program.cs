using System;

class Program
{
    static void Main()
    {
        // Create first order
        Address address1 = new Address("123 Elm St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Widget", "W01", 2.50m, 4));
        order1.AddProduct(new Product("Gizmo", "G02", 5.75m, 2));

        // Create second order
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Doohickey", "D03", 3.20m, 5));
        order2.AddProduct(new Product("Thingamabob", "T04", 7.80m, 1));

        // Display results
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():0.00}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():0.00}");
    }
}