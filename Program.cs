namespace SwitchStatement
{
    public static class Program
    {
        public static bool In<T>(this T val, params T[] vals) => vals.Contains(val);

        static void Main()
        {
            SubMultipleCaseResults(22);
            SubMultipleCaseResultsWithWhen(100);
            SubMultipleCaseWithExtension(22);
            SubMultipleCaseWithListValues(22);
            SubMultipleCaseWithNewVersion(22);
        }

        public static void SubMultipleCaseResults(int switchTemp)
        {
            var resultstring = string.Empty;

            switch (switchTemp)
            {
                case 20:
                case 22:
                case 24:
                    resultstring = "Сегодня приятный день";
                    break;
                case 30:
                    resultstring = "Сегодня очень жарко";
                    break;
                default:
                    resultstring = "Прогноза погоды на сегодня нет";
                    break;
            }

            Console.WriteLine(resultstring);
        }

        public static void SubMultipleCaseResultsWithWhen(int value)
        {
            switch (value)
            {
                case int n when (n >= 50 && n <= 150):
                    Console.WriteLine("Это значение находится в диапазоне от 50 до 150");
                    break;
                case int n when (n >= 150 && n <= 200):
                    Console.WriteLine("Это значение находится в диапазоне от 150 до 200");
                    break;
                default:
                    Console.WriteLine("Это число не находится в пределах заданного диапазона");
                    break;
            }
        }
        public static void SubMultipleCaseWithExtension(int tempValue)
        {
            var result = tempValue switch
            {
                var x when x.In(20, 22, 24) => "Сегодня приятный день",
                30 => "Сегодня жарко",
                35 => "Сегодня очень жарко",
                _ => "Никаких прогнозов погоды",
            };

            Console.WriteLine($"{result} - с методом расширения");
        }

        public static void SubMultipleCaseWithListValues(int tempValue)
        {
            var templist = new List<int> { 20, 22, 24 };

            var newresult = tempValue switch
            {
                var x when templist.Contains(x) => "Сегодня приятный день",
                30 => "Сегодня жарко",
                35 => "Сегодня очень жарко",
                _ => "Никаких прогнозов погоды",
            };

            Console.WriteLine($"{newresult} - результат при использовании списка");
        }

        public static void SubMultipleCaseWithNewVersion(int tempValue)
        {
            var resultText = tempValue switch
            {
                20 or 22 or 24 => "Сегодня приятный день",
                30 => "Сегодня жарко",
                35 => "Сегодня очень жарко",
                > 35 => "Состояние тепловой волны",
                _ => "Никаких прогнозов погоды",
            };

            Console.WriteLine($"{resultText} - результат для синтаксиса C# 9.0");
        }
    }
}