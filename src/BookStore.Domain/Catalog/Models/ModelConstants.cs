namespace BookStore.Domain.Catalog.Models;

public class ModelConstants
{
    public class Common
    {
        public const int MinNameLength = 2;
        public const int MaxNameLength = 120;

        public const int MinDescriptionLength = 5;
        public const int MaxDescriptionLength = 1200;
    }

    public class Book
    {
        public const decimal MinPriceValue = decimal.One;
        public const decimal MaxPriceValue = decimal.MaxValue;
    }
}