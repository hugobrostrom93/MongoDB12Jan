namespace ASPNetMongoDB.Database;

using MongoDB.Bson;
using MongoDB.Driver;

public class MongoDBHandler<T>
{
    private static string connString = "";
    private readonly IMongoCollection<T> _collection;
    private readonly IMongoDatabase _database;

    /// <summary>
    /// Initierar klassen med namnet på databasen och namnet på samlingen.
    /// </summary>
    /// <param name="databaseName">Namnet på databasen som ska användas</param>
    /// <param name="collectionName">Namnet på Collection som ska användas</param>
    public MongoDBHandler(string databaseName, string collectionName)
    {
        if (connString.Length == 0)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MongoDBConnectionString.txt");
            if (File.Exists(path))
                connString = File.ReadAllText(path);
            else
                connString = "mongodb://localhost:27017";
        }

        var client = new MongoClient(connString);
        _database = client.GetDatabase(databaseName);

        var collections = _database.ListCollections().ToList();

        if (!collections.Any(c => c.GetValue("name").ToString() == collectionName))
        {
            _database.CreateCollection(collectionName);
        }
        _collection = _database.GetCollection<T>(collectionName);
    }

    //CRUD methods
    /// <summary>
    /// Skapar en ny dokument i samlingen.
    /// </summary>
    /// <param name="obj">Objektet som ska sparas</param>
    public void Create(T obj)
    {
        _collection.InsertOne(obj);
    }

    /// <summary>
    /// Raderar ett dokument i samlingen.
    /// </summary>
    /// <param name="id">Id på objektet</param>
    public void Delete(string id)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        _ = _collection.DeleteOne(filter);
    }

    /// <summary>
    /// Hämtar ett dokument
    /// </summary>
    /// <param name="id">Id på dokumentet</param>
    /// <returns>Ett objekt eller NULL</returns>
    public T Get(string id)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        return _collection.Find(filter).FirstOrDefault();
    }

    /// <summary>
    /// Hämtar ett objekt enligt givna parametrar
    /// </summary>
    /// <param name="key">Nyckel som det ska filtreras på</param>
    /// <param name="value">Värde man ska söka på</param>
    /// <returns></returns>
    public T GetByValue(string key, string value)
    {
        var filter = Builders<T>.Filter.Eq(key, value);
        return _collection.Find(filter).FirstOrDefault();
    }

    /// <summary>
    /// Hämtar alla dokument i collection
    /// </summary>
    /// <returns>En lista av dokument</returns>
    public List<T> GetAll()
    {
        return _collection.Find(new BsonDocument()).ToList();
    }

    /// <summary>
    /// Hämta alla matchande dokument
    /// </summary>
    /// <param name="key">Nyckel som det ska filtreras på</param>
    /// <param name="value">Värde man ska söka på</param>
    /// <returns></returns>
    public List<T> GetAll(string key, string value)
    {
        var filter = Builders<T>.Filter.Eq(key, value);
        return _collection.Find(filter).ToList();
    }

    /// <summary>
    /// Uppdatera ett dokument
    /// </summary>
    /// <param name="id">Id till dokumentet</param>
    /// <param name="obj">Objekt med informationen som ska uppdateras</param>
    public void Update(string id, T obj)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        _ = _collection.ReplaceOne(filter, obj);
    }

    /// <summary>
    /// Raderar alla dokument i din Collection!!!
    /// </summary>
    internal void DeleteAll()
    {
        _ = _collection.DeleteMany(new BsonDocument());
    }

    /// <summary>
    /// Radera alla som matchar givna parametrar
    /// </summary>
    /// <param name="key">Nyckel som det ska filtreras på</param>
    /// <param name="value">Värde man ska söka på</param>
    internal void DeleteAll(string key, string value)
    {
        var filter = Builders<T>.Filter.Eq(key, value);
        _ = _collection.DeleteMany(filter);
    }
}