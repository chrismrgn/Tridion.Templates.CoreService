using System;
using Tridion.ContentManager.CoreService.Client;
using Tridion.Templates.CoreService.Core;

namespace Tridion.Templates.CoreService.Consumer
{
    public class TestConsumer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Core Service Consumer Test");
            var item = TridionCoreServiceFactory.TryGet<IdentifiableObjectData>("TCM_ID");
            Console.WriteLine(string.Format("Title: {0}", item.Title));

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        
    }
}
