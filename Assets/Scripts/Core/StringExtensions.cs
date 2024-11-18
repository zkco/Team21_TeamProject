using System;

    public static class StringExtensions
    {
    /// <summary>
    /// string을 enum으로 변환해주는 메서드.
    /// </summary>
    public static T StringToEnum<T>(this string value) where T : struct
        {
            if (Enum.TryParse<T>(value, true, out var enumValue))
            {
                return enumValue;
            }
            else
            {
                throw new ArgumentNullException(nameof(value));
            }
        }
    }

