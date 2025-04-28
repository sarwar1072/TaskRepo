using Autofac;
using TestProjectAuthoAPI.MService;

namespace TestProjectAuthoAPI
{
	public class WebModule:Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			//builder.RegisterType<VocubResponseModel>().AsSelf();
			//builder.RegisterType<CommonResponseModel>().AsSelf();
			builder.RegisterType< EmailService >().As<IEmailService >().InstancePerLifetimeScope();

            base.Load(builder);
		}

	}
}
