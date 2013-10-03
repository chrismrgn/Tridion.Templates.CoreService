using System;
using System.Configuration;
using System.Net;
using Tridion.Templates.CoreService.Core.Utils;
using Tridion.ContentManager.CoreService.Client;

namespace Tridion.Templates.CoreService.Core
{
    public static class TridionCoreServiceFactory
    {
        public static CoreServiceClient CreateCoreService()
        {
            var endPoint = ConfigurationManager.AppSettings["EndPoint"] ?? "CoreService";
            var credentials = new NetworkCredential(ConfigurationManager.AppSettings["Username"] ?? "DOMAIN\\USERNAME", 
                                                        ConfigurationManager.AppSettings["Password"] ?? "PASSWORD");
            return new CoreServiceSession(endPoint, credentials).CoreServiceClient;
        }

        public static T Get<T>(string id, ReadOptions readOptions = null) where T : class
        {
            object obj = null;
            CreateCoreService().Using(client =>
            {
                try
                {
                    if (readOptions == null) readOptions = new ReadOptions { LoadFlags = LoadFlags.Expanded };
                    obj = client.Read(id, readOptions);
                }
                catch (Exception e)
                {
                }
            });
            return obj as T;
        }

        public static T TryGet<T>(string id, ReadOptions readOptions = null) where T : class
        {
            try
            {
                return string.IsNullOrWhiteSpace(id) ? null : Get<T>(id, readOptions);
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("Invalid URI:")) return null;
                throw;
            }
        }

    }
}
