using System;
using System.Collections.Generic;
using System.Text;

class ParseRequest : API_Methods
{
    public static string AuthenticateURL(string YOUR_CLIENT_ID, string YOUR_REGISTERED_REDIRECT_URI)
    {
        return "https://api.put.io/v2/oauth2/authenticate" +
            "?client_id=" + YOUR_CLIENT_ID +
            "&response_type=code" +
            "&redirect_uri=" + YOUR_REGISTERED_REDIRECT_URI;
    }

    public static string TokenRequestURL(string YOUR_CLIENT_ID, string YOUR_CLIENT_SECRET, string YOUR_REGISTERED_REDIRECT_URI, string CODE)
    {
        return "https://api.put.io/v2/oauth2/access_token" +
            "?client_id=" + YOUR_CLIENT_ID +
            "&client_secret=" + YOUR_CLIENT_SECRET +
            "&grant_type=authorization_code" +
            "&redirect_uri=" + YOUR_REGISTERED_REDIRECT_URI +
            "&code=" + CODE;
    }
}

public class API_Methods
{
    static int i = 3;

    public static class Files
    {
        public static string[] list(string parent_id)
        {
            string[] nfo = new string[i];
            nfo[0] = "GET";
            nfo[1] = "/files/list/" + parent_id;
            return nfo;
        }

        public static string[] createFolder(string name, string parent_id)
        {
            string[] nfo = new string[i];
            nfo[0] = "POST";
            nfo[1] = "/files/create-folder";
            nfo[2] = "name=" + name +
                "&parent_id=" + parent_id;
            return nfo;
        }

        public static string[] properties(string id)
        {
            string[] nfo = new string[i];
            nfo[0] = "GET";
            nfo[1] = "/files/" + id;
            return nfo;
        }

        public static string[] delete(string file_ids)
        {
            string[] nfo = new string[i];
            nfo[0] = "POST";
            nfo[1] = "/files/delete";
            nfo[2] = "file_ids=" + file_ids;
            return nfo;
        }

        public static string[] rename(string file_id, string name)
        {
            string[] nfo = new string[i];
            nfo[0] = "POST";
            nfo[1] = "/files/rename";
            nfo[2] = "file_id=" + file_id +
                "&name=" + name;
            return nfo;
        }

        public static string[] move(string file_ids, string parent_id)
        {
            string[] nfo = new string[i];
            nfo[0] = "POST";
            nfo[1] = "/files/move";
            nfo[2] = "file_ids=" + file_ids +
                "&parent_id=" + parent_id;
            return nfo;
        }

        public static string[] toMp4(string id)
        {
            string[] nfo = new string[i];
            nfo[0] = "POST";
            nfo[1] = "/files/" + id + "/mp4";
            nfo[2] = "id=" + id;
            return nfo;
        }

        public static string[] statusMp4(string id)
        {
            string[] nfo = new string[i];
            nfo[0] = "GET";
            nfo[1] = "/files/" + id + "/mp4";
            return nfo;
        }

        public static string[] download(string id)
        {
            string[] nfo = new string[i];
            nfo[0] = "GETRedirect";
            nfo[1] = "/files/" + id + "/download";
            return nfo;
        }
    }

    public static class Transfers
    {
        public static string[] list()
        {
            string[] nfo = new string[i];
            nfo[0] = "GET";
            nfo[1] = "/transfers/list";
            return nfo;
        }

        public static string[] add(string url, string save_parent_id)
        {
            string[] nfo = new string[i];
            nfo[0] = "POST";
            nfo[1] = "/transfers/add";
            nfo[2] = "url=" + url +
                "&save_parent_id=" + save_parent_id;
            return nfo;
        }

        public static string[] properties(string id)
        {
            string[] nfo = new string[i];
            nfo[0] = "GET";
            nfo[1] = "/transfers/" + id;
            return nfo;
        }

        public static string[] cancel(string transfer_ids)
        {
            string[] nfo = new string[i];
            nfo[0] = "POST";
            nfo[1] = "/transfers/cancel";
            nfo[2] = "transfer_ids=" + transfer_ids;
            return nfo;
        }
    }

    public class Account
    {
        public static string[] info()
        {
            string[] nfo = new string[i];
            nfo[0] = "GET";
            nfo[1] = "/account/info";
            return nfo;
        }

        public static string[] settings()
        {
            string[] nfo = new string[i];
            nfo[0] = "GET";
            nfo[1] = "/account/settings";
            return nfo;
        }
    }

    public class Friends
    {
        public static string[] list()
        {
            string[] nfo = new string[i];
            nfo[0] = "GET";
            nfo[1] = "/friends/list";
            return nfo;
        }

        public static string[] pending_requests()
        {
            string[] nfo = new string[i];
            nfo[0] = "GET";
            nfo[1] = "/friends/waiting-requests";
            return nfo;
        }

        public static string[] request(string username)
        {
            string[] nfo = new string[i];
            nfo[0] = "POST";
            nfo[1] = "/friends/" + username + "/request";
            nfo[2] = "";
            return nfo;
        }

        public static string[] deny(string username)
        {
            string[] nfo = new string[i];
            nfo[0] = "POST";
            nfo[1] = "/friends/" + username + "/deny";
            nfo[2] = "";
            return nfo;
        }
    }
}
