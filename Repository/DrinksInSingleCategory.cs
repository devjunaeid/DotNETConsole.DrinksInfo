namespace DotNETConsole.DrinksInfo.Repository;
using System.Text.Json.Serialization;

public record class DrinksInSingleCategoy(
    [property: JsonPropertyName("strDrink")] string DrinkName,
    [property: JsonPropertyName("strDrinkThumb")] string CoverImage,
    [property: JsonPropertyName("idDrink")] string DrinkId
){
    public override string ToString()
      {
          return $"{this.DrinkName}";
      }
}
