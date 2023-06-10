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
                imageUrl: "https://m.media-amazon.com/images/I/71oWFPril4L.jpg"),
            new(
                title: "The Hitchhiker's Guide to the Galaxy",
                price: 7.99M,
                quantity: 100,
                imageUrl: "https://m.media-amazon.com/images/I/91TpAAdiBLL.jpg"),
            new(
                title: "To Kill a Mockingbird",
                price: 9.99M,
                quantity: 100,
                imageUrl: "https://m.media-amazon.com/images/I/81NeMmw4RQL.jpg"),
            new(
                title: "1984",
                price: 12.49M,
                quantity: 100,
                imageUrl: "https://m.media-amazon.com/images/I/819ijTWp9JL.jpg"),
            new(
                title: "Pride and Prejudice",
                price: 8.99M,
                quantity: 100,
                imageUrl: "https://m.media-amazon.com/images/I/91eKRbuhgaL.jpg"),
            new(
                title: "The Alchemist",
                price: 9.49M,
                quantity: 100,
                imageUrl: "https://m.media-amazon.com/images/I/71pJIgY8ZuL.jpg"),
            new(
                title: "The Da Vinci Code",
                price: 14.99M,
                quantity: 100,
                imageUrl: "https://m.media-amazon.com/images/I/91Q5dCjc2KL.jpg"),
            new(
                title: "Alan Turing: The Enigma",
                price: 11.49M,
                quantity: 100,
                imageUrl: "https://m.media-amazon.com/images/I/71AybBHkHAL.jpg"),
            new(
                title: "Sapiens: A Brief History of Humankind",
                price: 15.99M,
                quantity: 100,
                imageUrl: "https://m.media-amazon.com/images/I/716E6dQ4BXL.jpg")
        };
}