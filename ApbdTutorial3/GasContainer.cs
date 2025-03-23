namespace ContainerShipManagement.Models
{
    public class GasContainer : Container
    {
        public double Pressure { get; set; }

        public GasContainer(string serialNumber, double tareWeight, double maxPayload, double pressure)
            : base(serialNumber, tareWeight, maxPayload)
        {
            Pressure = pressure;
        }

        public override void LoadCargo(double mass)
        {
            if (CargoMass + mass > MaxPayload)
                throw new Exception("OverfillException: Gas container overload.");
            CargoMass += mass;
        }

        public void EmptyGas()
        {
            CargoMass *= 0.95; // Always leave 5% of gas
        }
    }
}