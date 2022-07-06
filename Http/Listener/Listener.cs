using System.Net;

namespace Listener
{
    public static class Listener 
    {
        public static void Run(string[] prefixes)
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }

            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");

            HttpListener listener = new();

            foreach (string s in prefixes)
            {
                listener.Prefixes.Add(s);
            }
            try
            {
                listener.Start();

                Console.WriteLine("Listening...");

                while (listener.IsListening)
                {
                    var context = listener.GetContext(); 

                    HandleRequest(context);             
                }             
            }
            catch(Exception e)
            {
                listener.Stop();
                throw;
            }          
        }

        public static void HandleRequest(HttpListenerContext context)
        {
            var request = context.Request;

            var response = context.Response;
            switch (request.RawUrl)
            {
                case "/MyName":
                    Console.WriteLine("Write your name");
                    var name = Console.ReadLine();
                    response.StatusCode = 200;
                    CreateResponse(response, name);
                    break;
                case "/Information":
                    response.StatusCode = 101;
                    CreateResponse(response, "Information called");
                    break;
                case "/Success":
                    response.StatusCode = 200;
                    CreateResponse(response, "Success called");
                    break;
                case "/Redirection":
                    response.StatusCode = 300;
                    CreateResponse(response, "Redirection called");
                    break;
                case "/ClientError":
                    response.StatusCode = 404;
                    CreateResponse(response, "ClientError called");
                    break;
                case "/ServerError":
                    response.StatusCode = 500;
                    CreateResponse(response, "ServerError called");
                    break;
                case "/MyNameByHeader":
                    GetMyNameByHeader(response);
                    break;
                case "/MyNameByCookies":
                    MyNameByCookies(response);
                    break;
            }

            context.Response.Close();
        }

        public static void CreateResponse(HttpListenerResponse listenerResponse, string body)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(body);
            listenerResponse.ContentLength64 = buffer.Length;
            var output = listenerResponse.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }

        public static void GetMyNameByHeader(HttpListenerResponse listenerResponse)
        {
            listenerResponse.StatusCode = 200;
            var header = "X-MyName";
            Console.WriteLine("Write your name");
            var name = Console.ReadLine(); 
            listenerResponse.Headers.Add(header, name);
        }

        public static void MyNameByCookies(HttpListenerResponse listenerResponse)
        {
            listenerResponse.StatusCode = 200;
            var key = "MyName";
            Console.WriteLine("Write your name");
            var name = Console.ReadLine();
            listenerResponse.Cookies.Add(new Cookie(key, name));
        }
    }
}
