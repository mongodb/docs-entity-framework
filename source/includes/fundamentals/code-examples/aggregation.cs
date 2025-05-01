// start-count
var planetCount = db.Planets.Count();

Console.WriteLine("Planet Count: " + planetCount);
// end-count

// start-long-count
var planetCountLong = db.Planets.LongCount();

Console.WriteLine("Long Planet Count: " + longCount);
// end-long-count

// start-any
var results = db.Planets.Any(p => p.HasRings);

foreach (var p in results)
{
    Console.WriteLine("Planet with Rings: " + p.Name);
}
// end-any

// start-max
var furthestPlanet = db.Planets.Max(p => p.OrderFromSun);

Console.WriteLine("Furthest Planet: " + furthestPlanet.Name);
// end-max

// start-min
var closestPlanet = db.Planets.Min(p => p.OrderFromSun);

Console.WriteLine("Closest Planet: " + closestPlanet.Name);
// end-min

// start-sum
var totalMass = db.Planets.Sum(p => p.Mass);
Console.WriteLine("Total Mass of Planets: " + totalMass);
// end-sum

// start-average
var averageMass = db.Planets.Average(p => p.Mass);

Console.WriteLine("Average Mass of Planets: " + averageMass);
// end-average
