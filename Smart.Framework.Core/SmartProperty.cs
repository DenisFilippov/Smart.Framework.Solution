using System;

namespace Smart.Framework.Core
{
  /// <summary>
  ///   Класс, олицетворяющий smart-свойство.
  /// </summary>
  public sealed class SmartProperty
  {
    /// <summary>
    ///   Возвратить метаданные smart-свойства.
    /// </summary>
    public SmartMetadata Metadata { get; private set; }

    /// <summary>
    ///   Возвратить название smart-свойства.
    /// </summary>
    public string PropertyName { get; private set; }

    /// <summary>
    ///   Возвратить возвращаемый тип smart-свойства.
    /// </summary>
    public Type PropertyType { get; private set; }

    /// <summary>
    ///   Возвратить объект, которому принадлежит smart-свойство.
    /// </summary>
    public Type OwnerType { get; private set; }

    /// <summary>
    ///   Возвратить метод обратного вызова для проверки присваиваемого значения smart-свойства.
    /// </summary>
    public SmartPropertyCheckValueCallback CheckValueCallback { get; private set; }

    /// <summary>
    ///   Регистрация smart-свойства.
    /// </summary>
    /// <param name="propertyName">Название smart-свойства.</param>
    /// <param name="propertyType">Возвращиемый тип smart-свойства.</param>
    /// <param name="ownerType">Объект, которому принадлежит smart-свойство.</param>
    /// <returns>smart-свойство.</returns>
    public static SmartProperty Register(string propertyName, Type propertyType, Type ownerType)
    {
      var result = new SmartProperty
      {
        PropertyName = propertyName,
        PropertyType = propertyType,
        OwnerType = ownerType,
        Metadata = null
      };

      return result;
    }

    /// <summary>
    ///   Регистрация smart-свойства.
    /// </summary>
    /// <param name="propertyName">Название smart-свойства.</param>
    /// <param name="propertyType">Возвращиемый тип smart-свойства.</param>
    /// <param name="ownerType">Объект, которому принадлежит smart-свойство.</param>
    /// <param name="metadata">Метаданные smart-свойства.</param>
    /// <returns>smart-свойство.</returns>
    public static SmartProperty Register(string propertyName, Type propertyType, Type ownerType, SmartMetadata metadata)
    {
      var result = new SmartProperty
      {
        PropertyName = propertyName,
        PropertyType = propertyType,
        OwnerType = ownerType,
        Metadata = metadata
      };

      return result;
    }

    /// <summary>
    ///   Регистрация smart-свойства.
    /// </summary>
    /// <param name="propertyName">Название smart-свойства.</param>
    /// <param name="propertyType">Возвращиемый тип smart-свойства.</param>
    /// <param name="ownerType">Объект, которому принадлежит smart-свойство.</param>
    /// <param name="metadata">Метаданные smart-свойства.</param>
    /// <param name="checkValueCallback">Метод обратного вызова для проверки присваиваемого значения smart-свойства.</param>
    /// <returns>smart-свойство.</returns>
    public static SmartProperty Register(string propertyName, Type propertyType, Type ownerType,
      SmartMetadata metadata, SmartPropertyCheckValueCallback checkValueCallback)
    {
      var result = new SmartProperty
      {
        PropertyName = propertyName,
        PropertyType = propertyType,
        OwnerType = ownerType,
        Metadata = metadata,
        CheckValueCallback = checkValueCallback
      };

      return result;
    }

    /// <summary>
    ///   Регистрация smart-свойства "только для чтения".
    /// </summary>
    /// <param name="propertyName">Название smart-свойства.</param>
    /// <param name="propertyType">Возвращиемый тип smart-свойства.</param>
    /// <param name="ownerType">Объект, которому принадлежит smart-свойство.</param>
    /// <param name="defaultValue">Значение smart-свойства по-умолчанию.</param>
    /// <returns>smart-свойство.</returns>
    public static SmartPropertyKey RegisterReadonly(string propertyName, Type propertyType, Type ownerType,
      object defaultValue)
    {
      var key = new SmartProperty
      {
        PropertyName = propertyName,
        PropertyType = propertyType,
        OwnerType = ownerType,
        Metadata = new SmartMetadata(defaultValue, true)
      };

      return new SmartPropertyKey(key);
    }

    /// <summary>
    ///   Регистрация smart-свойства "только для чтения".
    /// </summary>
    /// <param name="propertyName">Название smart-свойства.</param>
    /// <param name="propertyType">Возвращиемый тип smart-свойства.</param>
    /// <param name="ownerType">Объект, которому принадлежит smart-свойство.</param>
    /// <param name="defaultValue">Значение smart-свойства по-умолчанию.</param>
    /// <param name="checkValueCallback">Метод обратного вызова для проверки присваиваемого значения smart-свойства.</param>
    /// <returns>smart-свойство.</returns>
    public static SmartPropertyKey RegisterReadonly(string propertyName, Type propertyType,
      Type ownerType, object defaultValue, SmartPropertyCheckValueCallback checkValueCallback)
    {
      var key = new SmartProperty
      {
        PropertyName = propertyName,
        PropertyType = propertyType,
        OwnerType = ownerType,
        Metadata = new SmartMetadata(defaultValue, true),
        CheckValueCallback = checkValueCallback
      };

      return new SmartPropertyKey(key);
    }

    public override int GetHashCode()
    {
      return PropertyName.GetHashCode() ^ OwnerType.GetHashCode();
    }
  }
}