namespace BookStore.Domain.Sales.Models;

public class ModelConstants
{
    public class Address
    {
        public const int MinCityLength = 3;
        public const int MaxCityLength = 255;
        public const int MinStateLength = 3;
        public const int MaxStateLength = 255;
        public const int MinDescriptionLength = 3;
        public const int MaxDescriptionLength = 1000;
        public const int MinPostalCodeLength = 3;
        public const int MaxPostalCodeLength = 10;
    }

    public class PhoneNumber
    {
        public const int MinPhoneNumberLength = 5;
        public const int MaxPhoneNumberLength = 20;
        public const string PhoneNumberRegularExpression = @"\+[0-9]*";
    }

    public class OrderedBook
    {
        public const int MinQuantityValue = 1;
        public const int MaxQuantityValue = 10;
    }
}