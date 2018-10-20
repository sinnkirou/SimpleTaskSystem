using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace SimpleTaskSystem
{
    [DependsOn(
        typeof(SimpleTaskSystemCoreModule),
         typeof(AbpAutoMapperModule))]
    public class SimpleTaskSystemApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
