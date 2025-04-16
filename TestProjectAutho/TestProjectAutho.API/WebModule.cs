using Autofac;

namespace TestProjectAuthoAPI
{
	public class WebModule:Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			//builder.RegisterType<VocubResponseModel>().AsSelf();
			//builder.RegisterType<CommonResponseModel>().AsSelf();

			base.Load(builder);
		}

	}
}
