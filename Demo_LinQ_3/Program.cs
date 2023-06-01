using Demo_LinQ_3.Models;

List<Person> people = new List<Person>
{
    new Teacher {Id= 1, Firstname="Della", Lastname="Duck",  IsAppointed=true, Domain="Science" },
    new Student {Id= 2, Firstname = "Zaza", Lastname="Vanderquack", Section="Science", Result=17},
    new Student {Id= 3, Firstname = "Gontran", Lastname="Bonheur", Section="Science", Result=7},
    new Teacher {Id= 4, Firstname="Balthazar", Lastname="Picsou",  IsAppointed=true, Domain="Economie" },
    new Student {Id= 5, Firstname = "Riri", Lastname="Duck", Section="Economie", Result=12},
    new Student {Id= 6, Firstname = "Fifi", Lastname="Duck", Section="Economie", Result=15},
    new Student {Id= 7, Firstname = "Loulou", Lastname="Duck", Section="Economie", Result=5},
    new Teacher {Id= 8, Firstname="Goé", Lastname="Trouvetout",  IsAppointed=false, Domain="Science" },
    new Student {Id= 9, Firstname = "Flagada", Lastname="Jones", Section="Science", Result=1},
};

// Sans LinQ :(
List<Teacher> teachers1 = new List<Teacher>();
foreach(Person p in people)
{
    // if(p.GetType() == typeof(Teacher))
    if(p is Teacher && ((Teacher)p).IsAppointed)
    {
        teachers1.Add((Teacher) p);
    }
}

// Avec LinQ 😻
IEnumerable<Teacher> teachers2 = people.OfType<Teacher>().Where(p => p.IsAppointed);

IEnumerable<Teacher> teachers3 = from t in people.OfType<Teacher>()
                                 where t.IsAppointed
                                 select t;

// Affichage du resultat
Console.WriteLine("La liste des profs nommés : ");
foreach (Teacher teacher in teachers2)
{
    Console.WriteLine($" - {teacher.Firstname} {teacher.Lastname}");
}
Console.WriteLine();

// Les etudiants de la section "Economie" avec plus de 10 en resultat
IEnumerable<Student> students1 = people.OfType<Student>()
                                       .Where(s => s.Section == "Economie" && s.Result > 10);

IEnumerable<Student> students2 = people.OfType<Student>()
                                       .Where(s => s.Section == "Economie")
                                       .Where(s => s.Result > 10);

IEnumerable<Student> students3 = from s in people.OfType<Student>()
                                 where s.Section == "Economie" && s.Result > 10
                                 select s;

Console.WriteLine("List des etudiant d'économie qui ont réusis");
foreach(Student student in students3)
{
    Console.WriteLine($" - {student.Firstname} {student.Lastname}");
}
Console.WriteLine();

// Récuperation des etudiants qui ont la moyenne => Nom complet + Resultat

var students4 = from s in people.OfType<Student>()
                where s.Result >= 10
                select new { Name = s.Firstname + " " + s.Lastname, Result = s.Result };

var students5 = people.OfType<Student>()
                      .Where(s => s.Result >= 10)
                      .Select(s => new { Name = s.Firstname + " " + s.Lastname, Result = s.Result });


// Récuperation de tout les noms de famille (sans doublon)

IEnumerable<string> lastnames1 = (from p in people
                                  select p.Lastname
                                  ).Distinct() ;

IEnumerable<string> lastnames2 = people.Select(p => p.Lastname)
                                       .Distinct();

Console.WriteLine("Liste des noms de famille");
foreach(string name in lastnames1)
{
    Console.WriteLine($" - {name}");
}
Console.WriteLine();

// Récuperation de l'etudiante qui s'appel "Vanderquack"

IEnumerable<Student> students6 = from s in people.OfType<Student>()
                                 where s.Lastname == "Vanderquack"
                                 select s;
Student? target1 = students6.SingleOrDefault();

Student? target2 = people.OfType<Student>()
                         .Where(s => s.Lastname == "Vanderquack")
                         .SingleOrDefault();

// Récuperation des etudiants par ordre (DESC) de nom
IEnumerable<Student> students7 = from s in people.OfType<Student>()
                                 orderby s.Lastname descending
                                 select s;

IEnumerable<Student> students8 = people.OfType<Student>()
                                       .OrderByDescending(s => s.Lastname);

Console.WriteLine("List des etudiant trier par nom (DESC)");
foreach(Student s in students8)
{
    Console.WriteLine($"{s.Lastname} {s.Firstname} {s.Result}");
}
Console.WriteLine();

// Récuperation des etudiants par ordre (DESC) de nom et (ASC) de resultat
IEnumerable<Student> students9 = from s in people.OfType<Student>()
                                 orderby s.Lastname descending, s.Result ascending
                                 select s;

IEnumerable<Student> students10 = people.OfType<Student>()
                                       .OrderByDescending(s => s.Lastname)
                                       .ThenBy(s => s.Result);

Console.WriteLine("List des etudiant trier par nom (DESC) et leur resultat (ASC)");
foreach (Student s in students10)
{
    Console.WriteLine($"{s.Lastname} {s.Firstname} {s.Result}");
}
Console.WriteLine();




Console.WriteLine("Nombre d'étudiant");
int nbStudent = people.OfType<Student>().Count();
Console.WriteLine(nbStudent);
Console.WriteLine();

Console.WriteLine("Utilisation du Min/Max sur les string");
string? demo1 = people.OfType<Student>().Min(s => s.Lastname);
string? demo2 = people.OfType<Student>().Max(s => s.Lastname);

Console.WriteLine("Min : " + demo1);
Console.WriteLine("Max : " + demo2);
Console.WriteLine();


Console.WriteLine("Utilisation du Average");
var demo3 = people.OfType<Student>().Average(s => s.Lastname.Length);
Console.WriteLine("La moyenne de la longeur des noms de famille : " + demo3);
Console.WriteLine();
