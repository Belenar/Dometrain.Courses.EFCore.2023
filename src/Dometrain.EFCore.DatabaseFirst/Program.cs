// See https://aka.ms/new-console-template for more information

using Dometrain.EFCore.DatabaseFirst.Context;

Console.WriteLine("Hello, World!");

var context = new AdventureWorksContext();

var query = context.Customers
    .Where(c => c.FirstName.StartsWith("C"));

foreach (var customer in query)
{
    Console.WriteLine($"{customer.FullName}");
}