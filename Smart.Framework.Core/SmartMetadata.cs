namespace Smart.Framework.Core
{
  /// <summary>
  ///   Класс, олицетворяющий объект, содержащий метаданные smart-свойства.
  /// </summary>
  public class SmartMetadata
  {
    /// <summary>
    ///   Конструктор.
    /// </summary>
    /// <param name="defaultValue">Значение smart-свойства по-умолчанию.</param>
    public SmartMetadata(object defaultValue)
    {
      DefaultValue = defaultValue;
    }

    /// <summary>
    ///   Конструктор.
    /// </summary>
    /// <param name="defaultValue">Значение smart-свойства по-умолчанию.</param>
    /// <param name="propertyChangedCallback">Метод обратного вызова при изменении значения свойства.</param>
    public SmartMetadata(object defaultValue, SmartPropertyChangedCallback propertyChangedCallback)
    {
      DefaultValue = defaultValue;
      PropertyChangedCallback = propertyChangedCallback;
    }

    /// <summary>
    ///   Конструктор.
    /// </summary>
    /// <param name="propertyChangedCallback">Метод обратного вызова при изменении значения свойства.</param>
    public SmartMetadata(SmartPropertyChangedCallback propertyChangedCallback)
    {
      PropertyChangedCallback = propertyChangedCallback;
    }

    /// <summary>
    ///   Конструктор.
    /// </summary>
    /// <param name="defaultValue">Значение smart-свойства по-умолчанию.</param>
    /// <param name="isReadobly">Флаг того, что smart-свойство только для чтения.</param>
    internal SmartMetadata(object defaultValue, bool isReadobly)
    {
      DefaultValue = defaultValue;
      IsReadonly = isReadobly;
    }

    /// <summary>
    ///   Конструктор.
    /// </summary>
    /// <param name="defaultValue">Значение smart-свойства по-умолчанию.</param>
    /// <param name="isReadobly">Флаг того, что smart-свойство только для чтения.</param>
    /// <param name="propertyChangedCallback">Метод обратного вызова при изменении значения свойства.</param>
    internal SmartMetadata(object defaultValue, bool isReadobly, SmartPropertyChangedCallback propertyChangedCallback)
    {
      DefaultValue = defaultValue;
      IsReadonly = isReadobly;
      PropertyChangedCallback = propertyChangedCallback;
    }

    /// <summary>
    ///   Возвратить значение smart-свойства по-умолчанию.
    /// </summary>
    public object DefaultValue { get; }

    /// <summary>
    ///   Возвратить флаг того, что smart-свойство только для чтения.
    /// </summary>
    public bool IsReadonly { get; }

    /// <summary>
    ///   Возвратить метод обратного вызова при изменении значения свойства.
    /// </summary>
    internal SmartPropertyChangedCallback PropertyChangedCallback { get; }
  }
}