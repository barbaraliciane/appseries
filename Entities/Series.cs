using ProjectSeries.Entities.Enum;

namespace ProjectSeries
{
    public class Series : EntityBase
    {
        private Genero Kind { get; set;
        }
        private string Title { get; set; }

        private string Description { get; set; }

        private int Release { get; set;}

        private bool Excluded { get; set;}

        public Series(int id, Genero kind, string title, string description, int release)
        {
           this.Id = id;
           this.Kind = kind;
           this.Title = title; 
           this.Description = description;
           this.Release = release;
           this.Excluded = false;
        }
        public override string ToString()
        {
            string regress = "";
            regress += "Kind: " + this.Kind + Environment.NewLine;
            regress += "Title: " + this.Title + Environment.NewLine;
            regress += "Description: " + this.Description + Environment.NewLine;
            regress += "Release: " + this.Release+ Environment.NewLine;
            regress += "Excluído: " + this.Excluded;
            return regress;
        }

        public bool ReturnExcluded()
        {
            return this.Excluded;
        }
        public string ReturnTitle()
        {
            return this.Title;
        }

        internal int ReturnId()
        {
            return this.Id;
        }

        public void Excludes()
        {
            this.Excluded = true;
        }
    }
}