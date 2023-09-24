using System.Text.RegularExpressions;

namespace Application.Validations;

/// <summary>
/// Класс для проверки введенных данных на корректность
/// </summary>
public static class HelperMethods
{
    /// <summary>
    /// Проверка ФИО на корректность
    /// </summary>
    /// <param name="data">Строка для проверки</param>
    /// <returns>True - строка корректна, иначе false</returns>
    public static bool IsValidFullName(string data)
    {
        string pattern = "^([А-Я]{1}[а-яё]{1,15}|[A-Z]{1}[a-z]{1,15})$";
        Regex regex = new Regex(pattern);

        return regex.IsMatch(data);
    }
    
    /// <summary>
    /// Проверка цены товара на корректность
    /// </summary>
    /// <param name="price">Цена</param>
    /// <returns>True - цена корректна, иначе false</returns>
    public static bool IsValidPrice(decimal price)
    {
        string pattern = "^(\\d*(\\.|\\,|\\d)*)$";
        Regex regex = new Regex(pattern);

        return regex.IsMatch(price.ToString());
    }
}