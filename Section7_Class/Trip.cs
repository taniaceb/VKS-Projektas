using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section7_Class
{
    class Trip
    {
        public int Destination { get; set; }
        public int DistanceTraveled { get; set; }
        public double CostOfGasoline { get; set; }
        public double NumberOfGallonsConsumed { get; set; }

        public Trip(int destination, int distance, double cost, double number)
        {
            Destination = destination;
            DistanceTraveled = distance;
            CostOfGasoline = cost;
            NumberOfGallonsConsumed = number;
        }

        public double CalculateMiles()
        {
            return DistanceTraveled / NumberOfGallonsConsumed;
        }

        public double CostPerMile()
        {
            return CostOfGasoline / DistanceTraveled;
        }

        public override string ToString()
        {
            return "Miles per gallons " + string.Format("{0:0.00}", CalculateMiles()) + "  Cost per Mile " + string.Format("{0:0.00}", CostPerMile());
        }
    }
}
