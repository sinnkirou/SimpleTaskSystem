using Shouldly;
using SimpleTaskSystem.Persons;
using System.Threading.Tasks;
using Xunit;

namespace SimpleTaskSystem.Test.Persons
{
    public class PersonAppService_Tests : SimpleTaskSystemTestBase
    {
        private readonly IPersonAppService _personAppService;

        public PersonAppService_Tests()
        {
            _personAppService = LocalIocManager.Resolve<IPersonAppService>();
        }

        [Fact]
        public async Task Should_Get_All_People()
        {
            var output = await _personAppService.GetAllPeople();
            output.People.Count.ShouldBe(4);
        }
    }
}
