namespace Smart.Framework.Core
{
  /// <summary>
  ///   Делегат, используемый для метода обратного вызова для проверки присваиваемого значения smart-свойства.
  /// </summary>
  /// <param name="sender">Объект-владелец smart-свойства.</param>
  /// <param name="value">Новое значение smart-свойства.</param>
  /// <returns>Флаг, указывающий на валидность нового значения свойства.</returns>
  public delegate bool SmartPropertyCheckValueCallback(SmartObject sender, object value);
}