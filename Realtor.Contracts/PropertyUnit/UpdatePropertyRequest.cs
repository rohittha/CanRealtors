namespace Realtor.Contracts.PropertyUnit
{
    public record UpdatePropertiesRequest
    (
         int Id 
        , string? Description 
        , string? Type 
        , string? Address 
        , string? Address2 

        , string? City 
        , string? Region 
        , string? PostalCode 
        , string? Country 
        , string? Phone 
    );
}
