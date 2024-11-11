namespace Stock_Manager_API.Models
{
    public class StockDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string StockCollectionName { get; set; } = null!;
    }
}
