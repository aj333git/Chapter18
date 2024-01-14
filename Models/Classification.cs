namespace Chapter18.Models{
public class Classification {
        public long ClassificationId { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<Book>? Books { get; set; }
    }
}
