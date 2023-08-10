using Bogus;
using CreateTestDataApp.Model;

namespace CreateTestDataApp.Faker
{
    internal class CreditFaker : Faker<CreditModel>
    {
        private static int creditIds = 1;

        private static readonly List<string> roles = new()
        {
            "Director", "Producer", "Screenwriter", "Actor", "Actress", "Cinematographer", "Film Editor", "Production Designer", "Costume Designer", "Music Composer"
        };

        public CreditFaker(int titleId)
        {
            StrictMode(true);
            RuleFor(o => o.Id, f => creditIds++);
            RuleFor(o => o.TitleId, _ => titleId);
            RuleFor(o => o.RealName, f => f.Name.FullName().OrNull(f, 0.4f));
            RuleFor(o => o.CharacterName, f => f.Name.FullName().OrNull(f, 0.4f));
            RuleFor(o => o.Role, f => f.PickRandom(roles).OrNull(f, 0.4f));
        }
    }
}
