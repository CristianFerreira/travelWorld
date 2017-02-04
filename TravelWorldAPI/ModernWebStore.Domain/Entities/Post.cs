using System;

namespace ModernWebStore.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
        public string picture { get; set; }
        public string txtPicture { get; set; }
        public string video { get; set; }

        public int idCategory { get; set; }
        public Category category { get; set; }

        public int idContinent { get; set; }
        public Continent continent { get; set; }

        public int idUser { get; set; }
        public User users { get; set; }

    }
}