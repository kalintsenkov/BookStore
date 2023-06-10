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
                price: 16.99M,
                quantity: 100,
                imageUrl: "https://m.media-amazon.com/images/I/71oWFPril4L.jpg",
                description: "A promise made twenty-eight years ago calls seven adults to reunite in Derry, Maine, where as teenagers they battled an evil creature that preyed on the city's children. Unsure that their Losers Club had vanquished the creature all those years ago, the seven had vowed to return to Derry if IT should ever reappear. Now, children are being murdered again and their repressed memories of that summer return as they prepare to do battle with the monster lurking in Derry's sewers once more.",
                genre: Genre.Horror,
                author: new Author(
                    "Stephen King",
                    @"Stephen Edwin King (born September 21, 1947) is an American author of horror, supernatural fiction, suspense, crime, science-fiction, and fantasy novels. Described as the ""King of Horror"", a play on his surname and a reference to his high standing in pop culture, his books have sold more than 350 million copies, and many have been adapted into films, television series, miniseries, and comic books. King has published 64 novels, including seven under the pen name Richard Bachman, and five non-fiction books. He has also written approximately 200 short stories, most of which have been published in book collections.")),
            new(
                title: "The Hitchhiker's Guide to the Galaxy",
                price: 7.99M,
                quantity: 100,
                imageUrl: "https://m.media-amazon.com/images/I/91TpAAdiBLL.jpg",
                description: @"Seconds before the Earth is demolished to make way for a galactic freeway, Arthur Dent is plucked off the planet by his friend Ford Prefect, a researcher for the revised edition of The Hitchhiker's Guide to the Galaxy who, for the last fifteen years, has been posing as an out-of-work actor. Together this dynamic pair begin a journey through space aided by quotes from The Hitchhiker's Guide (""A towel is about the most massively useful thing an interstellar hitchhiker can have"") and a galaxy-full of fellow travelers: Zaphod Beeblebrox--the two-headed, three-armed ex-hippie and totally out-to-lunch president of the galaxy; Trillian, Zaphod's girlfriend (formally Tricia McMillan), whom Arthur tried to pick up at a cocktail party once upon a time zone; Marvin, a paranoid, brilliant, and chronically depressed robot; Veet Voojagig, a former graduate student who is obsessed with the disappearance of all the ballpoint pens he bought over the years. Where are these pens? Why are we born? Why do we die? Why do we spend so much time between wearing digital watches? For all the answers stick your thumb to the stars. And don't forget to bring a towel!",
                genre: Genre.Fantasy,
                author: new Author(
                    "Douglas Adams",
                    @"Douglas Adams was an English author, comic radio dramatist, and musician. He is best known as the author of the Hitchhiker's Guide to the Galaxy series. Hitchhiker's began on radio, and developed into a 'trilogy' of five books (which sold more than fifteen million copies during his lifetime) as well as a television series, a comic book series, a computer game, and a feature film that was completed after Adams' death. The series has also been adapted for live theatre using various scripts; the earliest such productions used material newly written by Adams. He was known to some fans as Bop Ad (after his illegible signature), or by his initials 'DNA'.")),
            new(
                title: "To Kill a Mockingbird",
                price: 9.99M,
                quantity: 100,
                imageUrl: "https://m.media-amazon.com/images/I/81NeMmw4RQL.jpg",
                description: @"Set in the 1930s, this Pulitzer Prize-winning novel follows Scout Finch, a young girl growing up in Alabama. As her father, Atticus Finch, defends a black man falsely accused of raping a white woman, Scout learns about racism, injustice, and the importance of empathy.",
                genre: Genre.Drama,
                author: new Author(
                    "Harper Lee",
                    @"Harper Lee (April 28, 1926 – February 19, 2016) was an American novelist widely known for her novel To Kill a Mockingbird, published in 1960. Immediately successful, it won the 1961 Pulitzer Prize and has become a classic of modern American literature. Though Lee had only published this single book, in 2007 she was awarded the Presidential Medal of Freedom for her contribution to literature.")),
            new(
                title: "1984",
                price: 12.49M,
                quantity: 100,
                imageUrl: "https://m.media-amazon.com/images/I/819ijTWp9JL.jpg",
                description: @"Set in a dystopian future, George Orwell's 1984 depicts a totalitarian regime where individuality and freedom are suppressed. The story follows Winston Smith as he rebels against the oppressive government's surveillance and control.",
                genre: Genre.Dystopian,
                author: new Author(
                    "George Orwell",
                    @"George Orwell, the pen name of Eric Arthur Blair (25 June 1903 – 21 January 1950), was an English novelist, essayist, journalist, and critic. His work is characterized by lucid prose, biting social criticism, opposition to totalitarianism, and outspoken support for democratic socialism.")),
            new(
                title: "Pride and Prejudice",
                price: 8.99M,
                quantity: 100,
                imageUrl: "https://m.media-amazon.com/images/I/91eKRbuhgaL.jpg",
                description: @"Jane Austen's classic novel follows the story of Elizabeth Bennet as she navigates the societal norms, expectations, and prejudices of the English gentry in the early 19th century. The book explores themes of love, marriage, and social hierarchy.",
                genre: Genre.Romance,
                author: new Author(
                    "Jane Austen",
                    @"Jane Austen (16 December 1775 – 18 July 1817) was an English novelist known primarily for her six major novels, which interpret, critique and comment upon the British landed gentry at the end of the 18th century. Austen's plots often explore the dependence of women on marriage in the pursuit of favourable social standing and economic security.")),
            new(
                title: "The Alchemist",
                price: 9.49M,
                quantity: 100,
                imageUrl: "https://m.media-amazon.com/images/I/71pJIgY8ZuL.jpg",
                description: @"Paulo Coelho's novel tells the story of Santiago, an Andalusian shepherd boy who embarks on a journey to discover his personal legend. Along the way, he encounters a series of characters and experiences that impart wisdom and lessons on following one's dreams.",
                genre: Genre.Fiction,
                author: new Author(
                    "Paulo Coelho",
                    @"Paulo Coelho is a Brazilian author known for his spiritual and inspirational writings. His book The Alchemist has been translated into numerous languages and has sold millions of copies worldwide, becoming one of the most widely translated and best-selling books in history.")),
            new(
                title: "The Da Vinci Code",
                price: 14.99M,
                quantity: 100,
                imageUrl: "https://m.media-amazon.com/images/I/91Q5dCjc2KL.jpg",
                description: @"Dan Brown's thrilling mystery follows symbologist Robert Langdon as he investigates a murder in the Louvre Museum, leading him to unravel a series of clues hidden within the works of Leonardo da Vinci. Langdon's quest takes him on a suspenseful journey across Europe, uncovering a secret that could shake the foundations of Christianity.",
                genre: Genre.Mystery,
                author: new Author(
                    "Dan Brown",
                    @"Dan Brown is an American author known for his best-selling novels, including The Da Vinci Code. His books often combine elements of mystery, history, art, and symbols, captivating readers with their intricate plots and fast-paced storytelling.")),
            new(
                title: "Alan Turing: The Enigma",
                price: 11.49M,
                quantity: 100,
                imageUrl: "https://m.media-amazon.com/images/I/71AybBHkHAL.jpg",
                description: @"Alan Turing: The Enigma is a biography that explores the life and work of Alan Turing, a pioneering mathematician, computer scientist, and codebreaker. Written by Andrew Hodges, this book delves into Turing's contributions to the field of computer science, his crucial role in breaking the German Enigma code during World War II, and the challenges he faced as a gay man in a time of societal intolerance. It provides a comprehensive look at Turing's intellectual brilliance, his impact on modern technology, and the tragic circumstances surrounding his life.",
                genre: Genre.Biography,
                author: new Author(
                    "Andrew Hodges",
                    @"Andrew Hodges is a British mathematician and author. His biography, Alan Turing: The Enigma, is considered one of the most authoritative accounts of Turing's life. Hodges explores Turing's mathematical genius, his groundbreaking ideas in the field of computing, and the impact of his work on cryptography and artificial intelligence. The book offers a deep insight into Turing's remarkable mind and his significant contributions to science and technology.")),
            new(
                title: "Sapiens: A Brief History of Humankind",
                price: 15.99M,
                quantity: 100,
                imageUrl: "https://m.media-amazon.com/images/I/716E6dQ4BXL.jpg",
                description: @"Sapiens: A Brief History of Humankind is a captivating exploration of the history of our species. Written by Yuval Noah Harari, the book takes readers on a journey from the emergence of Homo sapiens in Africa to the present-day global dominance of our species. Harari examines key turning points in human history, such as the Agricultural Revolution and the rise of empires, while delving into thought-provoking topics like the impact of technology, the development of cultures, and the future of humankind. This book offers a thought-provoking perspective on our shared history and the forces that have shaped our world.",
                genre: Genre.History,
                author: new Author(
                    "Yuval Noah Harari",
                    @"Yuval Noah Harari is an Israeli historian and professor at the Hebrew University of Jerusalem. In Sapiens: A Brief History of Humankind, Harari draws on insights from various disciplines to provide a comprehensive and accessible account of human history. His thought-provoking analysis challenges conventional wisdom and prompts readers to contemplate the future of our species."))
        };
}