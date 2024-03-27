namespace ParsingTest;

public class GetRequest
{
    public GetRequest(string requestUri)
    {
        RequestUri = requestUri;
        GetRequestHtml();
    }

    private string RequestUri { get; set; } = null!;
    public string Input { get; set; } = string.Empty;

    private void GetRequestHtml()
    {
        using HttpClient client = new() { Timeout = TimeSpan.FromSeconds(60) };
        using HttpResponseMessage httpResponseMessage = client.GetAsync(RequestUri).Result;
        using HttpContent httpContent = httpResponseMessage.Content;
        Input = httpContent.ReadAsStringAsync().Result;
    }
}