using Bogus;
using CreateTestDataApp.Model;

namespace CreateTestDataApp.Faker
{
    internal class TitleFaker : Faker<TitleModel>
    {
        private static int titleIds = 1;

        private static readonly List<string> certifications = new()
        {
            "G", "PG", "PG-13", "R", "NC-17", "U", "U/A", "A", "S", "AL", "6", "9", "12", "12A", "15", "18", "18R", "R18", "R21", "M", "MA15+", "R16", "R18+", "X18", "T", "E", "E10+", "EC", "C", "CA", "GP", "M/PG", "TV-Y", "TV-Y7", "TV-G", "TV-PG", "TV-14", "TV-MA"
        };

        public TitleFaker()
        {
            StrictMode(true);
            RuleFor(o => o.Id, f => titleIds++);
            RuleFor(o => o.Title, f => f.Lorem.Sentence(1, 20).OrNull(f, 0.4f));
            RuleFor(o => o.Description, f => f.Lorem.Sentences(f.Random.Int(1, 5)).OrNull(f, 0.4f));
            RuleFor(o => o.ReleaseYear, f => f.Date.PastOffset(f.Random.Int(0, 80)).Year);
            RuleFor(o => o.AgeCertification, f => f.PickRandom(certifications).OrNull(f, 0.4f));
            RuleFor(o => o.Runtime, f => f.Random.Number(1, 500));
            RuleFor(o => o.Genres, f => f.Random.WordsArray(1, 10).ToList().OrNull(f, 0.4f));
            RuleFor(o => o.ProductionCountry, f => f.Address.CountryCode().OrNull(f, 0.4f));
            RuleFor(o => o.Seasons, f => f.Random.Int(0, 100).OrNull(f, .5f));
            RuleFor(o => o.Credits, (f, e) =>
            {
                return GetCredits(e.Id, f.Random.Int(0, 10));
            });
        }

        private static List<CreditModel> GetCredits(int titleId, int count)
        {
            var creditFaker = new CreditFaker(titleId);
            return creditFaker.Generate(count);
        }
    }
}
