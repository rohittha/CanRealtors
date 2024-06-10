using Microsoft.AspNetCore.Mvc;
using Realtor.Contracts.PropertyUnit;

namespace Realtor.API.Services
{
    public interface IPropertyRepository
    {
        public Task<List<PropertyUnit>> GetPropertiesAsync();
        public Task<PropertyUnit> CreatePropertyAsync(PropertyUnit property);
        public Task<PropertyUnit> UpdatePropertyAsync(int Id, PropertyUnit property);
        public Task<PropertyUnit?> GetPropertyAsync(int id);
    }
}
