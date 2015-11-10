O db.products.find( { 'brand' : "GE" } )
0 db.products.find( { $and : [ { price : { $gt : 30 } },{ price : { $lt : 50 } } ] } ).sort( { brand : 1 } )
0 db.products.find( { 'brand' : "GE" } ).sort( { price : 1 } )
O db.products.find( { brand : 'GE' } ).sort( { category : 1, brand : -1 } )