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

Find all exam scores greater than or equal to 65, and sort those scores from lowest to highest
```
db.getCollection('grades').find({'score': {'$gte':65}}).sort({'score':1}).limit(1).pretty()
```

The previous query result will show you the answer.