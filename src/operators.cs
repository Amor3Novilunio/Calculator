using src.routes;

namespace src.Operators
{
    public class Operators : Routes
    {
        private static decimal Operation(string name,bool reverse = false){
            decimal firstInput = FirstInput;
            decimal secondInput = SecondInput;
            if (reverse){
                decimal oldValue = FirstInput;
                firstInput = secondInput;
                secondInput = oldValue;
            }
            return name switch{
                "Add" => firstInput + secondInput,
                "Subtraction" => firstInput - secondInput,
                "Multiplication" => firstInput * secondInput,
                "Division" => firstInput / secondInput,
                _ => 0
            };
        }
        public decimal Add(bool reverse = false) => Operation(nameof(Add), reverse);
        public decimal Subtraction(bool reverse = false) => Operation(nameof(Subtraction), reverse);
        public decimal Multiplication(bool reverse = false) => Operation(nameof(Multiplication), reverse);
        public decimal Division(bool reverse = false) => Operation(nameof(Division), reverse); 
    }
}