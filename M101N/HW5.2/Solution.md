Using the shell in the website, run the next query:

```
db.zips.aggregate([
    { $match: {$or: [ {state: "CA"}, {state: "NY"} ] } },
    { $group: { _id: { city: "$city" }, pop: { $sum: "$pop" } } },
    { $match: { "pop": { $gt: 25000 } } },
    { $group: { _id: null, avg_pop_of_city: { $avg: "$pop" } } }
])
```