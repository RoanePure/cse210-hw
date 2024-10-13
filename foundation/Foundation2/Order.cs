using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;
    private const float ShippingCostUSA = 5.0f;
    private const float ShippingCostInternational = 35.0f;

    public Order(Customer customer)
    {
        _products = new List<Product>();
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public float GetTotalCost()
    {
        float totalProductCost = 0;
        foreach (Product product in _products)
        {
            totalProductCost += product.GetTotalCost();
        }

        float shippingCost = _customer.IsInUSA() ? ShippingCostUSA : ShippingCostInternational;
        return totalProductCost + shippingCost;
    }

    public string GetPackagingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in _products)
        {
            label += $"Product Name: {product.Name}, Product ID: {product.ProductId}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\nCustomer: {_customer.Name}\n{_customer.Address.GetFullAddress()}";
    }
}