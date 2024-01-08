var mongoClient = new MongoClient("<Your MongoDB Connection URI>");
var mongoDatabase = mongoClient.GetDatabase("<Database Name>");

var dbContextOptions =
    new DbContextOptionsBuilder<MyDbContext>().UseMongoDB(mongoClient,
        mongoDatabase.DatabaseNamespace.DatabaseName);

var db = new MyDbContext(dbContextOptions.Options);