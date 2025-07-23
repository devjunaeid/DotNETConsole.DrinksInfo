namespace DotNETConsole.DrinksInfo.Controllers;

using System.Text.Json;
using System.Web;
using Repository;

public class DrinkController{

  public async Task<List<DrinkCategoryRecord>?> GetDrinksCategories(){
    using (HttpClient client = new())
    {
        await using Stream stream =  await client.GetStreamAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
        var res = await JsonSerializer.DeserializeAsync<DrinkCategoryResponse>(stream);
        return res?.DrinkCategories;
    }
  }

  public async Task<List<DrinksInSingleCategoy>?> GetDrinksInSingleCategoy(string category_name){

    using (HttpClient client = new())
    {
        await using Stream stream =  await client.GetStreamAsync($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={HttpUtility.UrlEncode(category_name)}");
        var res = await JsonSerializer.DeserializeAsync<DrinksInSingleCategoryResponse>(stream);
        return res?.Drinks;
    }
  }

public async Task<SingleDrinkRecord?> GetDrinkById(string id){
    using (HttpClient client = new())
    {
        await using Stream stream =  await client.GetStreamAsync($"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={id}");
        var res = await JsonSerializer.DeserializeAsync<SingleDrinkResponse>(stream);
        return res?.Drinks?.FirstOrDefault(); 
    }
  }


public async Task<SingleDrinkRecord?> GetARandomDrink(){
    using (HttpClient client = new())
    {
        await using Stream stream =  await client.GetStreamAsync("https://www.thecocktaildb.com/api/json/v1/1/random.php");
        var res = await JsonSerializer.DeserializeAsync<SingleDrinkResponse>(stream);
        return res?.Drinks?.FirstOrDefault(); 
    }
  }
}
