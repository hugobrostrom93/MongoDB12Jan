namespace ASPNetMongoDB.Database;
using Microsoft.EntityFrameworkCore;
using ASPNetMongoDB.Models;
using System.Collections.Generic;

public class MongoDBContextKunder
{
    #region Private Fields

    private readonly MongoDBHandler<Kund> _dataHandler;

    #endregion Private Fields

    #region Public Constructors

    public MongoDBContextKunder() => _dataHandler = new MongoDBHandler<Kund>("MinaKunder", "Kunder");

    #endregion Public Constructors

    #region Public Methods

    public void CreateKund(Kund kund)
    {
        _dataHandler.Create(kund);
    }

    public void DeleteAllKunder()
    {
        _dataHandler.DeleteAll();
    }
    
    public void DeleteKund(string id)
    {
        _dataHandler.Delete(id);
    }

    public List<Kund> GetAllKunder()
    {
        return _dataHandler.GetAll();
    }

    public List<Kund> GetAllOrdersByName(string namn)
    {
        return _dataHandler.GetAll("Namn", namn);
    }

    public Kund Get(string id)
    {
        return _dataHandler.Get(id);
    }

    public void UpdateKund(string id, Kund namn)
    {
        _dataHandler.Update(id, namn);
    }

    #endregion Public Methods
}