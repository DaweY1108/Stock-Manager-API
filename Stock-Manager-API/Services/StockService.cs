using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Stock_Manager_API.Models;

namespace Stock_Manager_API.Services
{
    public class StockService
    {
        private readonly IMongoCollection<Stock> _stockCollection;

        public StockService (
            IOptions<StockDatabaseSettings> stockDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                stockDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                stockDatabaseSettings.Value.DatabaseName);

            _stockCollection = mongoDatabase.GetCollection<Stock>(
                stockDatabaseSettings.Value.StockCollectionName);
        }

        public async Task<List<Stock>> GetAsync() =>
            await _stockCollection.Find(_ => true).ToListAsync();

        public async Task<Stock?> GetAsync(string id) =>
            await _stockCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Stock newStock) =>
            await _stockCollection.InsertOneAsync(newStock);

        public async Task UpdateAsync(string id, Stock updatedStock) =>
            await _stockCollection.ReplaceOneAsync(x => x.Id == id, updatedStock);

        public async Task RemoveAsync(string id) =>
            await _stockCollection.DeleteOneAsync(x => x.Id == id);
    }
}
