namespace DotNETConsole.DrinksInfo.Views;

using Spectre.Console;
using Repository;
using Enums;

public class UserInputViews
{

    public MainUi GetUiSelection()
    {
        MainUi choice = AnsiConsole.Prompt(new SelectionPrompt<MainUi>()
            .Title("Select [green]options from the menu.[/]?").AddChoices(new List<MainUi>((MainUi[])Enum.GetValues(typeof(MainUi)))));
        return choice;
    }

    public string GetDrinkCategorySelection(List<DrinkCategoryRecord> drinks)
    {
        DrinkCategoryRecord choice = AnsiConsole.Prompt(new SelectionPrompt<DrinkCategoryRecord>()
            .Title("Select [green]options from the menu.[/]?").AddChoices(drinks));
        return choice.DrinkCategory;
    }

    public string GetDrinkSelection(List<DrinksInSingleCategoy> drinks)
    {
        DrinksInSingleCategoy choice = AnsiConsole.Prompt(new SelectionPrompt<DrinksInSingleCategoy>()
            .Title("Select [green]options from the menu.[/]?").AddChoices(drinks));
        return choice.DrinkId;
    }

    public bool ContinueInput(string? extraMessage = null)
    {
        if (extraMessage != null)
        {
            AnsiConsole.MarkupLineInterpolated($"\n[blue]{extraMessage}[/]");
        }

        AnsiConsole.MarkupLine("[green]Press ESC to continue...[/]");

        while (true)
        {
            var keyPressed = AnsiConsole.Console.Input.ReadKey(true);
            if (keyPressed is { Key: ConsoleKey.Escape })
            {
                return true;
            }
        }
    }
}
