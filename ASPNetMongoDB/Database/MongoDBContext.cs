// Detta är en klass som används för att hantera databasoperationer i MongoDB.
// Det finns flera olika metoder i denna klass för att hantera CRUD-operationer (skapa, läsa, uppdatera, radera) för katter.
// De metoder som finns är: CreateCat, DeleteAllCats, DeleteAllCatsByColor, DeleteCat, GetAllCats, GetAllCatsByColor, GetCat och UpdateCat.

namespace ASPNetMongoDB.Database;

using ASPNetMongoDB.Models;
using System.Collections.Generic;

/// <summary>
/// Klassen ansvarar för att hantera databasoperationer i MongoDB.
/// </summary>
public class MongoDBContext
{
    #region Private Fields

    // Denna fält håller MongoDBHandler<Cat> objektet, för att kommunicera med databasen.
    private readonly MongoDBHandler<Cat> _catHandler;

    #endregion Private Fields

    #region Public Constructors

    public MongoDBContext() => _catHandler = new MongoDBHandler<Cat>("MyCats", "Cats");

    #endregion Public Constructors

    #region Public Methods

    //CRUD methods
    /// <summary>
    /// Skapar ett nytt katt-objekt och sparar i databasen
    /// </summary>
    /// <param name="cat">Katt-objektet som ska sparas</param>
    public void CreateCat(Cat cat)
    {
        _catHandler.Create(cat);
    }

    /// <summary>
    /// Raderar alla katter från databasen
    /// </summary>
    public void DeleteAllCats()
    {
        _catHandler.DeleteAll();
    }

    /// <summary>
    /// Raderar alla katter med angiven färg från databasen
    /// </summary>
    /// <param name="color">Färgen på kattarna som ska raderas</param>
    public void DeleteAllCatsByColor(string color)
    {
        _catHandler.DeleteAll("Color", color);
    }

    /// <summary>
    /// Raderar en katt med angiven id från databasen
    /// </summary>
    /// <param name="id">Id på katten som ska raderas</param>
    public void DeleteCat(string id)
    {
        _catHandler.Delete(id);
    }

    /// <summary>
    /// Hämtar alla katter från databasen
    /// </summary>
    /// <returns>En lista med alla katter i databasen</returns>
    public List<Cat> GetAllCats()
    {
        return _catHandler.GetAll();
    }

    /// <summary>
    /// Hämtar alla katter med angiven färg från databasen
    /// </summary>
    /// <param name="color">Färgen på kattarna som ska hämtas</param>
    /// <returns>En lista med alla katter med angiven färg i databasen</returns>
    public List<Cat> GetAllCatsByColor(string color)
    {
        return _catHandler.GetAll("Color", color);
    }

    /// <summary>
    /// Hämtar en katt med angiven id från databasen
    /// </summary>
    /// <param name="id">Id på katten som ska hämtas</param>
    /// <returns>Katt-objektet med angiven id</returns>
    public Cat GetCat(string id)
    {
        return _catHandler.Get(id);
    }

    /// <summary>
    /// Uppdaterar en katt med angiven id och uppdateringsdata
    /// </summary>
    /// <param name="id">Id på katten som ska uppdateras</param>
    /// <param name="cat">Katt-objektet med nya data</param>
    public void UpdateCat(string id, Cat cat)
    {
        _catHandler.Update(id, cat);
    }

    #endregion Public Methods
}