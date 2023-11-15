using Application.Mediatr.Interfaces.Commands;
using MediatR;

namespace Application.MediatR.Features.Models;

public class EditUserCommand : ICommand<Unit>
{
    #region Свойства

    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; }
    
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

    public EditUserCommand(Guid id, string name, string surname)
    {
        Id = id;
        Name = name;
        Surname = surname;
    }

    #endregion
}