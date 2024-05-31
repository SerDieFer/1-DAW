using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization;

namespace MongoDB
{
    internal class Program
    {
    

        static void Main(string[] args)
        {
            MongoClient mongoClient = new MongoClient("mongodb+srv://serdiefer:1234@serdiefer-pruebas.bmitp6y.mongodb.net/");
            var database = mongoClient.GetDatabase("test");
            var collection = database.GetCollection<BsonDocument>("oficinas");

            var filter = Builders<BsonDocument>.Filter.Eq("ciudad", "Valencia");

            var oficina = collection.Find(filter).FirstOrDefault();

            Oficina ofic = BsonSerializer.Deserialize<Oficina>(oficina);
            StringBuilder sb = new StringBuilder();

            sb.Append(ofic.CodOffice);
            sb.Append(ofic.City);
            sb.Append(ofic.Country);
            sb.Append(ofic.Phone);
            sb.Append(ofic.Adress);
            sb.Append(ofic.PostalCode);
            Console.WriteLine(sb);
            Console.ReadLine();

        }

        /*
        public void PrintDBList()
        {
            List<BsonDocument> dbList = mongoClient.ListDatabases().ToList();

            foreach (BsonDocument db in dbList)
            {
                Console.WriteLine(db);
            }
            Console.ReadLine();
        }
        */
    }
}
