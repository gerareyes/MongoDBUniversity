Using Windows Commandline

Run mongodb Server
```
mongod
```

Restore database
```
mongoimport -d students -c grades < grades.json
```

Enter to mongodb shell
```
mongo
```

Inside mongo shell, switch to students database
```
use students
```

Remove the grade of type "homework" with the lowest score for each student from the dataset in the handout
```
var student_id;
db.grades.find().sort({'student_id':1, 'score':1}).forEach( function(myDoc) { if (student_id != myDoc.student_id && myDoc.type == 'homework') {student_id = myDoc.student_id; db.grades.remove({"_id": myDoc._id})} } );
```

Let us count the number of grades we have:
```
db.grades.count() 
```

The result should be 600.

the identity of the student with the highest average in the class with following query that uses the aggregation framework. 
The answer will appear in the _id field of the resulting document. 
```
db.grades.aggregate( { '$group' : { '_id' : '$student_id', 'average' : { $avg : '$score' } } }, { '$sort' : { 'average' : -1 } }, { '$limit' : 1 } )
```