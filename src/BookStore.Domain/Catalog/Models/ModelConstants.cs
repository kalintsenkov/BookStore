namespace BookStore.Domain.Catalog.Models;

public class ModelConstants
{
    public class Common
    {
        public const int MinDescriptionLength = 5;
        public const int MaxDescriptionLength = 1200;
    }

    public class Book
    {
        public const decimal MinPriceValue = decimal.One;
        public const decimal MaxPriceValue = decimal.MaxValue;
        public const int MinQuantityValue = 1;
        public const int MaxQuantityValue = int.MaxValue;
    }
}