using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Web;

class netputio
{
    //public string authRedirect = Uri.EscapeUriString("https://api.put.io/v2/oauth2/authenticate?client_id=175&response_type=code&redirect_uri=https://twitter.com/ethernex");
    /// <summary>
    /// Redirects to https://YOUR_REGISTERED_REDIRECT_URI/?code=CODE. Used to obtain CODE.
    /// </summary>
    public string AuthURL { get; private set; }
    private string clientID;
    private string regRedirectUri;
    private string clientSecret;
    public string Token { get; private set; }

    /// <summary>
    /// Forms authRedirect URL for client login page.
    /// </summary>
    public netputio(string YOUR_CLIENT_ID, string YOUR_REGISTERED_REDIRECT_URI, string YOUR_CLIENT_SECRET)
    {
        this.clientID = YOUR_CLIENT_ID;
        this.regRedirectUri = Uri.EscapeUriString(YOUR_REGISTERED_REDIRECT_URI);
        this.clientSecret = YOUR_CLIENT_SECRET;
        this.AuthURL = Uri.EscapeUriString("https://api.put.io/v2/oauth2/authenticate" +
            "?client_id=" + clientID +
            "&response_type=code" +
            "&redirect_uri=" + regRedirectUri);
        this.Token = null;
    }

    /// <summary>
    /// Sets public Token variable.
    /// </summary>
    /// <param name="CODE"></param>
    public void TokenRequest(string CODE)
    {
        string request = Uri.EscapeUriString("https://api.put.io/v2/oauth2/access_token" +
            "?client_id=" + clientID +
            "&client_secret=" + clientSecret +
            "&grant_type=authorization_code" +
            "&redirect_uri=" + regRedirectUri +
            "&code=" + CODE);
        WebClient wc = new WebClient();
        string[] jsonreturn = wc.DownloadString(request).Split('"');
        if (jsonreturn[1] == "access_token")
            this.Token = jsonreturn[3];
        else
            this.Token = null;
    }

    private string jsonParseSend(string param, string value)
    {
        string s =  "{" +
                        "\"api_key\":\"" + " " + "\"," +
                        "\"api_secret\":\"" + " " + "\"," +
                        "\"params\":{" +
                        parseparamvalue(param, value) + "," +
                        parseparamvalue(param, value) +
                        "}" +
                    "}";
        return s;
    }

    private string parseparamvalue(string param, string value)
    {
        return "\"" + param + "\":\"" + value + "\"";
    }

}

