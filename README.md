# Anime Graph Exploration

A website to explore your favorite anime!

![Cute anime girl](doc/AnimeGirl.gif)

## Running in development

A My Anime List API key is required for the backend to function. The key is read through the environment variable `MAL_CLIENT_ID`. For convenience you may add the following line to `appsettings.json`

```js
{
  "MAL_CLIENT_ID": "<secret key>",
  "Logging": {
      // ...
    },
  "AllowedHosts": "*"
}

```
