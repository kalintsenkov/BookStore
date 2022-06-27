namespace BookStore.Domain.Sales.Models;

public class ModelConstants
{
    public class Address
    {
        public const int MinAddressLength = 2;
        public const int MaxAddressLength = 360;
    }

    public class PhoneNumber
    {
        public const int MinPhoneNumberLength = 5;
        public const int MaxPhoneNumberLength = 20;
        public const string PhoneNumberRegularExpression = @"\+[0-9]*";
    }
}