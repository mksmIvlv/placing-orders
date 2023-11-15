using Application.Mediatr.Interfaces.Commands;
using MediatR;

namespace Application.MediatR.Features.Models;

public class AddUserCommand : ICommand<Unit>
{
    #region Свойства

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname { get; }

    #endregion

    #region Конструктор

    public AddUserCommand(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }

    #endregion
}