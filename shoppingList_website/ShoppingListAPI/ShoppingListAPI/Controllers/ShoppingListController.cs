using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Globalization;
namespace ShoppingListAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingListController : Controller
    {
        private readonly ILogger<ShoppingListController> _logger;

        public ShoppingListController(ILogger<ShoppingListController> logger)
        {
            _logger = logger;
        }
        [HttpGet("DisplayAllRecords")]
        public List<string> DisplayAll()
        {
            var documents = new GrabAll();
            List<string> itemArr = new List<string>();  
            foreach (BsonDocument doc in documents.allRecs)
            {
                var item = new ReadableItem(doc);
                itemArr.Add(item.ItemName);
            }
            return itemArr;
        }
        [HttpPost("SubmitItem")]
        public string PostItem(string itemName)
        {
            string result;
            try 
            {
                var record = new SubmitItemInit(itemName);
                record.SubmitItem();
                result = "Submitted Correctly";
            }
            catch
            {
                result = "Error";
            }
            return result;
        }
    }
}
