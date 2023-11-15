using System.Text;
using Application.Interface;
using Application.MediatR.Features.Models;
using Application.Mediatr.Interfaces.Queries;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Application.MediatR.Features.Queries;

public class GetFileFromDataBaseHandler : IQueryHandler<GetFileFromDataBaseQuery, byte[]>
{
    #region Поле

    /// <summary>
    /// Доступ к репозиторию
    /// </summary>
    private readonly IRepository _repository;

    #endregion

    #region Конструктор

    public GetFileFromDataBaseHandler(IRepository repository)
    {
        _repository = repository;
    }

    #endregion
    
    #region Метод

    /// <summary>
    /// Получение файла с данными из бд
    /// </summary>
    /// <param name="query">Запрос</param>
    /// <param name="cancellationToken">Токен</param>
    /// <returns>Массив байтов</returns>
    public async Task<byte[]> Handle(GetFileFromDataBaseQuery query, CancellationToken cancellationToken)
    {
        var user = await _repository.GetUserAsync(query.IdUser);

        var jsonUser = JsonConvert.SerializeObject(user, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            });

        return Encoding.UTF8.GetBytes(jsonUser);
    }

    #endregion
}