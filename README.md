# 🎶 Deep-Dive Recommender

A serverless playlist curator that lets users explore an artist’s complete discography on Spotify—surfacing both the hits and hidden gems, organized into a coherent listening journey.

---

## 🚀 Overview

Deep-Dive Recommender is a full-stack demo built with Azure Functions (.NET 8) and a React front end. Given any Spotify artist, it:

1. Retrieves all albums & tracks
2. Analyzes track popularity and audio features
3. Picks each album’s “Hit Highlight” (most popular) and one “Deep Cut” (underrated + sonically distinctive)
4. Sorts the picks chronologically for a seamless listening flow
5. Returns a curated list of track URIs you can play or save as a Spotify playlist

This project showcases serverless architecture, API integration, data caching, and real-time user interaction

---

## ✨ Key Features

* **OAuth2 Authentication** via Spotify (Authorization Code Flow)
* **Deep-Dive Algorithm**: hits + hidden tracks per album
* **Azure Functions**

  * `SpotifyAuth` → redirect to Spotify login
  * `SpotifyCallback` → exchange code for tokens
  * `DeepDiveRecommender` → discography analysis & playlist assembly
* **Cosmos DB Caching**  Reduce API calls & improve performance
* **React Front End**

  * Artist search and selection
  * “Deep-Dive” trigger and results display
  * “Create this Playlist” link back into Spotify
* **Infrastructure as Code** with ARM/Bicep (or Terraform)
* **CI/CD** via GitHub Actions
* **Telemetry** with Application Insights

---

## 🛠️ Tech Stack

| Layer       | Technology                            |
| ----------- | ------------------------------------- |
| Compute     | Azure Functions (.NET 8, isolated)    |
| Data        | Cosmos DB (caching)          |
| Front End   | React (Vite) + TypeScript      |
| Auth & API  | Spotify Web API + Web Playback SDK    |
| IaC & CI/CD | Bicep (or Terraform) + GitHub Actions |
| Monitoring  | Azure Application Insights            |

---

## 📋 Prerequisites

* [.NET 8 SDK](https://dot.net/download)
* [Azure Functions Core Tools v4](https://docs.microsoft.com/azure/azure-functions/functions-run-local)
* [Node.js & npm](https://nodejs.org)
* A **Spotify Developer** account & registered app
* (Optional) Azure Subscription for deployment

---

## ⚙️ Configuration

### Spotify Dashboard Setup

1. Go to the [Spotify Developer Dashboard](https://developer.spotify.com/dashboard).
2. Register a new app, then in **Edit Settings → Redirect URIs** add:

   * `https://localhost:7071/api/spotify-callback`
   * `https://<your-production-app>.azurewebsites.net/api/spotify-callback`

### local.settings.json

Create a `local.settings.json` at the project root with:

```jsonc
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "SPOTIFY_CLIENT_ID": "<your-client-id>",
    "SPOTIFY_CLIENT_SECRET": "<your-client-secret>",
    "SPOTIFY_REDIRECT_URI": "https://localhost:7071/api/spotify-callback",

    // (Optional) Cosmos DB settings
    "COSMOS_DB_CONNECTION": "<your-cosmos-connection-string>",
    "COSMOS_DB_DATABASE_NAME": "RecommenderDb",
    "COSMOS_DB_CONTAINER_NAME": "ArtistCache"
  }
}
```


---

## 🏃‍♂️ Running Locally

1. **Start the Functions host**

   ```bash
   cd PlaylistRecommender
   func start 
   ```

---


## 🔮 Future Improvements

* **User Accounts**: persist user-saved playlists & preferences
* **Advanced ML**: integrate Azure ML for collaborative-filtering recommendations
* **Mobile**: React Native companion app
* **Playlist Embedding**: inline Spotify Web Playback SDK in UI
* **A/B Testing**: experiment with different “Deep Cut” selection algorithms

---

## 📞 Contact

**Author:** \[Victory Iyakoregha]
**GitHub:** [SpotifyWebApp](https://github.com/Mivezvictory/SpotifyWebApp.git)

---

## 📄 License

This project is MIT-licensed. See [LICENSE](./LICENSE) for details.
