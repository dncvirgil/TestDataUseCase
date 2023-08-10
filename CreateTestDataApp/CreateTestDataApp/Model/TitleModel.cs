using CsvHelper.Configuration.Attributes;

namespace CreateTestDataApp.Model
{
    internal class TitleModel
    {
        [Name("id")]
        public int Id { get; set; }

        [Name("title")]
        public string Title { get; set; }

        [Name("description")]
        public string Description { get; set; }

        [Name("release_year")]
        public int ReleaseYear { get; set; }

        [Name("age_certification")]
        public string AgeCertification { get; set; }

        [Name("runtime")]
        public int Runtime { get; set; }

        [Name("genres")]
        public List<string> Genres { get; set; }

        [Name("production_country")]
        public string ProductionCountry { get; set; }

        [Name("seasons")]
        public int? Seasons { get; set; }

        [Ignore]
        public List<CreditModel> Credits { get; set; }
    }
}
