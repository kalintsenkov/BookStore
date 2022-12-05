namespace BookStore.Domain.Sales.Models.Books;

using System;
using System.Collections.Generic;
using Common;

internal class BookData : IInitialData
{
    public Type EntityType => typeof(Book);

    public IEnumerable<object> GetData()
        => new List<Book>
        {
            new(
                title: "It", 
                price: 19.99M, 
                quantity: 100, 
                imageUrl: "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1334416842l/830502.jpg")
        };
}