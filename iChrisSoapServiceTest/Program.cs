using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace iChrisSoapServiceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            BasicHttpBinding binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = 1000000; //change this to the max file size allowed to be transferred. 
            EndpointAddress address = new EndpointAddress("http://6b8d3665.ngrok.io/CHRISProd/service/FTRWebService.asmx");

            ServiceReference1.FTRWebServiceSoapClient client = new ServiceReference1.FTRWebServiceSoapClient(binding, address);

            string msg = "GTR%3Acbr%3Dlogon%2CLogonApplication%3Dbreoption%2Cuser%3DFRONTIER%2Cpassword%3DA";
            string[] result = null;
            var taskAwaiter = Task.Run(async () => { result = await client.MessageAsync(msg); }).GetAwaiter();

            taskAwaiter.GetResult();

            Console.WriteLine(result);

        }
    }
}
