namespace Devrica.Roulette.Domain.Models

{
    public class StraightBet
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public decimal Amount { get; set; }
        public int? SpinNumber { get; set; }
        public String? Outcome { get; set; }
        public ResultColor Color { get; set; }
    }
}