namespace Gantt_Chart_Backend.Data.Models;

public class JwtOptions
{
    public string SecretKey { get; set; } = string.Empty;
    public int ExpireHours { get; set; }
}