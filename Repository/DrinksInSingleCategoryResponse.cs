namespace DotNETConsole.DrinksInfo.Repository;

using System.Text.Json.Serialization;

public record class DrinksInSingleCategoryResponse(
    [property: JsonPropertyName("drinks")] List<DrinksInSingleCategoy>? Drinks
);
