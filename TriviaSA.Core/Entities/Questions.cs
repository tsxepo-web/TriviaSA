using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaSA.Core.Entities
{
    public class Questions
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } 
        public string Question { get; set; } = string.Empty;
        public List<string> Options { get; set; } = [];
        public string CorrectAnswer { get; set; } = string.Empty;
        public List<string> Distractors { get; set; } = [];
    }
}
