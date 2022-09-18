
namespace PLCPublisher.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Devices.Client;

    public interface ICommandHandler
    {
        Task<MethodResponse> Handle(MethodRequest methodRequest);
    }
}