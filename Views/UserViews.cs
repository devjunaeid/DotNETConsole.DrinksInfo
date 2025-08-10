namespace DotNETConsole.DrinksInfo.Views;
using Spectre.Console;
using Repository;

public class UserViews
{
    public void ShowProjectInfo()
    {
        var appName = new FigletText("Foo Bar")
                .Color(Color.Cyan1)
                .Centered();
        AnsiConsole.Write(appName);
        AnsiConsole.Write(new Align(new Markup("-[orange3 italic] Get drinks from your favorite programming bar...[/]"), HorizontalAlignment.Center, VerticalAlignment.Top));
    }

    public void ShowSingleDrink(SingleDrinkRecord drink)
    {
        AnsiConsole.Write(
            new Panel(
                new Markup($"[bold yellow]{drink.DrinkName}[/]\n\n" +
                           $"[blue]Category:[/] {drink.DrinkCategory}\n" +
                           $"[blue]Glass:[/] {drink.DrinkGlass}\n" +
                           $"[blue]Last Update:[/] {DateTime.Parse(drink.LastModified).ToShortDateString()}\n\n" +
                           $"[green]Instructions:[/]\n{drink.Instructions}")
            )
            .Header("[underline green]Drink Info[/]")
            .Collapse()
            .Border(BoxBorder.Rounded)
            .Padding(1, 1)
        );

        var table = new Table()
            .Title("Ingredients")
            .AddColumn("Ingredient")
            .AddColumn("Measure")
            .Border(TableBorder.Rounded);

        var ingredients = new[]
        {
        (drink.Measure1, drink.Ingredient1),
        (drink.Measure2, drink.Ingredient2),
        (drink.Measure3, drink.Ingredient3),
        (drink.Measure4, drink.Ingredient4),
        (drink.Measure5, drink.Ingredient5),
        (drink.Measure6, drink.Ingredient6),
        (drink.Measure7, drink.Ingredient7),
        (drink.Measure8, drink.Ingredient8),
        (drink.Measure9, drink.Ingredient9),
        (drink.Measure10, drink.Ingredient10),
        (drink.Measure11, drink.Ingredient11),
        (drink.Measure12, drink.Ingredient12),
        (drink.Measure13, drink.Ingredient13),
        (drink.Measure14, drink.Ingredient14),
        (drink.Measure15, drink.Ingredient15),
    };

        foreach (var (measure, ingredient) in ingredients)
        {
            if (!string.IsNullOrWhiteSpace(ingredient))
            {
                table.AddRow(ingredient ?? "-", measure ?? "-");
            }
        }
        AnsiConsole.Write(table);
    }
}
