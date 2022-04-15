// See https://aka.ms/new-console-template for more information
//Teoria:
//1: c-d
//2. b-c
//3. a-d
using Test_7;


ManagerDB repository = new ManagerDB();



List<User> newUsers = new List<User>();
User u1 = new User("Federica");
User u2 = new User("Valentina");
newUsers.Add(u1);
newUsers.Add(u2);

try
{
    Console.WriteLine("Salve salvino vicino ino ino!");
    Console.WriteLine("Inserisci il nome per cui vuoi fare una ricerca: ");
    string nome = Console.ReadLine();
    Console.WriteLine("facciamo una ricerca veloce:");
    //repository.EsistenzaUtente(nome); //Eccezione del database
    ValidateStudent(nome);//Eccezione personalizzata, questa non va sul database ma su una lista creata da me
}
catch (UserException ex)
{
    Console.WriteLine(ex.Message);
}


void ValidateStudent(string student)
{
    foreach (var item in newUsers)
    {
        if (item.Name == student)
        {
            Console.WriteLine("Abbiamo trovato l'User");
            return;
        }
    }
    throw new UserException(student);
}
