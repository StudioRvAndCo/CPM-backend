using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace CPMApi.Models;

public class Character
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("FirstName")]
    [JsonPropertyName("FirstName")]
    [BsonDefaultValue("")]
    public string FirstName { get; set; } = "";

    [BsonElement("LastName")]
    [JsonPropertyName("LastName")]
    [BsonDefaultValue("")]
    public string LastName { get; set; } = "";
}