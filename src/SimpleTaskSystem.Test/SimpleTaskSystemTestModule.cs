using Abp.Modules;
using Abp.TestBase;

namespace SimpleTaskSystem.Test
{
    [DependsOn(
        typeof(SimpleTaskSystemDataModule),
        typeof(SimpleTaskSystemApplicationModule),
        typeof(AbpTestBaseModule)
    )]
    public class SimpleTaskSystemTestModule : AbpModule
    {

    }
}
