namespace BookStore.Domain.Common.Models;

public class ModelConstants
{
    public class Common
    {
        public const int MinNameLength = 2;
        public const int MaxNameLength = 120;
        public const int MaxUrlLength = 2048;
        public const int MinDescriptionLength = 5;
        public const int MaxDescriptionLength = 1200;
        public const string AdministratorRoleName = "Administrator";
    }

    public class Identity
    {
        public const int MinEmailLength = 3;
        public const int MaxEmailLength = 50;
        public const int MinPasswordLength = 6;
        public const int MaxPasswordLength = 32;
    }

    public class Book
    {
        public const decimal MinPriceValue = decimal.One;
        public const decimal MaxPriceValue = decimal.MaxValue;
        public const int MinQuantityValue = 1;
        public const int MaxQuantityValue = int.MaxValue;
    }
}