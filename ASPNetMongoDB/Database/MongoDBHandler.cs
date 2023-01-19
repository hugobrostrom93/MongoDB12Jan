namespace ASPNetMongoDB.Database;

using MongoDB.Bson;
using MongoDB.Driver;

public class MongoDBHandler<T>
{
    private static string connString = "";
    private readonly IMongoCollection<T> _collection;
    private readonly IMongoDatabase _database;

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

    public void Create(T obj)
    {
        _collection.InsertOne(obj);
    }

    public void Delete(string id)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        _ = _collection.DeleteOne(filter);
    }

    public T Get(string id)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        return _collection.Find(filter).FirstOrDefault();
    }

    public T GetByValue(string key, string value)
    {
        var filter = Builders<T>.Filter.Eq(key, value);
        return _collection.Find(filter).FirstOrDefault();
    }

    public List<T> GetAll()
    {
        return _collection.Find(new BsonDocument()).ToList();
    }

    /// <returns></returns>
    public List<T> GetAll(string key, string value)
    {
        var filter = Builders<T>.Filter.Eq(key, value);
        return _collection.Find(filter).ToList();
    }

    public void Update(string id, T obj)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        _ = _collection.ReplaceOne(filter, obj);
    }

    internal void DeleteAll()
    {
        _ = _collection.DeleteMany(new BsonDocument());
    }
    
    internal void DeleteAll(string key, string value)
    {
        var filter = Builders<T>.Filter.Eq(key, value);
        _ = _collection.DeleteMany(filter);
    }
}