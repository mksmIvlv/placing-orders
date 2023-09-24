using Application.Mediatr.Interfaces.Commands;
using MediatR;

namespace Application.MediatR.Features.Models;

public class DeleteUserDeleteCommand : ICommand<Unit>
{
    #region Свойство

    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; }

    #endregion

    #region Конструктор

    public DeleteUserDeleteCommand(Guid id)
    {
        Id = id;
    }

    #endregion
}