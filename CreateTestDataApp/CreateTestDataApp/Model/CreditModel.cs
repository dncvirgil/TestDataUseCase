using CsvHelper.Configuration.Attributes;

namespace CreateTestDataApp.Model
{
    internal class CreditModel
    {
        [Name("id")]
        public int Id { get; set; }

        [Name("title_id")]
        public int TitleId { get; set; }

        [Name("real_name")]
        public string RealName { get; set; }

        [Name("character_name")]
        public string CharacterName { get; set; }

        [Name("role")]
        public string Role { get; set; }
    }
}
