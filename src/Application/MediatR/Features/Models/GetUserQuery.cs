using Application.Mediatr.Interfaces.Queries;
using Domain.Models;

namespace Application.MediatR.Features.Models;

public class GetUserQuery : IQuery<User>
{
    #region Свойство

    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; }

    #endregion

    #region Конструктор

    public GetUserQuery(Guid id)
    {
        Id = id;
    }

    #endregion
}