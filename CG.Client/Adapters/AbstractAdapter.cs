using ServiceStack;

namespace CG.Client.Adapters
{
    public abstract class AbstractAdapter
    {
        public string HostUri { protected set; get; }
        public IServiceClient Client { protected set; get; }
    }
}
