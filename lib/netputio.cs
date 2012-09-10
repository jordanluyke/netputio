using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
//using System.Web;
//using System.Threading;
using System.Threading.Tasks;

class netputio
{
    public string AuthURL { get; private set; }
    private string clientID;
    private string regRedirectUri;
    private string clientSecret;
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
        string request = ParseRequest.TokenRequestURL(clientID, clientSecret, regRedirectUri, CODE);
        WebClient wc = new WebClient();
        string[] jsonreturn = wc.DownloadString(request).Split('"');
        wc.Dispose();
        if (jsonreturn[1] == "access_token")
            this.Token = jsonreturn[3];
        else
            this.Token = null;
        return null;
    }

    /*public void Request(string[] method)
    {
        HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create("https://api.put.io/v2/" + method[0]);

        UTF8Encoding encoding = new UTF8Encoding();

        byte[] data = encoding.GetBytes(method[1] + "&oauth_token=" + this.Token);

        httpWReq.Method = "POST";
        httpWReq.ContentType = "application/x-www-form-urlencoded";
        httpWReq.ContentLength = data.Length;

        using (Stream newStream = httpWReq.GetRequestStream()) {
            newStream.Write(data, 0, data.Length);
        }
    }*/

    public string Request(string[] mnfo)
    {
        string HtmlResult = "";
        using (WebClient wc = new WebClient()) {
            string URI = "https://api.put.io/v2/" + mnfo[1];
            if (mnfo[0] == "GET") {
                HtmlResult = wc.DownloadString(URI + "?oauth_token=" + this.Token);
                //HtmlResult = wc.DownloadString("https://api.put.io/v2/files/list?oauth_token=" + this.Token);
            } else if (mnfo[0] == "POST") {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                mnfo[2] += "&oauth_token=" + this.Token;
                HtmlResult = wc.UploadString(URI, mnfo[2]);
            }
        }
        return HtmlResult;
    }


}