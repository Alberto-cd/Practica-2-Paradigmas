namespace Practice1
{
    class PoliceStation : IMessageWritter
    {
        public List<PoliceCar> PoliceCars { get; private set; }

        public PoliceStation(string plate) : base(typeOfVehicle, plate)
        {
            SpeedHistory = new List<PoliceCar>();
        }

        public void InitiatePursuit(string plate)
        {
            Console.WriteLine(WriteMessage($"Initiate pursuit of vehicle with plate: {plate}"));
            foreach (PoliceCar policeCar in PoliceCars)
            {
                policeCar.startPursuit(plate);
            }
        }

        public string WriteMessage(string message)
        {
            return $"Police station:  {message}";
        }
    }
}