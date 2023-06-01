using Demo_LinQ_4.Models;

// Initialiser le context
List<Author> authors = new List<Author>
{
    new Author { Id = 1, Firstname = "Douglas", Lastname = "Adams" },
    new Author { Id = 2, Firstname = "Stephen", Lastname = "King" },
    new Author { Id = 3, Firstname = "John Ronald Reuel", Lastname = "Tolkien" },
    new Author { Id = 4, Firstname = "Christopher", Lastname = "Delecluse" }
};

List<Book> books = new List<Book>
{
    new Book { Id= 1, Title = "Le seigneur des anneaux", Year = 1954, Genre = "Fantasy", AuthorId = 3},
    new Book { Id= 2, Title = "La ligne verte", Year = 1996, Genre = "Fantastique", AuthorId = 2},
    new Book { Id= 3, Title = "Du conte de fées", Year = 1947, Genre = "Essai", AuthorId = 3},
    new Book { Id= 4, Title = "H2G2 - Le guide du voyageur galactique", Year = 1978, Genre = "Science-fiction humoristique", AuthorId = 1},
    new Book { Id= 5, Title = "Salem", Year = 1977, Genre = "Horreur", AuthorId = 2},
};

// Récuperation des livres avec le nom de l'auteur
var demo01 = books.Join(                // Source de donnée 1
                    authors,            // Source de donnée 2
                    b => b.AuthorId,    // Clef de jointure sur la Source 1
                    a => a.Id,          // Clef de jointure sur la Source 2
                    (book, author) => new
                    {                   // Résultat sur base des 2 sources de données
                        Nom = book.Title,
                        Annee = book.Year,
                        Author = author.Firstname + " " + author.Lastname
                    }
                );

var demo02 = from b in books                // Source de donnée 1
             join a in authors              // Source de donnée 2
                on b.AuthorId equals a.Id   // Condition de la jointure
             select new                     // Résultat sur base des 2 sources de données
             {
                 Nom = b.Title,
                 Annee = b.Year,
                 Author = a.Firstname + " " + a.Lastname
             };

Console.WriteLine("Join : ");
foreach (var result in demo02)
{
    Console.WriteLine($"{result.Nom} {result.Annee} - {result.Author}");
}
Console.WriteLine();
Console.WriteLine();

// Récuperation tout les livres de Tolkien
IEnumerable<Book> demo03 = books.Join(                  // Source de donnée 1
                                    authors,            // Source de donnée 2
                                    b => b.AuthorId,    // Clef de jointure sur la Source 1
                                    a => a.Id,          // Clef de jointure sur la Source 2
                                    (book, author) => new
                                    {
                                        Book = book,
                                        Author = author
                                    }
                                 )
                                 .Where(x => x.Author.Lastname == "Tolkien")
                                 .Select(x => x.Book);


IEnumerable<Book> demo04 = from b in books                // Source de donnée 1
                           join a in authors              // Source de donnée 2
                              on b.AuthorId equals a.Id   // Condition de la jointure
                           where a.Lastname == "Tolkien"
                           select b;




// Récuperation des auteurs avec leurs livres (ou aucun)
var demo05 = authors.GroupJoin(                  // Source de donnée 1
                        books,                   // Source de donnée 2
                        author => author.Id,     // Clef de jointure sur la Source 1
                        book => book.AuthorId,   // Clef de jointure sur la Source 2
                        (author, books) => new
                        {
                            Nom = author.Firstname + " " + author.Lastname,
                            Livres = books
                        }
                    );


var demo06 = from a in authors                  // Source de donnée 1
             join b in books                    // Source de donnée 2
                on a.Id equals b.AuthorId       // Condition de jointure
                into authorBooks                // Groupe d'element join
             select new
             {
                 Nom = a.Firstname + " " + a.Lastname,
                 Livres = authorBooks
             };


Console.WriteLine("GroupJoin : ");
foreach (var result in demo06)
{
    // Boucle sur les auteurs
    Console.WriteLine(" - " + result.Nom);

    if(result.Livres.Any())
    {
        foreach(Book livre in result.Livres)
        {
            // Boucle secondaire sur les livres de l'auteur
            Console.WriteLine("   " + livre.Title);
        }
    }
    else
    {
        Console.WriteLine("   (Pas encore de livre)");
    }
}