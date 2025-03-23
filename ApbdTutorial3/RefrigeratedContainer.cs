namespace ContainerShipManagement.Models
{
    public class RefrigeratedContainer : Container
    {
        public string ProductType { get; private set; }
        public double Temperature { get; private set; }

        public RefrigeratedContainer(string serialNumber, double tareWeight, double maxPayload, string productType, double temperature)
            : base(serialNumber, tareWeight, maxPayload)
        {
            ProductType = productType;
            Temperature = temperature;
        }
    }
}


