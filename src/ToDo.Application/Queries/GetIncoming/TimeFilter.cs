namespace ToDo.Application.Queries.GetIncoming;

/// <summary>
/// Enum for filtering time range for GetIncomingToDoTaskQuery
/// </summary>
public enum TimeFilter
{
    Today = 1,
    Tomorrow = 2,
    CurrentWeek = 3
}