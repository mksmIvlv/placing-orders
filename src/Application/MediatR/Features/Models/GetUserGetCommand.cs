using Application.Mediatr.Interfaces.Commands;
using Domain.Models;

namespace Application.MediatR.Features.Models;

public class GetUserGetCommand : ICommand<User>
{
    #region Свойство

    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; }

    #endregion

    #region Конструктор

    public GetUserGetCommand(Guid id)
    {
        Id = id;
    }

    #endregion
}