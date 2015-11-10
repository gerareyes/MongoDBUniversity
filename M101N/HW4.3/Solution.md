Using Windows Commandline

Run server
```
mongod
```

Restore database
```
mongorestore dump
```

Enter to mongodb shell
```
mongo
```

Inside mongo shell, switch to m101 database
```
use blog
```

Create index
```
db.posts.ensureIndex({CreatedAtUtc:1})
db.posts.ensureIndex({Tags:1}) 
db.posts.ensureIndex({Tags:1,CreatedAtUtc:1})
```

the just run MongoProc