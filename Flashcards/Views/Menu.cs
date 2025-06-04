using Spectre.Console;

namespace Flashcards.Views;

public class Menu
{
    internal void MainMenu()
    {
        var isMenuRunning = true;
        while (isMenuRunning)
        {
            var userChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What would you like to do?")
                    .AddChoices(
                        "Math",
                        "Science",
                        "Quit"
                    ));
            switch (userChoice)
            {
                case "Math":
                    Console.Clear();
                    break;
                case "Science":
                    Console.Clear();
                    break;
                case "Quit":
                    AnsiConsole.WriteLine("Goodbye");
                    isMenuRunning = false;
                    break;
            }
        }
    }
}