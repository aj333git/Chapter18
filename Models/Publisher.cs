namespace Chapter18.Models{
public class Publisher {
        public long PublisherId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public IEnumerable<Book>? Books { get; set; }
    }
}
