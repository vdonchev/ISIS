namespace IsIs.Core.Utils
{
    using System;

    public static class Validator
    {
        public static void IfIsNull(object item)
        {
            if (item == null)
            {
                throw new ArgumentNullException($"{nameof(item)} can't be null.");
            }
        }

        public static void IfStringIsNullOrEmpty(string value)
        {
            if (string.IsNullOrEmpty(value.Trim()))
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public static void IfStringIsEmpty(string value)
        {
            if (value.Trim().Length == 0)
            {
                throw new ArgumentException($"{nameof(value)} can't be empty.");
            }
        }

        public static void IfIsBiggerThan<T>(T value, T minRequired, bool inclusive = false)
            where T : IComparable<T>
        {
            var result = value.CompareTo(minRequired);

            if (inclusive)
            {
                if (result < 0)
                {
                    throw new ArgumentException($"{nameof(value)} should be bigger than or equal to {minRequired}");
                }
            }
            else
            {
                if (result < 1)
                {
                    throw new ArgumentException($"{nameof(value)} should be bigger than {minRequired}");
                }
            }
        }

        public static void IfIsInRange<T>(T value, T minRequired, T maxRequired, bool inclusive = false)
            where T : IComparable<T>
        {
            var minBorderResult = value.CompareTo(minRequired);
            var maxBorderResult = value.CompareTo(maxRequired);

            if (inclusive)
            {
                if (minBorderResult < 0 || maxBorderResult > 0)
                {
                    throw new ArgumentException($"{nameof(value)} ({value}) should be in range [{minRequired}...{maxRequired}] inclusively.");
                }
            }
            else
            {
                if (minBorderResult < 1 || maxBorderResult > 1)
                {
                    throw new ArgumentException($"{nameof(value)} ({value}) should be in range [{minRequired}...{maxRequired}] exclusively.");
                }
            }
        }
    }
}