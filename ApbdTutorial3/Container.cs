namespace ContainerShipManagement.Models
{
    public abstract class Container
    {
        public string SerialNumber { get; protected set; }
        public double CargoMass { get; set; }
        public double TareWeight { get; set; }
        public double MaxPayload { get; set; }

        public Container(string serialNumber, double tareWeight, double maxPayload)
        {
            SerialNumber = serialNumber;
            TareWeight = tareWeight;
            MaxPayload = maxPayload;
            CargoMass = 0;
        }

        public virtual void LoadCargo(double mass)
        {
            if (CargoMass + mass > MaxPayload)
                throw new Exception("OverfillException: Cargo exceeds the maximum payload.");
            CargoMass += mass;
        }

        public void UnloadCargo()
        {
            CargoMass = 0;
        }

        public override string ToString()
        {
            return $"{SerialNumber}: CargoMass = {CargoMass}, TareWeight = {TareWeight}, MaxPayload = {MaxPayload}";
        }
    }
}