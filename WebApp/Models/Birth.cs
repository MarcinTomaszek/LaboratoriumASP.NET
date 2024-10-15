using System.Runtime.InteropServices.JavaScript;

namespace WebApp.Models;

public class Birth
{
    public string? name { get; set; }
    public DateTime? date { get; set; }
    
    public bool IsValid()
    {
        return name != null && date != null&& DateTime.Now >date;
    }
    
    public int? Calculate()
    {
        return (int?)((DateTime.Now- date).Value.TotalDays/365);
    }
}

