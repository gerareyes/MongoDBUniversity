##Homework: Homework 5.4

Removing Rural Residents

In this problem you will calculate the number of people who live in a zip code in the US where the city starts with a digit. 
We will take that to mean they don't really live in a city. Once again, 
you will be using the zip code collection, which you will find in the 'handouts' link in this page. 
Import it into your mongod using the following command from the command line:
```
mongoimport -d test -c zips --drop zips.json
```

If you imported it correctly, you can go to the test database in the mongo shell and conform that
```
db.zips.count()
```

yields 29,467 documents.

The project operator can extract the first digit from any field. 
For example, to extract the first digit from the city field, you could write this query:
```
db.zips.aggregate([
    {$project: 
     {
  first_char: {$substr : ["$city",0,1]},
     }   
   }
])
```

Using the aggregation framework, 
calculate the sum total of people who are living in a zip code where the city starts with a digit. 
Choose the answer below.

You will need to probably change your projection to send more info through than just that first character. 
Also, you will need a filtering step to get rid of all documents where the city does not start with a digital (0-9).

Note: When you mongoimport the data, 
you will probably see a few duplicate key errors; this is to be expected, 
and will not prevent the mongoimport from working. 
There is also an issue with some versions of MongoDB 3.0 where it claims that 0 documents were mongoimported, 
when in fact there were 29,467 documents imported. 
You can verify this for yourself by going into the shell and counting the documents in the "test.zips" collection.