using System.ComponentModel;

namespace Practice1
{
    class PoliceStation : IMessageWritter
    {
        public List<PoliceCar> PoliceCars { get; private set; }

        public PoliceStation()
        {
            PoliceCars = new List<PoliceCar>();
        }

        public void AddPoliceCar(PoliceCar policeCar)
        {
            PoliceCars.Add(policeCar);
            Console.WriteLine(WriteMessage($"Added police car: {policeCar.GetPlate()}"));
        }
        public void RemovePoliceCar(PoliceCar policeCar)
        {
            PoliceCars.Remove(policeCar);
            Console.WriteLine(WriteMessage($"Removed police car: {policeCar.GetPlate()}"));
        }

        public void InitiatePursuit(string plate)
        {
            Console.WriteLine(WriteMessage($"Initiate pursuit of vehicle with plate: {plate}"));
            foreach (PoliceCar policeCar in PoliceCars)
            {
                policeCar.StartPursuit(plate);
            }
        }

        public string WriteMessage(string message)
        {
            return $"Police station: {message}";
        }
    }
}