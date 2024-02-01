namespace Devrica.Roulette.Domain.Models

{
    public class SplitBet
    {
        public int Id { get; set; }
        public List<int> Numbers { get; set; } = new List<int>();
        public decimal Amount { get; set; }
        public int? SpinNumber { get; set; }
        public String? Outcome { get; set; }
        public ResultColor Color { get; set; }
    }
}