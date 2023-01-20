using System.Net;
using Newtonsoft.Json;

private void RunScript(bool send, string api_Key, string prompt, ref object Answer)
  {
  // Set the endpoint URL and the prompt text
  string url = "https://api.openai.com/v1/completions";

  // Set the API key and other parameters
  var data = JsonConvert.SerializeObject(new { model = "text-davinci-003", prompt = prompt, temperature = 0.5, max_tokens = 1024 });
  var headers = new WebHeaderCollection();
  headers["Content-Type"] = "application/json";
  headers["Authorization"] = "Bearer " + api_Key;

  string answer = "Send to prompt to Open AI";

  if (send)
  {
  // Make the request
  using (var client = new WebClient())
  {
  client.Headers = headers;
  var response = client.UploadString(url, data);

  // Parse the response
  var response_json = JsonConvert.DeserializeObject<dynamic>(response);

  // Read the answer
  answer = response_json.choices[0].text;
  }
  }
  Answer = answer;
  }
