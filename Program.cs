internal class Program
{
    class DistanceUnit
    {
        double toMilimeter;
        double toCentimeter;
        double toMeter;
        double toKilometer;
        double toInch;
        double toFeet;
        double toYard;
        double toMile;

        public DistanceUnit(double toMilimeter, double toCentimeter, double toMeter, double toKilometer, double toInch, double toFeet, double toYard, double toMile)
        {
            this.toMilimeter = toMilimeter;
            this.toCentimeter = toCentimeter;
            this.toMeter = toMeter;
            this.toKilometer = toKilometer;
            this.toInch = toInch;
            this.toFeet = toFeet;
            this.toYard = toYard;
            this.toMile = toMile;
        }
        public double convert(double value, string unit)
        {
            switch (unit)
            {
                case "mm":
                    return value * toMilimeter;
                case "cm":
                    return value * toCentimeter;
                case "m":
                    return value * toMeter;
                case "km":
                    return value * toKilometer;
                case "in":
                    return value * toInch;
                case "ft":
                    return value * toFeet;
                case "yd":
                    return value * toYard;
                case "mi":
                    return value * toMile;
                default:
                    return 0;
            }
        }
    }

    static DistanceUnit Milimeters = new DistanceUnit(1, 0.1, 0.001, 0.000001, 0.03937007874, 0.003280839895, 0.001093613298, 0.00000062137);
    static DistanceUnit Centimeters = new DistanceUnit(10, 1, 0.01, 0.00001, 0.3937007874, 0.03280839895, 0.01093613298, 0.0000062137);
    static DistanceUnit Meters = new DistanceUnit(1000, 100, 1, 0.001, 39.37007874, 3.280839895, 1.093613298, 0.00062137);
    static DistanceUnit Kilometers = new DistanceUnit(1000000, 100000, 1000, 1, 39370.07874, 3280.839895, 1093.613298, 0.62137);
    static DistanceUnit Inches = new DistanceUnit(25.4, 2.54, 0.0254, 0.0000254, 1, 0.0833333333, 0.0277777778, 0.0000157828);
    static DistanceUnit Feet = new DistanceUnit(304.8, 30.48, 0.3048, 0.0003048, 12, 1, 0.3333333333, 0.0001893939);
    static DistanceUnit Yards = new DistanceUnit(914.4, 91.44, 0.9144, 0.0009144, 36, 3, 1, 0.0005681818);
    static DistanceUnit Miles = new DistanceUnit(1609344, 160934.4, 1609.344, 1.609344, 63360, 5280, 1760, 1);




    public static void Main(string[] args)
    {
        Console.WriteLine("What unit do you want to convert from?");
        Console.WriteLine("mm, cm, m, km, in, ft, yd, mi");
        string fromUnit = Console.ReadLine();

        Console.WriteLine("What is the value you want to convert?");
        if(!double.TryParse(Console.ReadLine(), out double value))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return;
        }

        Console.WriteLine("What unit do you want to convert to?");
        Console.WriteLine("mm, cm, m, km, in, ft, yd, mi");
        string toUnit = Console.ReadLine();

        switch(fromUnit) {
            case "mm":
                Console.WriteLine(Milimeters.convert(value, toUnit));
                break;
            case "cm":
                Console.WriteLine(Centimeters.convert(value, toUnit));
                break;
            case "m":
                Console.WriteLine(Meters.convert(value, toUnit));
                break;
            case "km":
                Console.WriteLine(Kilometers.convert(value, toUnit));
                break;
            case "in":
                Console.WriteLine(Inches.convert(value, toUnit));
                break;
            case "ft":
                Console.WriteLine(Feet.convert(value, toUnit));
                break;
            case "yd":
                Console.WriteLine(Yards.convert(value, toUnit));
                break;
            case "mi":
                Console.WriteLine(Miles.convert(value, toUnit));
                break;
            default:
                Console.WriteLine("Invalid input. Please enter a valid unit.");
                break;
        }

        Console.WriteLine("Do you want to convert another value? (y/n)");
        string response = Console.ReadLine();
        if (response == "y")
        {
            Main(args);
        }
    }
}