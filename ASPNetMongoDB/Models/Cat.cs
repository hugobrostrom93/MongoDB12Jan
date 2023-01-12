namespace ASPNetMongoDB.Models;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Cat
{
    /// <summary>Kattens Id på MongoDB.</summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = "";

    /// <summary>Kattens namn.</summary>
    public string Name { get; set; } = "";

    /// <summary>Kattens färg.</summary>
    public string Color { get; set; } = "";
}