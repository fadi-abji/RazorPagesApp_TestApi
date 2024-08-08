namespace RazorPagesApp.Pages
{
    public class FruitModel
    {
        // An id assigned by the database
        public int id { get; set; }
        // The name of the fruit
        public string? name { get; set; }
        // A boolean to indicate if the fruit is in stock
        public bool instock { get; set; }
    }
}