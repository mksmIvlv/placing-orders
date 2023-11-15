using Application.Mediatr.Interfaces.Commands;
using MediatR;

namespace Application.MediatR.Features.Models;

public class DeleteUserCommand : ICommand<Unit>
{
    #region Свойство

    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; }

    #endregion

    #region Конструктор

    public DeleteUserCommand(Guid id)
    {
        Id = id;
    }

    #endregion
}