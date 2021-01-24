namespace Smart.Framework.Core
{
  /// <summary>
  ///   Класс, олицетворяющий базовый объект для использования smart-свойств.
  /// </summary>
  public class SmartObject
  {
    /// <summary>
    ///   Возвратить значение smart-свойства.
    /// </summary>
    /// <param name="property">smart-свойство.</param>
    /// <returns>Значение smart-свойства.</returns>
    /// <exception cref="SmartPropertyException" />
    public object GetValue(SmartProperty property)
    {
      return PropertyValues.GetValue(this, property);
    }

    /// <summary>
    ///   Установить значение smart-свойства.
    /// </summary>
    /// <param name="property">smart-свойство.</param>
    /// <param name="value">Значение smart-свойства.</param>
    public void SetValue(SmartProperty property, object value)
    {
      PropertyValues.SetValue(this, property, value);
    }

    /// <summary>
    ///   Удалить значение smart-свойства из глобальной таблицы значений свойств.
    /// </summary>
    /// <param name="property">smart-свойство.</param>
    public void ResetValue(SmartProperty property)
    {
      PropertyValues.ResetValue(this, property);
    }

    /// <summary>
    ///   Установить значение smart-свойства.
    /// </summary>
    /// <param name="key">Ключ для записи smart-свойства.</param>
    /// <param name="value">Значение smart-свойства.</param>
    public void SetValue(SmartPropertyKey key, object value)
    {
      PropertyValues.SetValue(this, key.Property, value);
    }

    public sealed override int GetHashCode()
    {
      return -434485196 ^ base.GetHashCode();
    }
  }
}