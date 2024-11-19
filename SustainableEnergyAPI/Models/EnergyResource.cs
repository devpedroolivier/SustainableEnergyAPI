namespace SustainableEnergyAPI.Models
{
    public class EnergyResource
    {
        public int Id { get; set; } // O Id é obrigatório porque é chave primária
        public string Name { get; set; } = string.Empty; // Obrigatório
        public string Type { get; set; } = string.Empty; // Obrigatório
        public double Efficiency { get; set; } // Tipo numérico já é obrigatório por padrão
    }
}

