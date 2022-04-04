using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TesteCliente.Model;

namespace TesteCliente.Service
{
    public class ClienteService
    {
        private readonly IMongoCollection<Cliente> _clienteCollection;

        public ClienteService(IOptions<ClienteDatabaseSettings> clienteService)
        {
           var  mongoClient = new MongoClient(clienteService.Value.ConnectionString);
           var mongoDatabase = mongoClient.GetDatabase(clienteService.Value.DatabaseName);

            _clienteCollection = mongoDatabase.GetCollection<Cliente>
                (clienteService.Value.ClienteCollectionName);
                
        }

        public async Task<List<Cliente>> GetAsync() =>
            await _clienteCollection.Find(x => true).ToListAsync();

        public async Task<Cliente> GetAsync(string id) =>
            await _clienteCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Cliente cliente) =>
            await _clienteCollection.InsertOneAsync(cliente);

        public async Task DeleteAsync(Cliente cliente) =>

        await _clienteCollection.DeleteOneAsync(x => x.Id == cliente.Id);

        public async Task UpdateAsync(string id, Cliente cliente) =>
            await _clienteCollection.ReplaceOneAsync(x => x.Id == id, cliente);
    }
}
