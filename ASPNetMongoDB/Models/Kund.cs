namespace ASPNetMongoDB.Models;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Kund
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = "";
    public string Namn { get; set; } = "";
    public string Adress { get; set; } = "";
    public string Emailadress { get; set; } = "";
    public string Telefonnummer { get; set; } = "";
    public List<Order> Orders { get; set; } = new List<Order>();
}