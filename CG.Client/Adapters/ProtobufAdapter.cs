using ServiceStack;
using ServiceStack.ProtoBuf;

namespace CG.Client.Adapters
{
    public class ProtobufAdapter : AbstractAdapter
    {
        public ProtobufAdapter(string hostUri)
        {
            HostUri = hostUri;
            Client = new CachedServiceClient(new ProtoBufServiceClient(HostUri));
        }
    }
}
