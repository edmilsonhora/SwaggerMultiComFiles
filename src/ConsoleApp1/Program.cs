using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            SalvarVarios();

        }


        static void SalvarUm()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("http://localhost:14867/api/v1/");

                var path = "C://GitHub//Capturaar.PNG";

                using (var content = new MultipartFormDataContent())
                {
                    var f = new StreamContent(File.OpenRead(path));
                    f.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
                    content.Add(f, name: "file", fileName: "Capturaar.PNG");
                    var r = httpClient.PostAsync("Produtos/salvarArquivo/", content).Result;
                    r.EnsureSuccessStatusCode();
                }

                Console.WriteLine("Sucesso!");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        static void SalvarVarios()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("http://localhost:14867/api/v1/");

                string[] paths = { "C://GitHub//Capturaar.PNG", "C://GitHub//Capturar1.PNG" };

                using (var content = new MultipartFormDataContent())
                {
                    foreach (var path in paths)
                    {
                        var fileName = Path.GetFileName(path);
                        var f = new StreamContent(File.OpenRead(path));
                        f.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
                        content.Add(f, name: "files", fileName: fileName); 
                    }

                    var r = httpClient.PostAsync("Produtos/salvarArquivos/", content).Result;
                    r.EnsureSuccessStatusCode();
                }


                Console.WriteLine("Sucesso!");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
