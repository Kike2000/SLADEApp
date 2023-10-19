using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace CongresoSlade.AzFunctions.HttpRequests
{
    public static class OrquestrationFunction
    {
        [FunctionName("OrquestrationFunction")]
        public static async Task<List<string>> RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var outputs = new List<string>();

            // Replace "hello" with the name of your Durable Activity Function.
            outputs.Add(await context.CallActivityAsync<string>(nameof(SayHello), "Tokyo"));

            // returns ["Hello Tokyo!", "Hello Seattle!", "Hello London!"]
            return outputs;
        }

        [FunctionName(nameof(SayHello))]
        public async static Task<string> SayHello([ActivityTrigger] string name, ILogger log)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                // Reemplaza la URL con la dirección de tu API
                string apiUrl = "https://localhost:7047/api/evento/select";

                // Puedes ajustar este objeto según las necesidades de tu solicitud
                var requestContent = new StringContent("Contenido de la solicitud", Encoding.UTF8, "application/json");

                // Realiza la solicitud HTTP POST (o GET, PUT, etc.) a tu endpoint
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                // Maneja la respuesta según tus necesidades
                if (response.IsSuccessStatusCode)
                {
                    // Procesa la respuesta exitosa
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
                else
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }

        }

        [FunctionName("OrquestrationFunction_HttpStart")]
        public static async Task<HttpResponseMessage> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestMessage req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            // Function input comes from the request content.
            string instanceId = await starter.StartNewAsync("OrquestrationFunction", null);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}