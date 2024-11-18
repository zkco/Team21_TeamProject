using System;

    public static class StringExtensions
    {
    /// <summary>
    /// string�� enum���� ��ȯ���ִ� �޼���.
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

