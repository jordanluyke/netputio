using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading.Tasks;

class netputio
{
    public string AuthURL { get; private set; }
    private string clientID;
    private string regRedirectUri;
    private string clientSecret;
    private string code;
    public string Token { get; private set; }

    public netputio(string YOUR_CLIENT_ID, string YOUR_REGISTERED_REDIRECT_URI, string YOUR_CLIENT_SECRET)
    {
        this.clientID = YOUR_CLIENT_ID;
        this.regRedirectUri = Uri.EscapeUriString(YOUR_REGISTERED_REDIRECT_URI);
        this.clientSecret = YOUR_CLIENT_SECRET;
        this.AuthURL = ParseRequest.AuthenticateURL(clientID, regRedirectUri);
        this.Token = null;
    }

    public Task TokenRequest(string CODE)
    {
        this.code = CODE;
        string request = ParseRequest.TokenRequestURL(clientID, clientSecret, regRedirectUri, code);
        string[] jsonreturn;
        using (WebClient wc = new WebClient()) {
            jsonreturn = wc.DownloadString(request).Split('"');
        }
        if (jsonreturn[1] == "access_token")
            this.Token = jsonreturn[3];
        else
            this.Token = null;
        return null;
    }

    public string Request(string[] mnfo)
    {
        string HtmlResult = "";
        using (WebClient wc = new WebClient()) {
            string URI = "https://api.put.io/v2" + mnfo[1];
            if (mnfo[0] == "GET") {
                HtmlResult = wc.DownloadString(URI + "?oauth_token=" + this.Token);
            } else if (mnfo[0] == "POST") {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                mnfo[2] += "&oauth_token=" + this.Token;
                HtmlResult = wc.UploadString(URI, mnfo[2]);
            } else if (mnfo[0] == "GETRedirect") {
                var request = (HttpWebRequest)WebRequest.Create(URI + "?oauth_token=" + this.Token);
                request.Method = "HEAD";
                request.AllowAutoRedirect = false;
                string location;
                using (var response = request.GetResponse() as HttpWebResponse) {
                    location = response.GetResponseHeader("Location");
                }
                HtmlResult = location;
            }
        }
        return HtmlResult;
    }

}