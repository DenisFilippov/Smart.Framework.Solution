using System;

namespace Smart.Framework.Core
{
  /// <summary>
  ///   Класс, олицетворяющий ключ для записи в smart-свойство.
  /// </summary>
  public sealed class SmartPropertyKey
  {
    /// <summary>
    ///   Конструктор.
    /// </summary>
    /// <param name="property">smart-свойство.</param>
    internal SmartPropertyKey(SmartProperty property)
    {
      Property = property ?? throw new ArgumentNullException(nameof(property));
    }

    /// <summary>
    ///   Возвратить smart-свойство.
    /// </summary>
    public SmartProperty Property { get; }
  }
}