namespace ASPNetMongoDB.Models;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = "";
    public string KundId { get; set; } = ""; 
    public string Namn { get; set; } = "";
}