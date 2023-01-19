namespace ASPNetMongoDB.Database;
using Microsoft.EntityFrameworkCore;
using ASPNetMongoDB.Models;
using System.Collections.Generic;

public class MongoDBContextVaror
{
    #region Private Fields

    private readonly MongoDBHandler<Vara> _dataHandler;

    #endregion Private Fields
    
    #region Public Constructors

    public MongoDBContextVaror() => _dataHandler = new MongoDBHandler<Vara>("MinaVaror", "Varor");

    #endregion Public Constructors

    #region Public Methods

    public void CreateVaror(Vara vara)
    {
        _dataHandler.Create(vara);
    }

    public void DeleteAllVaror()
    {
        _dataHandler.DeleteAll();
    }
    public void DeleteVara(string id)
    {
        _dataHandler.Delete(id);
    }

    public List<Vara> GetAllVaror()
    {
        return _dataHandler.GetAll();
    }

    public List<Vara> GetAllVaraByPodukt(string produkt)
    {
        return _dataHandler.GetAll("Produkt", produkt);
    }

    public Vara Get(string id)
    {
        return _dataHandler.Get(id);
    }

    public void UpdateVara(string id, Vara vara)
    {
        _dataHandler.Update(id, vara);
    }

    #endregion Public Methods
}