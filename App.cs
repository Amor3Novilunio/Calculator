using helper;
using src.routes;
using src.Operators;
using src.Temperature;
using Microsoft.VisualBasic;


namespace app
{
    public static class App
    {
        private static readonly string[] _mainSelection = ["[1]Calculator", "[2]Temperature", "[3]Exit"];
        private static readonly string[] _calculatorSelection = ["[0]Return", "[1]Add", "[2]Subtraction", "[3]Multiplication", "[4]Division"];
        private static readonly string[] _temperaturerSelection = ["[0]Return", "[1]fahrenhiet to celcius", "[2]celcius to fahrenhiet"];
        public static void Start()
        {
            System.Console.Clear();
            System.Console.WriteLine("***Calculator & Temperature***");
            System.Console.WriteLine("");
            Helper.SelectionOption(_mainSelection);
            System.Console.Write("Selected Option : ");
            var selection = System.Console.ReadLine();
            bool selected = int.TryParse(selection, out int SelectionResult);
            if (!selected)
            {
                Helper.FalseValue(selected, false);
                Start();
            }

            switch (SelectionResult)
            {
                case 1:
                    Fields("Calculator",1);
                    break;
                case 2:
                    Fields("Temperature", 2);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

        }

        public static void Fields(string title="",int selection = 3)
        {
            System.Console.Clear();
            System.Console.WriteLine($"***{title}***");
            System.Console.WriteLine("");
            System.Console.Write("First Input  : ");
            var inputFieldOne = System.Console.ReadLine();
            bool isFieldOne = int.TryParse(inputFieldOne, out int inputFieldOneValue);
            switch(selection){
                case 1:
                    bool isFieldTwo = false;
                    System.Console.Write("Second Input : ");
                    var inputFieldTwo = System.Console.ReadLine();
                    isFieldTwo = int.TryParse(inputFieldTwo, out int inputFieldTwoValue);
                    if (!isFieldOne || !isFieldTwo)
                    {
                        Helper.FalseValue(isFieldOne, isFieldTwo);
                        Fields(title, 1);
                    }
                    Routes.FirstInput = inputFieldOneValue;
                    Routes.SecondInput = inputFieldTwoValue;
                    CalculatorSelection();
                    break;
                case 2:
                    if (!isFieldOne)
                    {
                        Helper.FalseValue(isFieldOne, false);
                        Fields(title, 2);
                    }
                    Routes.FirstInput = inputFieldOneValue;
                    TemperatureSelection();
                break;
                default:
                break;
            }

        }
        public static void CalculatorSelection()
        {
            System.Console.Clear();
            System.Console.WriteLine("***What do you want to do?***");
            System.Console.WriteLine("");
            Helper.SelectionOption(_calculatorSelection);
            System.Console.Write("Selected Option : ");
            var selection = System.Console.ReadLine();
            bool selected = int.TryParse(selection, out int SelectionResult);
            if (!selected)
            {
                Helper.FalseValue(selected, false);
                CalculatorSelection();
            }
            string OperatorUsed="";
            decimal Result = 0;
            switch(SelectionResult){
                case 0:
                    Start();
                    break;
                case 1:
                    Result = new Operators().Add();
                        OperatorUsed = "+";
                    break;
                case 2:
                    Result = new Operators().Subtraction();
                        OperatorUsed = "-";
                    break;
                case 3:
                    Result = new Operators().Multiplication();
                        OperatorUsed = "*";
                    break;
                case 4:
                    Result = new Operators().Division();
                        OperatorUsed = "/";
                    break;
                default:
                Helper.FalseValue();
                CalculatorSelection();
                break;
            }
            FinalResult(OperatorUsed,Result);
        }
        public static void TemperatureSelection(){
            System.Console.Clear();
            System.Console.WriteLine("***What do you want to do?***");
            System.Console.WriteLine("");
            Helper.SelectionOption(_temperaturerSelection);
            System.Console.Write("Selected Option : ");
            var selection = System.Console.ReadLine();
            bool selected = int.TryParse(selection, out int SelectionResult);
            if (!selected)
            {
                Helper.FalseValue(selected, false);
                TemperatureSelection();
            }
            decimal Result = 0;
            switch (SelectionResult)
            {
                case 0:
                    Start();
                    break;
                case 1:
                    Result = Temperature.FahToCel();
                    break;
                case 2:
                    Result = Temperature.CelToFah();
                    break;
                default:
                    Helper.FalseValue();
                    TemperatureSelection();
                    break;
            }
            FinalResult(Result: Result, optionStatus:1);
        }
        public static void FinalResult(string OperatorUsed = "", decimal Result = 0, int optionStatus = 0)
        {
            System.Console.Clear();
            System.Console.WriteLine("***Results***");
            System.Console.WriteLine();
            if (optionStatus == 1){
                System.Console.WriteLine($"{Result}");
                Helper.FalseValue(true, true);
                TemperatureSelection();
            }
            else{
            System.Console.WriteLine($"{Routes.FirstInput} {OperatorUsed} {Routes.SecondInput} = {Result}");
            Helper.FalseValue(true,true);
            CalculatorSelection();
            }

        }

    }

}