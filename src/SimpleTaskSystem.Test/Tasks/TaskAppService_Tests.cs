using Shouldly;
using SimpleTaskSystem.Persons;
using SimpleTaskSystem.Tasks;
using SimpleTaskSystem.Tasks.Dtos;
using System.Linq;
using Xunit;

namespace SimpleTaskSystem.Test.Tasks
{
    public class TaskAppService_Tests : SimpleTaskSystemTestBase
    {
        private readonly ITaskAppService _taskAppService;

        public TaskAppService_Tests()
        {
            //Creating the class which is tested (SUT - Software Under Test)
            _taskAppService = LocalIocManager.Resolve<ITaskAppService>();
        }

        [Fact]
        public void Should_Create_New_Tasks()
        {
            //Prepare for test
            var initialTaskCount = UsingDbContext(context => context.Tasks.Count());
            var thomasMore = GetPerson("Thomas More");

            //Run SUT
            _taskAppService.CreateTask(
                new CreateTaskInput
                {
                    Description = "my test task 1"
                });
            _taskAppService.CreateTask(
                new CreateTaskInput
                {
                    Description = "my test task 2",
                    AssignedPersonId = thomasMore.Id
                });

            //Check results
            UsingDbContext(context =>
            {
                context.Tasks.Count().ShouldBe(initialTaskCount + 2);
                context.Tasks.FirstOrDefault(t => t.AssignedPersonId == null && t.Description == "my test task 1").ShouldNotBe(null);
                var task2 = context.Tasks.FirstOrDefault(t => t.Description == "my test task 2");
                task2.ShouldNotBe(null);
                task2.AssignedPersonId.ShouldBe(thomasMore.Id);
            });
        }

        private Person GetPerson(string name)
        {
            return UsingDbContext(context => context.People.Single(p => p.Name == name));
        }
    }
}
