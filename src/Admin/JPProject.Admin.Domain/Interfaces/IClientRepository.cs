using IdentityServer4.Models;
using JPProject.Domain.Core.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JPProject.Admin.Domain.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client> GetClient(string clientId);
        Task UpdateWithChildrens(string oldClientId, Client client);
        Task<Client> GetByClientId(string requestClientId);

        Task<Client> GetClientDefaultDetails(string clientId);
        Task RemoveSecret(string clientId, Secret secret);
        Task AddSecret(string clientId, Secret secret);
        Task RemoveProperty(string clientId, string key, string value);
        Task AddProperty(string clientId, string key, string value);
        Task RemoveClaim(string clientId, string type);
        Task RemoveClaim(string clientId, string type, string value);
        Task AddClaim(string clientId, Claim claim);
        Task<IEnumerable<Secret>> GetSecrets(string clientId);
        Task<IEnumerable<Client>> All();
        Task<IDictionary<string, string>> GetProperties(string clientId);
        Task<IEnumerable<Claim>> GetClaims(string clientId);
        Task<List<string>> ListClients();
    }
}
