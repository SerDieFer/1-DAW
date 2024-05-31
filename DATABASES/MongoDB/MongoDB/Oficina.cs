using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDB
{
    [BsonIgnoreExtraElements]
    internal class Oficina
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }


        [BsonElement("codOficina")]
        public string CodOffice { get; set; }

        [BsonElement("ciudad")]
        public string City { get; set; }

        [BsonElement("pais")]
        public string Country { get; set; }

        [BsonElement("codPostal")]
        public string PostalCode { get; set; }

        [BsonElement("telefono")]
        public string Phone { get; set; }

        [BsonElement("linea_direccion1")]
        public string Adress { get; set; }

    }
}
