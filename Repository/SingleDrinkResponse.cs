namespace DotNETConsole.DrinksInfo.Repository;

using System.Text.Json.Serialization;

public record class SingleDrinkResponse(
    [property: JsonPropertyName("drinks")] List<SingleDrinkRecord>? Drinks
);
