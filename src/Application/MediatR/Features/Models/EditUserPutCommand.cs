using Application.Mediatr.Interfaces.Commands;
using MediatR;

namespace Application.MediatR.Features.Models;

public class EditUserPutCommand : ICommand<Unit>
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

    public EditUserPutCommand(Guid id, string name, string surname)
    {
        Id = id;
        Name = name;
        Surname = surname;
    }

    #endregion
}