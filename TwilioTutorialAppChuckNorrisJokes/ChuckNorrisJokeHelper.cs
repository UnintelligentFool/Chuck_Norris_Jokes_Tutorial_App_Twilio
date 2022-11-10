namespace TwilioTutorialAppChuckNorrisJokes {
    /*internal */class ChuckNorrisJokeHelper {

        public static async Task<string> GetJokeAsync() {

            var theJoke = "Error! Something went wrong when we asked Chuck Norris to provide us with a joke!";

            using (var httpClient = new HttpClient()) {

                var apiEndPoint = "https://api.chucknorris.io/jokes/random";
                httpClient.BaseAddress = new Uri(apiEndPoint);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync(apiEndPoint);

                if (response.StatusCode == HttpStatusCode.OK) {
                    
                    var jsonContent = await response.Content.ReadAsStringAsync();

                    dynamic data = JsonConvert.DeserializeObject<dynamic>(jsonContent);

                    theJoke = data.value;

                }
            
            }

            return theJoke;
        
        }

    }
}
