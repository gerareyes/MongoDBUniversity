0 There must be a index on the collection that starts with the shard key.
0 Any update that does not contain the shard key will be sent to all shards.
O The shard key must be unique
0 MongoDB can not enforce unique indexes on a sharded collection other than the shard key itself, or indexes prefixed by the shard key.
O You can change the shard key on a collection if you desire.