using System;
using System.Collections.Generic;
using System.Text;

class ParseRequest : API_Methods
{
    public static string AuthenticateURL(string YOUR_CLIENT_ID, string YOUR_REGISTERED_REDIRECT_URI)
    {
        return Uri.EscapeUriString("https://api.put.io/v2/oauth2/authenticate" +
            "?client_id=" + YOUR_CLIENT_ID +
            "&response_type=code" +
            "&redirect_uri=" + YOUR_REGISTERED_REDIRECT_URI);
    }

    public static string TokenRequestURL(string YOUR_CLIENT_ID, string YOUR_CLIENT_SECRET, string YOUR_REGISTERED_REDIRECT_URI, string CODE)
    {
        return Uri.EscapeUriString("https://api.put.io/v2/oauth2/access_token" +
            "?client_id=" + YOUR_CLIENT_ID +
            "&client_secret=" + YOUR_CLIENT_SECRET +
            "&grant_type=authorization_code" +
            "&redirect_uri=" + YOUR_REGISTERED_REDIRECT_URI +
            "&code=" + CODE);
    }
}

public class API_Methods
{
    public static class Files
    {
        static int i = 3;

        public static string[] List(string parent_id)
        {
            string[] nfo = new string[i];
            nfo[0] = "GET";
            nfo[1] = "files/list/" + parent_id;
            return nfo;
        }

        public static string[] CreateFolder(string name, string parent_id)
        {
            string[] nfo = new string[i];
            nfo[0] = "POST";
            nfo[1] = "files/create-folder";
            nfo[2] = "name=" + name +
                "&parent_id=" + parent_id;
            return nfo;
        }
    }
}
