namespace BookStore.Infrastructure.Common.Services;

using System;
using Application.Common.Contracts;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.UtcNow;
}