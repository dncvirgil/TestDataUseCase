using CreateTestDataApp;
using CreateTestDataApp.Faker;

string titlesOutputPath = "./generated_titles.csv";
string creditsOutputPath = "./generated_credits.csv";

var faker = new TitleFaker();
var titles = faker.Generate(200);

CsvGenerator.Generate(titles, titlesOutputPath);

var credits = titles.SelectMany(a => a.Credits).ToList();
CsvGenerator.Generate(credits, creditsOutputPath);

