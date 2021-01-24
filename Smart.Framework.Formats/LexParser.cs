using System;
using System.IO;
using System.Text;

namespace Smart.Framework.Formats
{
  /// <summary>
  ///   Класс лексического парсера общего назначения.
  /// </summary>
  public class LexParser
  {
    private readonly string[] _termStrings;

    private StreamReader _reader;

    /// <summary>
    ///   Конструктор.
    /// </summary>
    /// <param name="termStrings">Массив разделителей лексем.</param>
    private LexParser(params string[] termStrings)
    {
      if (termStrings != null && termStrings.Length != 0)
      {
        _termStrings = new string[termStrings.Length];
        var index = 0;
        foreach (var term in termStrings) _termStrings[index++] = term;
      }
      else
      {
        _termStrings = new string[3];
        _termStrings[0] = " ";
        _termStrings[1] = "\n";
        _termStrings[2] = "\r";
      }
    }

    /// <summary>
    ///   Возвратить терминальную строку.
    /// </summary>
    public string TermString { get; private set; }

    /// <summary>
    ///   Возвратить лексему.
    /// </summary>
    public string LexString { get; private set; }

    /// <summary>
    ///   Создать экземпляр объекта LexParser.
    /// </summary>
    /// <param name="stream">Поток, содержащий данные для разбора.</param>
    /// <param name="encoding">Кодировка потока (если null, то UTF8).</param>
    /// <param name="termStrings">Массив разделителей лексем.</param>
    /// <returns>Экземпляр объекта LexParser.</returns>
    /// <exception cref="ArgumentNullException" />
    /// <exception cref="InvalidOperationException" />
    public static LexParser Create(Stream stream, Encoding encoding = null, params string[] termStrings)
    {
      if (stream == null) throw new ArgumentNullException(nameof(stream));

      if (!stream.CanRead) throw new InvalidOperationException();

      var result = new LexParser(termStrings);
      result._reader = new StreamReader(stream, encoding != null ? encoding : Encoding.UTF8);
      return result;
    }

    private (bool, string) containsTerm(string value)
    {
      foreach (var term in _termStrings)
        if (value.Contains(term))
          return (true, term);

      return (false, string.Empty);
    }

    private string selectLexString(string lexValue, string term)
    {
      return lexValue.Substring(0, lexValue.IndexOf(term));
    }

    /// <summary>
    ///   Прочитать лексему из потока.
    /// </summary>
    /// <returns>= true, если лексема прочитана, = false, если конец потока чтения.</returns>
    public bool Read()
    {
      var accumulator = new StringBuilder();
      int c;
      while ((c = _reader.Read()) != -1)
      {
        accumulator.Append((char) c);
        var value = accumulator.ToString();
        var (result, termString) = containsTerm(value);
        if (result)
        {
          LexString = selectLexString(value, termString);
          TermString = termString;
          return true;
        }
      }

      return false;
    }
  }
}