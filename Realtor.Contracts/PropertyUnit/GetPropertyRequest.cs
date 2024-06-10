namespace Realtor.Contracts.PropertyUnit
{
    public record GetPropertyRequest
    {
        public int? Id { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public string? Address { get; set; }
        public string? Address2 { get; set; }

        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
    }
}
