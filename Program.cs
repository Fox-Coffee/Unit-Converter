/**
    * Unit Converter - a program used to convert units
    * Copyright (C) 2024  Eden kamieniecka
    *
    * This program is free software: you can redistribute it and/or modify
    * it under the terms of the GNU General Public License as published by
    * the Free Software Foundation, either version 3 of the License, or
    * (at your option) any later version.
    *
    * This program is distributed in the hope that it will be useful,
    * but WITHOUT ANY WARRANTY; without even the implied warranty of
    * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    * GNU General Public License for more details.
    *
    * You should have received a copy of the GNU General Public License
    * along with this program.  If not, see <https://www.gnu.org/licenses/>.
**/
internal class Program
{
    abstract class Units
    {
        protected Dictionary<string, double> conversionFators = new Dictionary<string, double>();
        public double convert(double value, string unit)
        {
            return conversionFators != null && conversionFators.TryGetValue(unit, out double conversionFactor) ? value * conversionFactor : 0;
        }
    }


    class DistanceUnit : Units
    {
        public DistanceUnit(double toMilimeter, double toCentimeter, double toMeter, double toKilometer, double toInch, double toFeet, double toYard, double toMile)
        {
            conversionFators = new Dictionary<string, double>
            {
                { "mm", toMilimeter },
                { "cm", toCentimeter },
                { "m", toMeter },
                { "km", toKilometer },
                { "in", toInch },
                { "ft", toFeet },
                { "yd", toYard },
                { "mi", toMile }
            };
        }
    }
    class MassUnit : Units
    {

        public MassUnit(double toMiligram, double toGram, double toDecagram, double toKilogram, double toTonne, double toOunce, double toPound)
        {
            conversionFators = new Dictionary<string, double>
            {
                {"mg", toMiligram},
                {"g", toGram},
                {"dag", toDecagram},
                {"kg", toKilogram},
                {"t", toTonne},
                {"oz", toOunce},
                {"lb",  toPound},
            };
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

    static MassUnit Miligrams = new MassUnit(1, 0.001, 0.0001, 0.000001, 0.000000001, 0.000035274, 0.00000220462);
    static MassUnit Grams = new MassUnit(1000, 1, 0.1, 0.001, 0.000001, 0.035274, 0.00220462);
    static MassUnit Decagrams = new MassUnit(10000, 10, 1, 0.01, 0.00001, 0.35274, 0.0220462);
    static MassUnit Kilograms = new MassUnit(1000000, 1000, 100, 1, 0.001, 35.274, 2.20462);
    static MassUnit Tonne = new MassUnit(1000000000, 1000000, 100000, 1000, 1, 0.0035274, 0.00220462);
    static MassUnit Ounces = new MassUnit(28349.5, 28.3495, 2.83495, 0.0283495, 0.0000283495, 1, 0.06249994901875);
    static MassUnit Pounds = new MassUnit(453592, 453.592, 45.3592, 0.453592, 0.000453592, 16, 1);

    public static void DistanceConvert(){
        Console.WriteLine("What unit do you want to convert from?");
        Console.WriteLine("mm, cm, m, km, in, ft, yd, mi");
        string? fromUnit = Console.ReadLine();

        Console.WriteLine("What is the value you want to convert?");
        if (!double.TryParse(Console.ReadLine(), out double value))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return;
        }

        Console.WriteLine("What unit do you want to convert to?");
        Console.WriteLine("mm, cm, m, km, in, ft, yd, mi");
        string? toUnit = Console.ReadLine();
        toUnit ??= "";

        DistanceUnit? unit = fromUnit switch
        {
            "mm" => Milimeters,
            "cm" => Centimeters,
            "m" => Meters,
            "km" => Kilometers,
            "in" => Inches,
            "ft" => Feet,
            "yd" => Yards,
            "mi" => Miles,
            _ => null
        };

        if (unit == null)
        {
            Console.WriteLine("Invalid unit\n");
            DistanceConvert();
        }

        double result = unit.convert(value, toUnit);
        Console.WriteLine($"Result: {result} {toUnit}");

        Console.WriteLine("Do you want to convert another value? (y/n)");
        string? response = Console.ReadLine();
        if (response == "y")
        {
            DistanceConvert();
        }
    }

    public static void MassConvert()
    {
        Console.WriteLine("What unit do you want to convert from?");
        Console.WriteLine("mg, g, dag, kg, t, oz, lb");
        string? fromUnit = Console.ReadLine();

        Console.WriteLine("What is the value you want to convert?");
        if (!double.TryParse(Console.ReadLine(), out double value))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return;
        }

        Console.WriteLine("What unit do you want to convert to?");
        Console.WriteLine("mg, g, dag, kg, t, oz, lb");
        string? toUnit = Console.ReadLine();
        toUnit ??= "";

        MassUnit? unit = fromUnit switch
        {
            "mg" => Miligrams,
            "g" => Grams,
            "dag" => Decagrams,
            "kg" => Kilograms,
            "t" => Tonne,
            "oz" => Ounces,
            "lb" => Pounds,
            _ => null
        };

        if (unit == null)
        {
            Console.WriteLine("Invalid unit\n");
            MassConvert();
        }

        double result = unit.convert(value, toUnit);
        Console.WriteLine($"Result: {result} {toUnit}");

        Console.WriteLine("Do you want to convert another value? (y/n)");
        string? response = Console.ReadLine();
        if (response == "y")
        {
            MassConvert();
        }
    }


    public static void Main(string[] args)
    {
        Console.WriteLine("Unit Converter  Copyright (C) 2024  Eden Kamieniecka\nThis program comes with ABSOLUTELY NO WARRANTY; for details type `show w'.\nThis is free software, and you are welcome to redistribute it\nunder certain conditions; type `show c' for details.");
        while (true)
        {
            Console.WriteLine("\n\nWhat would you like to do?\ns - start program\na - about the program\nc- display license details\ne-exit the program");
            string? userInput = Console.ReadLine();

            switch (userInput)
            {
                case "s":
                    Console.WriteLine("What units would you like to convert?\nd - distance\nm - mass\nENTER - go back");
                    string? unitType = Console.ReadLine();
                    switch (unitType)
                    {
                        case "d":
                            DistanceConvert();
                            break;
                        case "m":
                            MassConvert();
                            break;
                        default:
                            break;
                    }
                    break;
                case "a":
                    Console.WriteLine("This is a program used to convert units of measurment (ex. meters to yards). Currently the program allows to convert units of distance. The program runs in the command prompt or terminal.\nAuthor: Eden Kamieniecka\nVersion: \x1b[1mPREVIEW 0.0.0");
                    break;
                case "c":
                    Console.WriteLine("This project is under the GPL-3 license, to learn more visit https://www.gnu.org/licenses/gpl-3.0.en.html.\nThis software is free to use and modify, but a modified version of the program has to be distributed under the same license.\nThe program's source code can be found on https://github.com/Fox-Coffee/unit-converter");
                    Console.WriteLine("Developers that use the GNU GPL protect your rights with two steps:\n(1) assert copyright on the software, and \n(2) offer you this Licensegiving you legal permission to copy, distribute and/or modify it.");
                    Console.WriteLine("Copyright © 2024, Eden Kamieniecka\nAll Rights Reserved");
                    break;
                case "e":
                    return;
                default:
                    Console.WriteLine("Incorrect command");
                    break;
            }
        }

    }
}