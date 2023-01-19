namespace ASPNetMongoDB.Models;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Vara
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = "";
    public string Produkt { get; set; } = "";
    public string Pris { get; set; } = "";
}