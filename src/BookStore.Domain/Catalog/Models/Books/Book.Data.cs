namespace BookStore.Domain.Catalog.Models.Books;

using System;
using System.Collections.Generic;
using Authors;
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
                description: "A promise made twenty-eight years ago calls seven adults to reunite in Derry, Maine, where as teenagers they battled an evil creature that preyed on the city's children. Unsure that their Losers Club had vanquished the creature all those years ago, the seven had vowed to return to Derry if IT should ever reappear. Now, children are being murdered again and their repressed memories of that summer return as they prepare to do battle with the monster lurking in Derry's sewers once more.",
                genre: Genre.Horror,
                author: new Author(
                    "Stephen King",
                    @"Stephen Edwin King (born September 21, 1947) is an American author of horror, supernatural fiction, suspense, crime, science-fiction, and fantasy novels. Described as the ""King of Horror"", a play on his surname and a reference to his high standing in pop culture, his books have sold more than 350 million copies, and many have been adapted into films, television series, miniseries, and comic books. King has published 64 novels, including seven under the pen name Richard Bachman, and five non-fiction books. He has also written approximately 200 short stories, most of which have been published in book collections."))
        };
}