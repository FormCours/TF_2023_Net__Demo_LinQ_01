using Demo_LinQ_2.Models;


// Demo d'un filtre
List<Person> people = new List<Person>()
{
    new Person() { Id=1, Firstname="Della", Lastname="Duck" },
    new Person() { Id=2, Firstname="Zaza", Lastname="Vanderquack" },
    new Person() { Id=3, Firstname="Balthazar", Lastname="Picsou" },
    new Person() { Id=4, Firstname="Riri", Lastname="Duck" },
    new Person() { Id=6, Firstname="Fifi", Lastname="Duck" },
    new Person() { Id=5, Firstname="Gontran", Lastname="Bonheur" },
    new Person() { Id=7, Firstname="Loulou", Lastname="Duck" },
};

// - Traitement "classique" -> Sans utiliser "Linq to object"
List<string> ducks = new List<string>();
foreach (Person person in people)
{
    if (person.Lastname == "Duck")
    {
        ducks.Add(person.Firstname);
    }
}

people.Add(new Person() { Id = 8, Firstname = "Géo", Lastname = "Trouvetout" });
people.Add(new Person() { Id = 9, Firstname = "Donald", Lastname = "Duck" });
people.Add(new Person() { Id = 10, Firstname = "Miss", Lastname = "Tick" });

// Code peu ré-exploitable
// Code "Complexe" => Boucle avec une condition
// Si la source de donnée est modifié => Le resultat ne change pas :(

Console.WriteLine("Traitement \"classique\" : ");
foreach (string firstname in ducks)
{
    Console.WriteLine($"- {firstname}");
}
Console.WriteLine();
Console.WriteLine();

// - Même Traitement avec "Linq to object"

// (v1) Expression
IEnumerable<string> ducksLinq1 = from person in people
                                 where person.Lastname == "Duck"
                                 select person.Firstname;

// (v2) Methode extension
IEnumerable<string> ducksLinq2 = people.Where(person => person.Lastname == "Duck")
                                       .Select(person => person.Firstname);


Console.WriteLine("Traitement \"LinQ to object \" 1 : ");
foreach (string firstname in ducksLinq1)
{
    Console.WriteLine($"- {firstname}");
}
Console.WriteLine();

Console.WriteLine("-> On vire donald");
people.RemoveAll(person => person.Id == 9);
Console.WriteLine();

Console.WriteLine("Traitement \"LinQ to object \" 2 : ");
foreach (string firstname in ducksLinq1)
{
    Console.WriteLine($"- {firstname}");
}
Console.WriteLine();
Console.WriteLine();