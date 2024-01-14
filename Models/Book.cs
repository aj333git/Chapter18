using System.ComponentModel.DataAnnotations.Schema;
namespace Chapter18.Models{
public class Book {
        public long BookId { get; set; }
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        public long ClassificationId { get; set; }
        public Classification? Classification { get; set; }
        public long PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
    }
}
