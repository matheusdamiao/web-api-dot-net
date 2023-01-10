namespace Buber.Domain.Entities;

public class Product
    {
        public int Id { get; set; } = 0!;
        public string Name { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public int Stock { get; set; } = 0!;
        public decimal Price { get; set; } = 0!;

    }