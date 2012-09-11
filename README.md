#### About
A .Net library for the [Put.io][1] [API v2][2].

#### How
1. Authenticate using netputio.AuthURL (sets this when instantiating netputio class)
2. Obtain code from redirect url (https://YOUR_REGISTERED_REDIRECT_URI/?code=CODE
3. Obtain token using netputio.TokenRequest(code);

You are now free to use commands such as:
```csharp
nputio..Request(ParseRequest.Transfers.add("magnet:?xt=urn:btih", "0"));
```

[1]: http://put.io/
[2]: https://api.put.io/v2/docs/