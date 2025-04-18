﻿namespace OM.Assessment.API.Controllers;

public class ApiResponse
{
    public bool Success { get; set; }
    public object? Data { get; set; }
    public string? Message { get; set; }
}

public class PaginatedResponse : ApiResponse
{
    public int TotalItems { get; set; }
}