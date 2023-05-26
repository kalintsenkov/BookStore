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
                price: 16.99M,
                quantity: 100,
                imageUrl: "https://m.media-amazon.com/images/I/71oWFPril4L._AC_UF1000,1000_QL80_.jpg"),
            new(
                title: "The Hitchhiker's Guide to the Galaxy",
                price: 7.99M,
                quantity: 100,
                imageUrl: "https://m.media-amazon.com/images/I/91TpAAdiBLL.jpg")
        };
}