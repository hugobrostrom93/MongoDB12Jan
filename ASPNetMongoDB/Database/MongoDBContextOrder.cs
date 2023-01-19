namespace ASPNetMongoDB.Database;
using Microsoft.EntityFrameworkCore;
using ASPNetMongoDB.Models;
using System.Collections.Generic;

public class MongoDBContextOrder
{
    #region Private Fields
    
    private readonly MongoDBHandler<Order> _dataHandler;

    #endregion Private Fields

    #region Public Constructors
    
    public MongoDBContextOrder() => _dataHandler = new MongoDBHandler<Order>("MinaOrdrar", "Ordrar");

    #endregion Public Constructors

    #region Public Methods
    
    public void CreateOrder(Order order)
    {
        _dataHandler.Create(order);
    }

    public void DeleteAllOrders()
    {
        _dataHandler.DeleteAll();
    }

    public void DeleteOrder(string id)
    {
        _dataHandler.Delete(id);
    }

    public List<Order> GetAllOrders()
    {
        return _dataHandler.GetAll();
    }

    public List<Order> GetAllOrdersByPerson(string person)
    {
        return _dataHandler.GetAll("Person", person);
    }

    public Order Get(string id)
    {
        return _dataHandler.Get(id);
    }

    public void UpdateOrder(string id, Order order)
    {
        _dataHandler.Update(id, order);
    }
    
    #endregion Public Methods
}