using System;

namespace Smart.Framework.Core
{
  /// <summary>
  ///   Класс, олицетворяющий версию программного продукта.
  /// </summary>
  [Serializable]
  public class Version : IEquatable<Version>, IComparable<Version>, ICloneable
  {
    /// <summary>
    ///   Возвращает главную часть версии.
    /// </summary>
    public readonly int Major;

    /// <summary>
    ///   Возвращает второстепенную часть версии.
    /// </summary>
    public readonly int Minor;

    /// <summary>
    ///   Конструктор.
    /// </summary>
    /// <param name="value">Строковое представление.</param>
    /// <exception cref="ArgumentException" />
    /// <exception cref="ArgumentNullException" />
    /// <exception cref="FormatException" />
    /// <exception cref="OverflowException" />
    public Version(string value)
    {
      if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("value");

      var s = value.Split(new[] {'.'}, StringSplitOptions.None);
      if (s.Length != 2) throw new ArgumentException();

      Major = int.Parse(s[0]);
      Minor = int.Parse(s[1]);
    }

    /// <summary>
    ///   Конструтор.
    /// </summary>
    /// <param name="value">Версия.</param>
    /// <exception cref="ArgumentNullException" />
    public Version(Version value)
    {
      if (value == null) throw new ArgumentNullException("value");

      Major = value.Major;
      Minor = value.Minor;
    }

    public object Clone()
    {
      return new Version(this);
    }

    public int CompareTo(Version other)
    {
      if (other == null) throw new ArgumentNullException("other");

      if (Major == other.Major && Minor == other.Minor) return 0;

      if (Major == other.Major) return Minor < other.Minor ? -1 : 1;

      return Major < other.Major ? -1 : 1;
    }

    public bool Equals(Version other)
    {
      if (other == null) return false;

      return other.Major == Major && other.Minor == Minor;
    }

    public static bool operator ==(Version value1, Version value2)
    {
      if ((object) value1 == null && (object) value2 == null) return true;

      if ((object) value1 == null || (object) value2 == null) return false;

      return value1.Equals(value2);
    }

    public static bool operator !=(Version value1, Version value2)
    {
      return !(value1 == value2);
    }

    public static bool operator >(Version value1, Version value2)
    {
      if ((object) value1 == null && (object) value2 == null) throw new ArgumentException();

      if ((object) value1 == null || (object) value2 == null) throw new ArgumentException();

      return value1.CompareTo(value2) == 1;
    }

    public static bool operator <(Version value1, Version value2)
    {
      if ((object) value1 == null && (object) value2 == null) throw new ArgumentException();

      if ((object) value1 == null || (object) value2 == null) throw new ArgumentException();

      return value1.CompareTo(value2) == -1;
    }

    public static bool operator >=(Version value1, Version value2)
    {
      if ((object) value1 == null && (object) value2 == null) throw new ArgumentException();

      if ((object) value1 == null || (object) value2 == null) throw new ArgumentException();

      var result = value1.CompareTo(value2);

      return result == 0 || result == 1;
    }

    public static bool operator <=(Version value1, Version value2)
    {
      if ((object) value1 == null && (object) value2 == null) throw new ArgumentException();

      if ((object) value1 == null || (object) value2 == null) throw new ArgumentException();

      var result = value1.CompareTo(value2);

      return result == 0 || result == -1;
    }

    public static explicit operator Version(string value)
    {
      return new(value);
    }

    public override string ToString()
    {
      return $"{Major}.{Minor}";
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as Version);
    }

    public override int GetHashCode()
    {
      return Major + Minor;
    }
  }
}