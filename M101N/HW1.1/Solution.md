// Using Windows Commandline

// Run mongodb Server
```
mongod
```

// Restore database
```
mongorestore dump
```

// Enter to mongodb shell
```
mongo
```

// Inside mongo shell, switch to m101 database
```
use m101
```

// Get 1 record from hw1 collection
```
db.hw1.findOne()
```

// Previous query result
```
{
  "_id" : ObjectId("50773061bf44c220307d8514"),
  "answer" : 42,
  "question" : "The Ultimate Question of Life, The Universe and Everything"
}
```

// Answer
```
42
```
