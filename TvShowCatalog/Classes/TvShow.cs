namespace TvShowCatalog
{
    public class TvShow : BaseEntity
    {
        private Genre Genre { get; set; }
        private String Title { get; set; }
        private String Description { get; set; }
        private int Year { get; set; }
        public bool Removed { get; set; }
        public TvShow(int id, Genre genre, string tittle,
                        string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = tittle;
            this.Description = description;
            this.Year = year;
            this.Removed = false;
        }

        public override string ToString()
        {
            string @return = "";
            @return += "Genre: " + this.Genre + Environment.NewLine;
            @return += "Title: " + this.Title + Environment.NewLine;
            @return += "Description: " + this.Description + Environment.NewLine;
            @return += "Removed: " + this.Year + this.Removed +Environment.NewLine;
            @return += "Year: " + this.Year;
            return @return;
        }
        public string TittleReturnner()
        {
            return this.Title;
        }
        public int IdReturnner()
        {
            return this.Id;
        }
        public void RemoveFormCatalog()
        {
            this.Removed = true;
        }
    }
}