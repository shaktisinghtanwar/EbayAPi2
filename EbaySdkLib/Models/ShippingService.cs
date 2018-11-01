namespace EbaySdkLib.Models
{
    public class ShippingService
    {
        public Amount additionalShippingCost { get; set; }
        public string buyerResponsibleForPickup { get; set; }
        public string buyerResponsibleForShipping { get; set; }
        public Amount cashOnDeliveryFee { get; set; }
        public string freeShipping { get; set; }
        public string shippingCarrierCode { get; set; }
        public Amount shippingCost { get; set; }
        public string shippingServiceCode { get; set; }
        public RegionSet shipToLocations { get; set; }
        public string sortOrder { get; set; }
        public Amount surcharge { get; set; }
    }
}
