using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realtor.Application.Services.PropertyUnit
{
    public class PropertyUnitRepository : IPropertyUnitRepository
    {
        //private readonly AppDbContext _context;
        //public PropertyRepository(AppDbContext context)
        //{
        //    _context = context;
        //}

        //public async Task<List<PropertyUnit>> GetPropertiesAsync()
        //{
        //    var propList = await _context.PropertyUnits.ToListAsync();
        //    return propList;
        //}

        //public async Task<PropertyUnit> CreatePropertyAsync(PropertyUnit property)
        //{
        //    await _context.PropertyUnits.AddAsync(property);
        //    await _context.SaveChangesAsync();
        //    return property;
        //}

        //public async Task<PropertyUnit?> GetPropertyAsync(int Id)
        //{
        //    var property = await _context.PropertyUnits.Where(p => p.Id == Id).FirstOrDefaultAsync();
        //    return property;
        //}

        //public async Task<PropertyUnit?> UpdatePropertyAsync(int Id, PropertyUnit property)
        //{
        //    var existingProperty = await _context.PropertyUnits.FirstOrDefaultAsync(u => u.Id == Id);
        //    if (existingProperty == null) return null;

        //    existingProperty.Phone = property.Phone;
        //    existingProperty.Address = property.Address;
        //    existingProperty.Address2 = property.Address2;
        //    existingProperty.Region = property.Region;
        //    existingProperty.City = property.City;
        //    existingProperty.Country = property.Country;
        //    existingProperty.Description = property.Description;
        //    existingProperty.PostalCode = property.PostalCode;
        //    existingProperty.Type = property.Type;

        //    //_context.PropertyUnits.Update(existingProperty);
        //    await _context.SaveChangesAsync();
        //    return existingProperty;
        //}
    }
}
