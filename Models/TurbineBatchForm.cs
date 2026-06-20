namespace WindServiceManager.Models;

public class TurbineBatchForm
{
    public string Prefix { get; set; } = "WTG";
    public int StartNumber { get; set; } = 1;
    public int Count { get; set; } = 1;
    public string Location { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
}
