// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using RestCT.Shared.Models;


using (var client = new HttpClient())
        {
    //client.BaseAddress = new Uri("http://localhost:44352/api/");
    //HTTP GET
    //client.DefaultRequestHeaders.ConnectionClose = true;
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json; charset=utf-8"));
    //new MediaTypeWithQualityHeaderValue("application/json")
    //client.DefaultRequestHeaders.Add("Content-Type", "application/json; charset=utf-8");
    var responseTask = client.GetAsync("http://localhost:44352/api/categories");
    responseTask.Wait();
    var result = responseTask.Result;

    if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Item[]>();
                readTask.Wait();

                var students = readTask.Result;

                foreach (var student in students)
                {
                    Console.WriteLine(student.Name);
                }
            }
        }
        Console.ReadLine();
