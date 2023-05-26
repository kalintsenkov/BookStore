namespace BookStore.Application.Common.Contracts;

using System;

public interface IDateTime
{
    DateTime Now { get; }
}