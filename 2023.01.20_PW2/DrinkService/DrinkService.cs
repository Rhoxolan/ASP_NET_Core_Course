namespace _2023._01._20_PW2.DrinkService
{
    public class DrinkService
    {
        private IEnumerable<IDrink> _drinks;

        public DrinkService(IEnumerable<IDrink> drinks)
        {
            _drinks = drinks;
        }

        public IDrink? GetTea()
        {
            return _drinks.Where(d => d is Tea).FirstOrDefault();
        }

        public IDrink? GetCoffe()
        {
            return _drinks.Where(d => d is Coffe).FirstOrDefault();
        }

        public IDrink? GetMineralWater()
        {
            return _drinks.Where(d => d is MineralWater).FirstOrDefault();
        }
    }
}
