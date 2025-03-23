namespace ContainerShipManagement.Models
{
    public class LiquidContainer : Container
    {
        public bool IsHazardous { get; private set; }

        public LiquidContainer(string serialNumber, double tareWeight, double maxPayload, bool isHazardous)
            : base(serialNumber, tareWeight, maxPayload)
        {
            IsHazardous = isHazardous;
        }

        public override void LoadCargo(double mass)
        {
            double limit = IsHazardous ? MaxPayload * 0.5 : MaxPayload * 0.9;
            if (CargoMass + mass > limit)
                throw new Exception("OverfillException: Cargo exceeds the allowed limit for liquid containers.");
            CargoMass += mass;
        }
    }
}