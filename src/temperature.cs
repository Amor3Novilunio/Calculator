using src.routes;

namespace src.Temperature 
{
    public class Temperature : Routes
    {
        public static decimal FahToCel()=> (FirstInput * 9 / 5) + 32;
        public static decimal CelToFah() => (FirstInput - 32) * 5 / 9;
    }
}