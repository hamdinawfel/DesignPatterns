using Autofac;
using DesignPatterns.CharpTopics._5_DefaultInterfaceMembers;
using DesignPatterns.Utils;
using JetBrains.Annotations;
using MediatR;

namespace DesignPatterns.Mediator
{

    public class MediatRDemo : IDisplayDemo
    {
        public class PongResponse
        {
            public DateTime Timestamp;

            public PongResponse(DateTime timestamp)
            {
                Timestamp = timestamp;
            }
        }

        public class PingCommand : IRequest<PongResponse>
        {
        }

        [UsedImplicitly]
        public class PingCommandHandler : IRequestHandler<PingCommand, PongResponse>
        {
            public async Task<PongResponse> Handle(PingCommand request, CancellationToken cancellationToken)
            {
                return await Task.FromResult(new PongResponse(DateTime.UtcNow))
                  .ConfigureAwait(false);
            }
        }

        public async void DisplayResult()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MediatR.Mediator>()
              .As<IMediator>()
              .InstancePerLifetimeScope(); // singleton

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.RegisterAssemblyTypes(typeof(MediatRDemo).Assembly)
              .AsImplementedInterfaces();

            // FIX THIS EXCEPTION : Autofac.Core.Activators.Reflection.NoConstructorsFoundException:
            // 'No accessible constructors were found for the type 'DesignPatterns.Singleton.SingletonDatabase'.'

            var container = builder.Build();
            var mediator = container.Resolve<IMediator>();
            var response =  await mediator.Send(new PingCommand());
            Console.WriteLine($"We got a pong at {response.Timestamp}");
        }
    }
}
