namespace SustainableEnergyAPI.Models
{
    public class EnergyResource
    {
        public int Id { get; set; } // NÃO enviar no POST, será gerado automaticamente.
        public string Name { get; set; }
        public string Type { get; set; }
        public double Efficiency { get; set; }
    }

}

