using AnimeGraphExploration.Entities;

namespace AnimeGraphExploration.Services
{
    public interface IAnimeGraphService
    {
        Task<AnimeGraph> GetAnimeGraph(int id);
    }
    public class MainPicture
    {
        public string medium { get; set; }
        public string large { get; set; }
    }

    public class Node
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class RelatedAnime
    {
        public Node node { get; set; }
        public string relation_type { get; set; }
        public string relation_type_formatted { get; set; }
    }

    public class AnimeJsonResponse
    {
        public int id { get; set; }
        public string title { get; set; }
        public MainPicture? main_picture { get; set; }
        public List<RelatedAnime> related_anime { get; set; }
    }

    public class AnimeGraphService : IAnimeGraphService
    {
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _httpClientFactory;

        public AnimeGraphService(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            _config = config;
            _httpClientFactory = httpClientFactory;
        }

        private async Task<AnimeJsonResponse> GetAnimeNode(int id)
        {
            var clientId = _config["MAL_CLIENT_ID"];
            if (clientId == null)
            {
                // todo: throw something
            }

            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Add("X-MAL-CLIENT-ID", clientId);

            var response = await httpClient.GetFromJsonAsync<AnimeJsonResponse>(
                string.Format("https://api.myanimelist.net/v2/anime/{0}?fields=related_anime", id)
            );

            return response;
        }

        public async Task<AnimeGraph> GetAnimeGraph(int id)
        {
            var animeGraph = new AnimeGraph();

            var toVisit = new Queue<int>();
            toVisit.Enqueue(id);

            while (toVisit.Count > 0)
            {
                var animeId = toVisit.Dequeue();

                var animeNode = await GetAnimeNode(animeId);
                animeGraph.Add(animeNode);

                foreach (RelatedAnime related in animeNode.related_anime)
                {
                    if (!animeGraph.Contains(related.node.id) && !toVisit.Contains(related.node.id))
                    {
                        toVisit.Enqueue(related.node.id);
                    }
                }
            }

            return animeGraph;
        }
    }
}