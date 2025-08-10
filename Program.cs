namespace DotNETConsole.DrinksInfo;

using System.Threading.Tasks;
using Controllers;


public class Program
{
    private static MenuController _menuController = new MenuController();
    public static async Task Main(string[] args)
    {
        await _menuController.MainMenu();
    }
}
