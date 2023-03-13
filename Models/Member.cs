using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace CPMApi.Models;

public class Member
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonRequired]
    [BsonElement("FirstName")]
    [JsonPropertyName("FirstName")]
    public string FirstName { get; set; } = null!;

    [BsonElement("LastName")]
    [JsonPropertyName("LastName")]
    [BsonDefaultValue("")]
    public string LastName { get; set; } = "";

    [BsonElement("Phone")]
    [JsonPropertyName("Phone")]
    [BsonDefaultValue("")]
    public string Phone { get; set; } = "";

    /*public Member cloneMember(){
        Member newMember = new Member();

        newMember.Id = this.Id;
        newMember.FirstName = this.FirstName;
        newMember.LastName = this.LastName;
        newMember.PhoneNumber = this.PhoneNumber;

        return newMember;
    }*/
}