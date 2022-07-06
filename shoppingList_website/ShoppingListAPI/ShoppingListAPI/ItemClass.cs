using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
namespace ShoppingListAPI.Controllers
{
    public abstract class Item
    {
        public string ItemName;
    }
    public class ReadableItem : Item
    {
        public string ItemName { get; }
        public ReadableItem(BsonDocument bsonDoc)
        {
            this.ItemName = bsonDoc.GetValue("item_name").ToString();
        }
    }
    public class GrabAll
    {
        public List<BsonDocument> allRecs { get; }
        public GrabAll()
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://dbuser:dbuser@cluster0.sssd1.mongodb.net/?retryWrites=true&w=majority");
            var database = dbClient.GetDatabase("testdb");
            var collection = database.GetCollection<BsonDocument>("shopping_list");
            var documents = collection.Find(new BsonDocument()).ToList();
            this.allRecs = documents;
        }
    }
    public class SubmitItemInit: Item
    {
        public string ItemName { get; }
        public BsonDocument Record { get; } 
        public SubmitItemInit(string item)
        {
            this.ItemName = item;
            this.Record = new BsonDocument { {"item_name" , this.ItemName} };
        }
        public void SubmitItem()
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://dbuser:dbuser@cluster0.sssd1.mongodb.net/?retryWrites=true&w=majority");
            var database = dbClient.GetDatabase("testdb");
            var collection = database.GetCollection<BsonDocument>("shopping_list");
            collection.InsertOne(this.Record);
        }
    }
}
