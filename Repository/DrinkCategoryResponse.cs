namespace DotNETConsole.DrinksInfo.Repository;

using System.Text.Json.Serialization;

public record class DrinkCategoryResponse(
    [property: JsonPropertyName("drinks")] List<DrinkCategoryRecord>? DrinkCategories
);
