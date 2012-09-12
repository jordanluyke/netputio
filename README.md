#### About
A .Net library for the [Put.io][1] [API v2][2].

#### How
1. Log in at netputio.AuthURL (sets this up when instantiating netputio class)
2. Obtain code from redirect url (https://YOUR_REGISTERED_REDIRECT_URI/?code=CODE)
3. Obtain netputio.Token by using netputio.TokenRequest(code);

You are now free to use commands such as:
```csharp
nputio.Request(ParseRequest.Transfers.add("magnet:?xt=urn:btih", "0"));
```
and
```csharp
nputio.Request(ParseRequest.Files.properties("654321"));
```

[1]: http://put.io/
[2]: https://api.put.io/v2/docs/