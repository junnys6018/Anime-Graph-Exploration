using AnimeGraphExploration.Services;

namespace AnimeGraphExploration.Entities
{
    public class AnimeGraph
    {
        public List<Anime> Animes { get; set; }
        public List<AnimeRelation> Relationships { get; set; }

        public AnimeGraph()
        {
            Animes = new List<Anime>();
            Relationships = new List<AnimeRelation>();
        }

        public void Add(AnimeJsonResponse item)
        {
            var anime = new Anime
            {
                Title = item.title,
                Id = item.id,
                Picture = item.main_picture.large,
            };

            Animes.Add(anime);

            foreach (RelatedAnime related in item.related_anime)
            {
                Relationships.Add(new AnimeRelation
                {
                    From = item.id,
                    To = related.node.id,
                    Relationship = related.relation_type,
                });
            }
        }

        public bool Contains(int id)
        {
            return Animes.Exists(x => x.Id == id);
        }

    }

    public class Anime
    {
        public string Title { get; set; }
        public int Id { get; set; }

        public string Picture { get; set; }
    }

    public class AnimeRelation
    {
        public int From { get; set; }
        public int To { get; set; }
        public string Relationship { get; set; }

    }

}