namespace Gantt_Chart_Backend.Exceptions;

public class ResourceNotFoundException : Exception
{
    public ResourceNotFoundException(string message = "Resource not found") 
        : base(message) { }
}