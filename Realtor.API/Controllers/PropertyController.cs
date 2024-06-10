using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Realtor.Contracts.PropertyUnit;
using Realtor.API.Data;
using Realtor.API.Services;

namespace Realtor.API.Controllers
{
    [ApiController]
    [Route("property")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyRepository _propertyRepository;
        public PropertyController(IPropertyRepository propertyRepository)
        {
            //_context = context;
            _propertyRepository = propertyRepository;
        }

        [HttpPost]
        [Route("getproperties")]
        public async Task<IActionResult> GetProperties(GetPropertiesRequest getPropertiesRequest)
        {
            var propertyList = await _propertyRepository.GetPropertiesAsync();
            return Ok(propertyList);
        }

        [HttpPost]
        [Route("createproperty")]
        public async Task<IActionResult> CreateProperty(CreatePropertiesRequest createPropReq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                PropertyUnit prop = new PropertyUnit
                {
                    Phone = createPropReq.Phone,
                    Address = createPropReq.Address,
                    Address2 = createPropReq.Address2,
                    Region = createPropReq.Region,
                    City = createPropReq.City,
                    Country = createPropReq.Country,
                    Description = createPropReq.Description,
                    PostalCode = createPropReq.PostalCode,
                    Type = createPropReq.Type
                };

                var createdItem = await _propertyRepository.CreatePropertyAsync(prop);
                return CreatedAtAction(nameof(GetProperty), new { id = createdItem.Id }, createdItem);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Error occurred while creating the item.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("getproperty")]
        public async Task<IActionResult> GetProperty(int Id)
        {
            if (ModelState.IsValid)
            {
                var property = await _propertyRepository.GetPropertyAsync(Id);
                return Ok(property);
            }
            else
            {
                return BadRequest("Error encountered!");
            }
        }

        [HttpPost]
        [Route("updateproperty")]
        public async Task<IActionResult> UpdateProperty(int Id, PropertyUnit property)
        {
            var updatedProperty = await _propertyRepository.UpdatePropertyAsync(Id, property);
            return Ok(updatedProperty);
        }
    }
}
