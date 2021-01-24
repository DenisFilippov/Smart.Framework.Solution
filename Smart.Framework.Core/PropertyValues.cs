using System.Collections;
using System.Runtime.CompilerServices;

namespace Smart.Framework.Core
{
  /// <summary>
  ///   Класс, олицетворяющий глобальное хранилище значений smart-свойств.
  /// </summary>
  internal static class PropertyValues
  {
    private static readonly Hashtable _global = new();

    private static int getKey(SmartObject obj, SmartProperty property)
    {
      return property.GetHashCode() ^ obj.GetHashCode();
    }

    /// <summary>
    ///   Возвратить значение smart-свойства.
    /// </summary>
    /// <param name="obj">Объект, которому принадлежит smart-свойство.</param>
    /// <param name="property">smart-свойство.</param>
    /// <returns>Значение smart-свойства.</returns>
    /// <exception cref="SmartPropertyException" />
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static object GetValue(SmartObject obj, SmartProperty property)
    {
      var key = getKey(obj, property);
      var contains = _global.ContainsKey(key);
      if (!contains && property.Metadata == null) throw new SmartPropertyException();
      return contains ? _global[key] : property.Metadata.DefaultValue;
    }

    /// <summary>
    ///   Установить значение smart-свойства.
    /// </summary>
    /// <param name="obj">Объект, которому принадлежит smart-свойство.</param>
    /// <param name="property">smart-свойство.</param>
    /// <param name="value">Значение smart-свойства.</param>
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void SetValue(SmartObject obj, SmartProperty property, object value)
    {
      if (property.CheckValueCallback != null && !property.CheckValueCallback(obj, value)) return;
      var key = getKey(obj, property);
      if (property.Metadata != null && property.Metadata.PropertyChangedCallback != null)
      {
        var oldValue = _global.ContainsKey(key) ? _global[key] :
          property.Metadata.DefaultValue != null ? property.Metadata.DefaultValue : null;
        property.Metadata.PropertyChangedCallback?.Invoke(obj, oldValue, value);
      }

      _global[key] = value;
    }

    /// <summary>
    ///   Удалить значение smart-свойства из глобальной таблицы значений свойств.
    /// </summary>
    /// <param name="obj">Объект, которому принадлежит smart-свойство.</param>
    /// <param name="property">smart-свойство.</param>
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void ResetValue(SmartObject obj, SmartProperty property)
    {
      var key = getKey(obj, property);
      if (!_global.ContainsKey(key)) return;
      _global.Remove(key);
    }
  }
}