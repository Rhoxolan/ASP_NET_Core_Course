namespace _2023._01._20_PW2
{
    public interface IDrink
    {
        public string Name { get; }

        public double Calories { get; }
    }

    public class Tea : IDrink
    {
        public string Name
            => "Tea";

        public double Calories
            => 1;
    }

    public class Coffe : IDrink
    {
        public string Name
            => "Coffe";

        public double Calories
            => 0.5;
    }

    public class MineralWater : IDrink
    {
        public string Name
            => "Mineral water";

        public double Calories
            => 0;
    }
}
