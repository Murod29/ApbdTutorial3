using System;
using System.Collections.Generic;

namespace ContainerShipManagement.Models
{
    public class ContainerShip
    {
        public string Name { get; private set; }
        public double MaxWeight { get; private set; }
        public int MaxContainers { get; private set; }
        public List<Container> Containers { get; private set; }

        public ContainerShip(string name, double maxWeight, int maxContainers)
        {
            Name = name;
            MaxWeight = maxWeight;
            MaxContainers = maxContainers;
            Containers = new List<Container>();
        }

        public void LoadContainer(Container container)
        {
            if (Containers.Count >= MaxContainers)
                throw new Exception("Ship capacity reached.");
            if (TotalCargoWeight() + container.TareWeight + container.CargoMass > MaxWeight)
                throw new Exception("Exceeding ship weight limit.");
            Containers.Add(container);
        }

        public void RemoveContainer(string serialNumber)
        {
            Containers.RemoveAll(c => c.SerialNumber == serialNumber);
        }

        public double TotalCargoWeight()
        {
            double weight = 0;
            foreach (var c in Containers)
                weight += c.TareWeight + c.CargoMass;
            return weight;
        }
    }
}