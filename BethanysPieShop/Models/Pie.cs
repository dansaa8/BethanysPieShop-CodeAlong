using System.ComponentModel;

namespace BethanysPieShop.Models
{
    public class Pie
    {
        // ? nullable på props som man inte kräver ett värde på.
        // kan vara null i database.
        public int PieId { get; set; }
        public string Name { get; set; } = string.Empty; // värde inte nullable
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }

        public string? AllergyInformation { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageThumbnailUrl { get; set; }
        public bool IsPieOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }

        // default ! 
        // nullforgiving operator, anv. i kombination med nullable
        // för att indikera att Category inte kan vara null.
        public Category Category { get; set; } = default!;
    }
}
