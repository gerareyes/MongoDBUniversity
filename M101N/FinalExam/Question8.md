##MongoDB M101N Final Exam Question 8
Question 8:

Supposed we executed the following C# code. How many animals will be inserted into the "animals" collection? 

using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace M101DotNet
{
    class InsertTest
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("test");

            var animals = db.GetCollection<BsonDocument>("animals");

            var animal = new BsonDocument
                            {
                            {"animal", "monkey"}
                            };

            await animals.InsertOneAsync(animal);
            animal.Remove("animal");
            animal.Add("animal", "cat");
            animal["_id"] = ObjectId.GenerateNewId();
            await animals.InsertOneAsync(animal);
            animal.Remove("animal");
            animal.Add("animal", "lion");
            animal["_id"] = ObjectId.GenerateNewId();
            await animals.InsertOneAsync(animal);
        }
    }
}

Options:

1.- 0
2.- 1
3.- 2
4.- 3