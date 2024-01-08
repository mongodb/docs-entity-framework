using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using MongoDB.EntityFrameworkCore.Extensions;

// start-use-mongodb
var mongoClient = new MongoClient("<Your MongoDB Connection URI>");
var mongoDatabase = mongoClient.GetDatabase("<Database Name>");

var dbContextOptions =
    new DbContextOptionsBuilder<MyDbContext>().UseMongoDB(mongoClient,
        mongoDatabase.DatabaseNamespace.DatabaseName);

var db = new MyDbContext(dbContextOptions.Options);
// end-use-mongodb

db.Customers.Add(new Customer() { name = "John Doe", Order = "1 Green Tea" });
db.SaveChanges();

// start-customer
internal class Customer
{
    public ObjectId Id { get; set; }
    public String Name { get; set; }
    public String Order { get; set; }
}
// end-customer

// start-db-context
internal class MyDbContext : DbContext
{
    public DbSet<Customer> Customers { get; init; }

    public MyDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Customer>().ToCollection("customers");
    }
}
// end-db-context