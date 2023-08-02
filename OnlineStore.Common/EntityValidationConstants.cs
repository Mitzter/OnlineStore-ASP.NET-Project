namespace OnlineStore.Common
{
    using System.ComponentModel.DataAnnotations;

    public static class EntityValidationConstants
    {
        public static class Item
        {
            public const int ItemNameMinLength = 6;
            public const int ItemNameMaxLength = 100;

            public const int ItemDescriptionMinLength = 0;
            public const int ItemDescriptionMaxLength = 5000;

            public const int ImageUrlMaxLength = 2000;

            public const string PriceMinValue = "0";
            public const string PriceMaxValue = "10000";

        }

        public static class Post
        {

            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 100;

            public const int TextMinLength = 5;
            public const int TextMaxLength = 10000;

            public const int ImageUrlMaxLength = 2000;

        }

        public static class Reply
        {
            public const int MessageMinLength = 2;
            public const int MessageMaxLength = 10000;
        }

        public static class BulkBuyer
        {
            public const int PhoneNumberMinLength = 8;
            public const int PhoneNumberMaxLength = 15;

            public const int VATNumberMinLength = 9;
            public const int VatNumberMaxLength = 13;

            public const int CompanyNameMinLength = 3;
            public const int CompanyNameMaxLength = 50;

            public const int FinancialManagerNameMinLength = 6;
            public const int FinancialManagerNameMaxLength = 100;
        }

    }
}
