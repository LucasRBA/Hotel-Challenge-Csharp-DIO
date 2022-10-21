using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Person> guests = new List<Person>();

// Person p1 = new Person(name: "Hóspede 1");
// Person p2 = new Person(name: "Hóspede 2");

// hospedes.Add(p1);
// hospedes.Add(p2);

// // Cria a suíte
// Room room = new Room (roomType: "Premium", capacity: 2, pricePerNight: 30);

// // Cria uma nova reservation, passando a suíte e os hóspedes
// Reservation reservation = new Reservation(bookedDays: 5);
// reservation.CadastrarSuite(room);
// reservation.CadastrarHospedes(hospedes);

// // Exibe a quantidade de hóspedes e o valor da diária
// Console.WriteLine($"Hóspedes: {reservation.ObterQuantidadeHospedes()}");
// Console.WriteLine($"Valor diária: {reservation.CalcularValorDiaria()}");

string option = string.Empty;
bool showMenu = true;


Reservation reservation = new Reservation();
Room room = new Room();

while (showMenu)
{
    Console.Clear();
    Console.WriteLine($"Welcome to our Hotel! \n");
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1 - Check-in");
    Console.WriteLine("2 - Choose/Alter room type");
    Console.WriteLine("3 - List guests");
    Console.WriteLine("4 - Checkout");
    Console.WriteLine("5 - Exit");

    switch (Console.ReadLine())
    {
        case "1":
            reservation.GuestRegistration(guests);
            break;

        case "2":
            reservation.GetSuiteType(room);
            break;

        case "3":
            reservation.DisplayBookedGuests();
            break;

        case "4":
            reservation.CalculateTotal();
            break;
        
        case "5":
            showMenu = false;
            break;

        default:
            Console.WriteLine("Invalid option");
            break;
    }
}