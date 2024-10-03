namespace Practice1
{
    internal class Program
    {

        static void Main()
        {
            City city = new City();
            PoliceStation policeStation = new PoliceStation();

            Taxi taxi1 = new Taxi("0001 AAA");
            Taxi taxi2 = new Taxi("0002 BBB");
            SpeedRadar speedRadar1 = new SpeedRadar();
            SpeedRadar speedRadar2 = new SpeedRadar();
            PoliceCar policeCar1 = new PoliceCar("0001 CNP", policeStation, speedRadar1);
            PoliceCar policeCar2 = new PoliceCar("0002 CNP", policeStation, speedRadar2);
            PoliceCar policeCar3 = new PoliceCar("0003 CNP", policeStation);

            Console.WriteLine(city.WriteMessage("Created"));
            Console.WriteLine(policeStation.WriteMessage("Created"));

            Console.WriteLine(taxi1.WriteMessage("Created"));
            Console.WriteLine(taxi2.WriteMessage("Created"));
            Console.WriteLine(policeCar1.WriteMessage("Created"));
            Console.WriteLine(policeCar2.WriteMessage("Created"));
            Console.WriteLine(policeCar3.WriteMessage("Created"));

            city.AddTaxiLicense(taxi1.GetPlate());
            city.AddTaxiLicense(taxi2.GetPlate());

            policeStation.AddPoliceCar(policeCar1);
            policeStation.AddPoliceCar(policeCar2);
            policeStation.AddPoliceCar(policeCar3);

            policeCar1.StartPatrolling();
            policeCar1.UseRadar(taxi1); // con radar
            policeCar3.UseRadar(taxi1); // sin radar

            taxi2.StartRide();
            policeCar2.UseRadar(taxi2);
            policeCar2.StartPatrolling();
            policeCar2.UseRadar(taxi2);
            policeCar2.SendAlarm(taxi2.GetPlate());
            taxi2.StopRide();
            policeCar2.EndPatrolling();
            policeCar1.EndPursuit(taxi2.GetPlate());
            city.RemoveTaxiLicense(taxi2.GetPlate());

            policeCar3.StartPatrolling();

            taxi1.StartRide();
            taxi1.StartRide();
            policeCar1.StartPatrolling();
            policeCar1.UseRadar(taxi1);
            policeCar1.SendAlarm(taxi1.GetPlate());
            taxi1.StopRide();
            taxi1.StopRide();
            policeCar1.EndPatrolling();
            policeCar3.EndPatrolling();
            city.RemoveTaxiLicense(taxi1.GetPlate());

            policeCar1.PrintRadarHistory();
            policeCar2.PrintRadarHistory();
            policeCar3.PrintRadarHistory();

        }
    }
}
    

