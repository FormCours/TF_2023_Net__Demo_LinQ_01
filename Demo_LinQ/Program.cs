// Var
/*
var nb1 = 42;               // Int
var text = "Denys";         // String

var nb2 = 2_000_000_000;    // Int
var nb3 = 4_000_000_000;    // UInt

nb3 = -2;                   // Bug (╯°□°）╯︵ ┻━┻
*/

// Type Ano
using Demo_LinQ.ExtensionHelper;
using Demo_LinQ.Models;

var person = new
{
    Firstname = "Della",
    Lastname = "Duck"
};

// Lambda expression

// - Procedure
Action<string, string> displayDel = (firstname, lastname) => Console.WriteLine($"Bienvenu {firstname} {lastname}");

// - Fonction (retour d'une valeur generique)
Func<string, bool> filterDel = (name) => name.Contains("e");

// - Fonction (retour d'un booléen)
Predicate<string> predicateDel = (name) => !name.Contains("a") && name.Contains("e");


// Méthode d'extension

// (Non nullable)
string teacher = "Della";

// - Utilisation en tant qu'extension 
bool test1a = teacher.ContainsLetterE();
bool test1b = teacher.ContainsLetter('X');

// - Utilisation en tant que méthode static
bool test1c = StringHelper.ContainsLetterE(teacher);
bool test1d = StringHelper.ContainsLetter(teacher, 'X');

// (Nullable)
string? student = "Denys";

// - Utilisation en tant qu'extension
bool test2a = student?.ContainsLetterE() ?? false;

// - Utilisation en tant que méthode static
bool test2b = (student is not null) && StringHelper.ContainsLetterE(student);



