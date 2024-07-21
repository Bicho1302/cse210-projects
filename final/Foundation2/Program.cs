using System;
using System.Collections.Generic;
using System.Text;

// Address class
public class Address
{
    private string streetAddress;
    private string city;
    private string state;
    private string country;

    public Address(string streetAddress, string city, string state, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddress()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(streetAddress);
        sb.AppendLine($"{city}, {state}");
        sb.AppendLine(country);
        return sb.ToString();
    }
}

// Customer class
public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string GetName()
    {
        return name;
    }

    public Address GetAddress()
    {
        return address;
    }

    public bool LivesInUSA()
    {
        return address.IsInUSA();
    }
}

// Product class
public class Product
{
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return price * quantity;
    }

    public string GetProductDetails()
    {
        return $"Name: {name}, Product ID: {productId}, Price: {price:C}, Quantity: {quantity}";
    }

    public string GetProductId()
    {
        return productId;
    }
}

// Order class
public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal CalculateTotalPrice()
    {
        decimal total = 0;
        foreach (Product product in products)
        {
            total += product.GetTotalCost();
        }

        // Add shipping cost
        decimal shippingCost = customer.LivesInUSA() ? 5 : 35;
        total += shippingCost;

        return total;
    }

    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        foreach (Product product in products)
        {
            sb.AppendLine($"Product ID: {product.GetProductId()}, Name: {product.GetProductDetails()}");
        }
        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        return $"Customer Name: {customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Elm St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create products
        Product product1 = new Product("Laptop", "P001", 999.99m, 1);
        Product product2 = new Product("Mouse", "P002", 25.50m, 2);
        Product product3 = new Product("Keyboard", "P003", 45.00m, 1);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // Display order details
        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());

        Console.WriteLine($"Total Price: {order.CalculateTotalPrice():C}");
        Console.WriteLine();
    }
}
