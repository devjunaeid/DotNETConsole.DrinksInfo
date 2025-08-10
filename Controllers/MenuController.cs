namespace DotNETConsole.DrinksInfo.Controllers;
using Views;
using Enums;
using System.Threading.Tasks;

public class MenuController
{
    private static bool IsRunning { get; set; }
    private UserInputViews _userInput = new UserInputViews();
    private UserViews _userViews = new UserViews();
    private DrinkController _drinkController = new DrinkController();

    public MenuController()
    {
        IsRunning = true;
    }

    public async Task MainMenu()
    {
        while (IsRunning)
        {
            _userViews.ShowProjectInfo();
            var choice = _userInput.GetUiSelection();
            switch (choice)
            {
                case MainUi.Drink_Catelouge:
                    var drinksCategory = await _drinkController.GetDrinksCategories();
                    if (drinksCategory is null || drinksCategory.Count == 0)
                    {
                        Console.WriteLine("No Category Found");
                    }
                    else
                    {
                        var selectedDrinkCategory = _userInput.GetDrinkCategorySelection(drinksCategory);
                        var drinksInSelectedCategory = await _drinkController.GetDrinksInSingleCategoy(selectedDrinkCategory);
                        if (drinksInSelectedCategory is null || drinksInSelectedCategory.Count <= 0)
                        {
                            Console.WriteLine($"No Drinks Found in {selectedDrinkCategory}");
                            break;
                        }
                        else
                        {
                            var selectedDrink = _userInput.GetDrinkSelection(drinksInSelectedCategory);
                            var fetchedDrink = await _drinkController.GetDrinkById(selectedDrink);
                            if (fetchedDrink is null)
                            {
                                Console.WriteLine("Sorry No Drink Found with this ID.");
                                break;
                            }
                            else
                            {
                                _userViews.ShowSingleDrink(fetchedDrink);
                            }
                        }
                    }
                    _userInput.ContinueInput();
                    Console.Clear();
                    break;
                case MainUi.Get_A_Random_Drink:
                    var drink = await _drinkController.GetARandomDrink();
                    if (drink is null)
                    {
                        Console.WriteLine("Sorry No Drink Found this time try again.");
                        break;
                    }
                    else
                    {
                        _userViews.ShowSingleDrink(drink);
                    }
                    _userInput.ContinueInput();
                    Console.Clear();
                    break;
                case MainUi.Exit:
                    IsRunning = false;
                    Console.Clear();
                    break;
            }
        }
    }
}
