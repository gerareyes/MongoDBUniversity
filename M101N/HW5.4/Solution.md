Using the shell in the website, run the next query:

```
db.posts.aggregate([
    { $unwind: "$comments" },
    { $group: { _id: "$comments.author", count: { $sum: 1 } } },
    { $sort: { count: -1 } },
    { $limit: 1 }
])
```

Using Windows Commandline

Run server
```
mongod
```

Restore database
```
mongoimport -d test -c zips --drop zips.json
```

Enter to mongodb shell
```
mongo
```

Inside mongo shell, switch to m101 database
```
use zips
```

run
```
db.zips.aggregate([
    { $project: { _id: 0, city: 1, pop: 1 } },
    { $match: { city: /^\d.*/ } },
    { $group: { _id: null, pop: { $sum: "$pop" } } },
    { $sort: { city: 1} }
])
```