using MongoDB.Bson.Serialization.Attributes;

namespace CourseAppMicroservice.Catalog.Api.Repositories;

public class BaseEntity
{
    //snow flakes algorithm
    [BsonElement("_id")]
    public Guid Id { get; set; }
}