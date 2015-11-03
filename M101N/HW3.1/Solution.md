Using Windows Commandline

Run mongodb Server
```
mongod
```

Restore database
```
mongoimport -d school -c students < students.json
```

Enter to mongodb shell
```
mongo
```

Inside mongo shell, switch to students database
```
use students
```

Remove the lowest homework score for each student
```
var cursor = db.students.aggregate({'$unwind': '$scores'}, {'$match': {'scores.type': 'homework'}}, {'$group': {'_id' :'$_id', 'minimum': {$min: '$scores.score'}}}, {'$sort': {'_id': 1}});

while (cursor.hasNext()) { cur = cursor.next(); db.students.update({"_id": cur._id}, {"$pull": {"scores": {"score": cur.minimum} } } )}
```

To verify that you have completed this task correctly, 
provide the identity (in the form of their _id) of the student with the highest average in the class with following query that uses the aggregation framework. 
The answer will appear in the _id field of the resulting document.

```
db.students.aggregate( { '$unwind' : '$scores' } , { '$group' : { '_id' : '$_id' , 'average' : { $avg : '$scores.score' } } } , { '$sort' : { 'average' : -1 } } , { '$limit' : 1 } )
```
