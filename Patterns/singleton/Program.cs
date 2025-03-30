// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Singleton!");

var cache1 = MemoryCache.Instance;
var cache2 = MemoryCache.Instance;

cache1.Add("date", DateTime.Now);

Console.WriteLine("date :" + cache2.Get("date"));
Console.WriteLine("cache1.Equals(cache2) :" + cache1.Equals(cache2));
Console.WriteLine("object.ReferenceEquals(cache1, cache2) :" + object.ReferenceEquals(cache1, cache2));
