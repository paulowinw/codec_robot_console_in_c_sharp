public class CommandHandler
{
    static void Main(string[] args) 
    {
        string? marsPlateauSize;
        string? commands;
        string location;
        MarsPlateau marsPlateau;
        Robot robot;

        Console.Write("Welcome to the robot moviment console!" + Environment.NewLine + Environment.NewLine);
        Console.Write("You can use following commands:" + Environment.NewLine);
        Console.Write("L: Turn the robot left" + Environment.NewLine);
        Console.Write("R: Turn the robot right" + Environment.NewLine);
        Console.Write("F: Move forward on its facing direction" + Environment.NewLine + Environment.NewLine);

        Console.Write("Enter a plateau size: default (5x5):"  + Environment.NewLine);

        try
        {
            marsPlateauSize = Console.ReadLine();
            if (string.IsNullOrEmpty(marsPlateauSize))
            {
                marsPlateauSize = "5x5";
            }
            marsPlateau = new MarsPlateau(marsPlateauSize);

            Console.Write("Enter a moviment command: default (FFRFLFLF):" + Environment.NewLine);
            commands = Console.ReadLine();
            if (string.IsNullOrEmpty(commands))
            {
                commands = "FFRFLFLF";
            }
            robot = new Robot(marsPlateau);
            location = robot.move(commands);

            Console.Write(Environment.NewLine + location);
        }
        catch (WrongCommandException e)
        {
            Console.Write(Environment.NewLine + "Error: " + e.Message);
        } 
        catch
        {
            Console.Write(Environment.NewLine + "Error: Invalid input!!");
        }
        
    }
}
