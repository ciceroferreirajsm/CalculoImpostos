namespace CalculoImpostos.Entities
{
    class Individual : TaxPayer
    {
        public double HealthExpenditures { get; set; }

        public Individual()
        {
        }

        public Individual(string name, double anualIncome, double healthExpenditures) : base (name, anualIncome)
        {
            HealthExpenditures = healthExpenditures;
        }

        public override double Tax()
        {
            if (AnualIncome < 20000)
            {
                return AnualIncome * 15 / 100;
            }
            else if (AnualIncome > 20000 && HealthExpenditures > 0)
            {
                return (AnualIncome * 25 / 100) - (HealthExpenditures * 50 / 100);
            }
            else
            {
                return AnualIncome * 25 / 100;
            }
        }
    }
}
