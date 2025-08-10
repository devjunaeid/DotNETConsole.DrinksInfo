namespace DotNETConsole.DrinksInfo.Repository;
using System.Text.Json.Serialization;

public record class DrinkCategoryRecord(
    [property: JsonPropertyName("strCategory")] string DrinkCategory
)
{
    public override string ToString()
    {
        return $"{this.DrinkCategory}";
    }
}
