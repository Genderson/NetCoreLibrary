using MongoDB.Bson.Serialization.Attributes;

namespace Services.api.Library.Core.Entities
{
    [BsonCollection("Empleado")]
    public class EmpleadoEntity : Document
    {
        [BsonElement("nombre")]
        public string Nombre { get; set; }
    }
}
