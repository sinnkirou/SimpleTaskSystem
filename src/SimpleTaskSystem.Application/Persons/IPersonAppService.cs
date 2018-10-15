using System.Threading.Tasks;
using Abp.Application.Services;
using SimpleTaskSystem.Persons.Dtos;

namespace SimpleTaskSystem.Persons
{
    public interface IPersonAppService : IApplicationService
    {
        Task<GetAllPeopleOutput> GetAllPeople();
    }
}