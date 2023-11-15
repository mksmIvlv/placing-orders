using Application.Mediatr.Interfaces.Queries;

namespace Application.MediatR.Features.Models;

public class GetFileFromDataBaseQuery : IQuery<byte[]>
{
    #region Свойство

    /// <summary>
    /// Id пользователя
    /// </summary>
    public Guid IdUser { get; }

    #endregion

    #region Конструктор

    public GetFileFromDataBaseQuery(Guid idUser)
    {
        IdUser = idUser;
    }

    #endregion
}