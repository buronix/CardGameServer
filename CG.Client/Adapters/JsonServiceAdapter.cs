using ServiceStack;

namespace CG.Client.Adapters
{
    public class JsonServiceAdapter : AbstractAdapter
    {
        public JsonServiceAdapter(string hostUri)
        {
            HostUri = hostUri;
            Client = new CachedServiceClient(new JsonServiceClient(HostUri));
        }
    }
}
