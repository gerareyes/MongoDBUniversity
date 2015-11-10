##HOMEWORK: HOMEWORK 4.4

In this problem you will analyze a profile log taken from a mongoDB instance. 
To start, please download sysprofile.json from Download Handout link and import it with the following command:

```
mongoimport -d m101 -c profile < sysprofile.json
```

Now query the profile data, looking for all queries to the students collection in the database school2, 
sorted in order of decreasing latency. What is the latency of the longest running operation to the collection, in milliseconds?

O 19776550
O 10000000
O 5580001
O 15820
O 2350