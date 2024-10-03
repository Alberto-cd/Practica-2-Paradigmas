namespace Practice1
{
    class PoliceCar : VehicleWithPlate
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car"; 
        private bool isPatrolling;
        private bool isInPursuit;
        private string plateOfInPursuitVehicle;
        private PoliceStation policeStation;
        private SpeedRadar? speedRadar;

        public PoliceCar(string plate, PoliceStation policeStation, SpeedRadar? speedRadar = null) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            isInPursuit = false;
            plateOfInPursuitVehicle = "";
            this.policeStation = policeStation;
            this.speedRadar = speedRadar;
        }

        public void UseRadar(VehicleWithPlate vehicle)
        {
            if (isPatrolling && speedRadar != null)
            {
                speedRadar.TriggerRadar(vehicle);
                string meassurement = speedRadar.GetLastReading();
                Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no active radar."));
            }
        }

        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                isInPursuit = false;
                plateOfInPursuitVehicle = "";
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }

        public void PrintRadarHistory()
        {
            if (speedRadar != null)
            {
                Console.WriteLine(WriteMessage("Report radar speed history:"));
                foreach (float speed in speedRadar.SpeedHistory)
                {
                    Console.WriteLine(speed);
                }
            }
            else 
            {
                Console.WriteLine(WriteMessage("Has no active radar"));
            }
        }

        public void StartPursuit(string plate)
        {
            if (isInPursuit)
            {
                Console.WriteLine(WriteMessage($"Is already in a pursuit of vehicle with plate: {plateOfInPursuitVehicle}"));
            }
            else if (isPatrolling)
            {
                isInPursuit = true;
                plateOfInPursuitVehicle = plate;
                Console.WriteLine(WriteMessage($"In pursuit of vehicle with plate: {plate}"));
            }
            else 
            {
                Console.WriteLine(WriteMessage("Is not patrolling"));
            }
        }

        public void EndPursuit(string plate) 
        {
            if (!isPatrolling)
            {
                Console.WriteLine(WriteMessage("Was not patrolling"));
            }
            else if (!isInPursuit)
            {
                Console.WriteLine(WriteMessage("Was not in a pursuit"));
            }
            else if (plate != plateOfInPursuitVehicle)
            {
                Console.WriteLine(WriteMessage($"Was not in a pursuit with vehicle with plate {plate}"));
            }
            else
            {
                isInPursuit = false;
                plateOfInPursuitVehicle = "";
                Console.WriteLine(WriteMessage($"Endded it's pursuit"));
            }

        }

        public void SendAlarm(string plate)
        {
            policeStation.InitiatePursuit(plate);
        }
    }
}