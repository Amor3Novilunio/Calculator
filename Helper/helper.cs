namespace helper
{
    public static class Helper{
        public static void SelectionOption(string[] collection)
        {
            foreach (var selection in collection)
            {
                System.Console.WriteLine(selection);
            }
        }
        public static void FalseValue(bool isFieldOne = false, bool isFieldTwo = false)
        {
            if (!isFieldOne || !isFieldTwo)
            {
                System.Console.WriteLine("Please Enter A Number");
            }
            System.Console.Write("Press Enter to Continue");
            System.Console.ReadLine();
            System.Console.Clear();
        }
    }
}