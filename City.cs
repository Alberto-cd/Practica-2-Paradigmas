namespace Practice1
{
    class City : IMessageWritter
    {
        public List<string> TaxiLicenses { get; private set; }

        public City()
        {
            TaxiLicenses = new List<string>();
        }

        public addTaxiLicense(string license)
        {
            TaxiLicenses.Add(license);
        }

        public removeTaxiLicense(string license)
        {
            TaxiLicenses.Remove(license);
        }

        public string WriteMessage(string message)
        {
            return $"City:  {message}";
        }
    }
}