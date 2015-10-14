##HOMEWORK: HOMEWORK 1.1

Install MongoDB on your computer and run it on the standard port.

Download the HW1-1 from the Download Handout link and uncompress it.

[Handout link](https://github.com/gerareyes/MongoDBUniversity/tree/master/M101N/HW1.1/dump)

Use mongorestore to restore the dump into your running mongod. Do this by opening a terminal window (mac) or cmd window (windows) and navigating to the directory so that you are in the parent directory of the dump directory (if you used the default extraction method, it should be hw1/). Now type:

```
mongorestore dump
```

Note you will need to have your path setup correctly to find mongorestore.

Next, go into the Mongo shell, perform a findOne on the collection called hw1 in the database m101. That will return one document. Please provide the value corresponding to the "answer" key from the document returned.

hint: if you get back a document that looks like { "_id": 1234, "answer": 2468 }, please only put in 2468 (with no spaces) for your answer.
