namespace Final.Core.Entities
{
    public class Category :BaseEntity
    {
        public string  Title { get; set; }
        public string SubTitle { get; set; }
        public string Link { get; set; }
        public string  Image { get; set; }
        public ICollection<Blog> Blogs { get; set; }
        //public  ICollection<Product> Products { get; set; }
    }
}
