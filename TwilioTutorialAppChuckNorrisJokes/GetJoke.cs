using System.Xml;

namespace TwilioTutorialAppChuckNorrisJokes
{
    public static class GetJoke
    {
        [FunctionName("GetJoke")]

        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", 
            Route = null)] HttpRequest req/*, ILogger log*/) {


            var norrisJoke = await ChuckNorrisJokeHelper.GetJokeAsync();

            var responseMessage = new MessagingResponse().Message(norrisJoke);

            var twiml = responseMessage.ToString();

            //return ContentResult {

            //    //Content = twiml;
            //    Content = twiml,
            //    ContentType = "application/xml"

            //};



            /* --> */   return new OkObjectResult(twiml);

            //return new OkObjectResult(twiml as Xml);







            //public static async Task<IActionResult> Run(
            //    [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            //    ILogger log)
            //{
            //    log.LogInformation("C# HTTP trigger function processed a request.");

            //    string name = req.Query["name"];

            //    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //    dynamic data = JsonConvert.DeserializeObject(requestBody);
            //    name = name ?? data?.name;

            //    string responseMessage = string.IsNullOrEmpty(name)
            //        ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            //        : $"Hello, {name}. This HTTP triggered function executed successfully.";

            //    return new OkObjectResult(responseMessage);
            //}

        }

    }

}
