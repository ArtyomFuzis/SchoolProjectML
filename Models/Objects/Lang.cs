namespace PLTest.Models.Objects
{
    [Serializable]
    public struct Lang
    {
        
        public string Title { get; set; }
        public string Content { get; set; }
        public Uri Homelink { get; set; }
        public Uri Wikilink { get; set; }
        public string ImageLink { get; set; }
        public Lang(string title,string content,Uri homelink,Uri wiklink, string img_link) 
        {
            Title = title;
            Content = content;
            Homelink = homelink;
            Wikilink = wiklink;
            ImageLink = img_link;
        }
    }
}
