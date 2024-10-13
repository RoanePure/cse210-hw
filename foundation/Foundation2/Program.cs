using System;

class Program
{
    static void Main(string[] args)
    {
        // Create address objects
        Address address1 = new Address("789 Birch Lane", "Los Angeles", "CA", "USA");
        Address address2 = new Address("987 Willow Road", "Sydney", "NSW", "Australia");

        // Create customer objects
        Customer customer1 = new Customer("Sean Brown", address1);
        Customer customer2 = new Customer("Yan Ortiz", address2);

        // Create product objects
        Product product1 = new Product("Laptop Bag", 111, 35.25f, 3);
        Product product2 = new Product("Gaming Chair", 112, 120.50f, 1);
        Product product3 = new Product("Mouse Pad", 113, 15.20f, 2);

        // Create order objects
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);

        // Display Order 1
        Console.WriteLine(order1.GetPackagingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():0.00}\n");

        // Display Order 2
        Console.WriteLine(order2.GetPackagingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():0.00}\n");
    }
}