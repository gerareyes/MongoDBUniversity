##Homework: Homework 5.1 (Hands On)

Finding the most frequent author of comments on your blog

In this assignment you will use the aggregation framework to find the most frequent author of comments on your blog. 
We will be using the same basic dataset as last week, with posts and comments shortened considerably, 
and with many fewer documents in the collection in order to streamline the operations of the Hands On web shell.

Use the aggregation framework in the web shell to calculate the author with the greatest number of comments.

Just to clarify, the data set for this week is not available for download.

To help you verify your work before submitting, the author with the fewest comments is Cody Strouth and he commented 68 times.

Once you've found the correct answer with your query, please choose your answer below for the most prolific comment author.

Note: this data set is relatively large. Due to some quirks of the shell, 
the entire result set gets pulled into the browser on find(), so if you want to see the document schema, 
we recommend either using db.posts.findOne(), db.posts.find().limit(1),
or that you plan on waiting for a bit after you hit enter. 
We also recommend that the last phase of your aggregation pipeline is {$limit: 1} (or some single digit number)