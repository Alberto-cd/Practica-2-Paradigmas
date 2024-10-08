namespace Practice1
{
    class City : IMessageWritter
    {
        public List<string> TaxiLicenses { get; private set; }

        public City()
        {
            TaxiLicenses = new List<string>();
        }

        public void AddTaxiLicense(string plate)
        {
            TaxiLicenses.Add(plate);
            Console.WriteLine(WriteMessage($"Added taxi license: {plate}"));
        }

        public void RemoveTaxiLicense(string plate)
        {
            TaxiLicenses.Remove(plate);
            Console.WriteLine(WriteMessage($"Removed taxi license: {plate}"));
        }

        public string WriteMessage(string message)
        {
            return $"City: {message}";
        }
    }
}