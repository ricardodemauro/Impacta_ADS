using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AlunosApi.Models
{
    public class Aluno
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Nome { get; set; }

        public string Email { get; set; }
    }
}