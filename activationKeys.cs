namespace softUniFund_FinalExamPrep2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            string command = Console.ReadLine();
            while(command != "Generate")
            {
                string[] commandParts = command.Split(">>>");
                switch(commandParts[0])
                {
                    case "Contains":
                        if(activationKey.Contains(commandParts[1])) Console.WriteLine($"{activationKey} contains {commandParts[1]}");
                        else Console.WriteLine("Substring not found!");
                        break;
                    case "Flip":
                        string upperOrLowerString = "";
                        for(int i = int.Parse(commandParts[2]); i < int.Parse(commandParts[3]); i++)
                        {
                            upperOrLowerString += activationKey[i];
                        }
                        if(commandParts[1] == "Upper") activationKey = activationKey.Replace(upperOrLowerString, upperOrLowerString.ToUpper());
                        else activationKey = activationKey.Replace(upperOrLowerString, upperOrLowerString.ToLower());

                        Console.WriteLine(activationKey);
                        break;
                    case "Slice":
                        activationKey = activationKey.Remove(int.Parse(commandParts[1]), int.Parse(commandParts[2]) - int.Parse(commandParts[1]));
                        Console.WriteLine(activationKey);
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}