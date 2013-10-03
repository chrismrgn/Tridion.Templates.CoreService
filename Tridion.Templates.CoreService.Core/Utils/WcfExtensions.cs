using System;
using System.ServiceModel;

namespace Tridion.Templates.CoreService.Core.Utils
{
    public static class WcfExtensions
    {
        public static void Using<T>(this T client, Action<T> work)
            where T : ICommunicationObject
        {
            try
            {
                work(client);
                client.Close();
            }
            catch
            {
                client.Abort();
                throw;
            }
        }
    }
}
