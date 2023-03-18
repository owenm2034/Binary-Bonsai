namespace Binary_Bonsai;

public class BonsaiTree
{
    public Guid Id { get; set; }
    public string? name { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}
