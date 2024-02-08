
//using TaskDataBaseSql.Services;

//namespace ApplicationSql.Service
//{
//    public class PlayerMenuUI
//    {
//        private readonly ClientService _clientService;

//        public PlayerMenuUI(ClientService clientService)
//        {
//            _clientService = clientService;
//        }

//        public void CreatePlayer()
//        {
//            Console.Clear();

//            Console.WriteLine("---Create Player---");

//            Console.Write("First Name: ");
//            var firstname = Console.ReadLine()!;

//            Console.Write("Last Name: ");
//            var lastname = Console.ReadLine()!;

//            Console.Write("StreetName: ");
//            var streetname = Console.ReadLine()!;

//            Console.Write("PostalCode: ");
//            var postalcode = Console.ReadLine()!;

//            Console.Write("City: ");
//            var city = Console.ReadLine()!;

//            Console.Write("Email: ");
//            var email = Console.ReadLine()!;

//            Console.Write("PhoneNumber: ");
//            var phoneNumber = Console.ReadLine()!;

//            var result = _clientService.CreateClient(firstname, lastname,streetname,postalcode,city,email,phoneNumber);    
//            if (result != null)
//            {
//                Console.Clear();
//                Console.WriteLine("Player was create");

//                Console.ReadKey();  
//            }
//        }

//        public void GetPlayer()
//        {
//            Console.Clear();
//            var player = _clientService.GetAllClients();

//            foreach (var client in player)
//            {
//                Console.Clear();
//                Console.WriteLine($"{client.FirstName} - {client.LastName} - {client.Address.StreetName} - {client.Address.PostalCode} - {client.Address.City} - {client.Contact.Email} - {client.Contact.PhoneNumber}");

//            }
//            Console.ReadKey();
//        }

//        public void UpdatePlayer()
//        {
//            Console.Clear();
//            Console.Write("Enter Id: ");
//            var id = int.Parse(Console.ReadLine()!);
//            var client = _clientService.GetClientById(id);

//            if (client != null)
//            {
//                Console.WriteLine($"{client.FirstName} - {client.LastName} - {client.Address.StreetName} - {client.Address.PostalCode} - {client.Address.City} - {client.Contact.Email} - {client.Contact.PhoneNumber}");
//                Console.WriteLine();

//                Console.Write("New Player Name: ");
//                client.FirstName = Console.ReadLine()!;

//                var newPlayer = _clientService.UpdateClient(client);
//                Console.WriteLine($"{client.FirstName} - {client.LastName} - {client.Address.StreetName} - {client.Address.PostalCode} - {client.Address.City} - {client.Contact.Email} - {client.Contact.PhoneNumber}");


//            }
//            else 
//            {

//                Console.WriteLine("No Player Found");

//            }
//            Console.ReadKey();
//        }




//    }
//}
using TaskDataBaseSql.Services;

namespace ApplicationSql.Service
{
    public class PlayerMenuUI
    {
        private readonly ClientService _clientService;

        public PlayerMenuUI(ClientService clientService)
        {
            _clientService = clientService;
        }

        public void CreatePlayer()
        {
            Console.WriteLine("---Create Player---");

            Console.Write("First Name: ");
            var firstName = Console.ReadLine()!;

            Console.Write("Last Name: ");
            var lastName = Console.ReadLine()!;

            Console.Write("Street Name: ");
            var streetName = Console.ReadLine()!;

            Console.Write("Postal Code: ");
            var postalCode = Console.ReadLine()!;

            Console.Write("City: ");
            var city = Console.ReadLine()!;

            Console.Write("Email: ");
            var email = Console.ReadLine()!;

            Console.Write("Phone Number: ");
            var phoneNumber = Console.ReadLine()!;

            var result = _clientService.CreateClient(firstName, lastName, streetName, postalCode, city, email, phoneNumber);
            if (result != null)
            {
                Console.WriteLine("Player was created");
                Console.ReadKey();
            }
        }

        public void GetPlayer()
        {
            Console.WriteLine("---List of Players---");

            var players = _clientService.GetAllClients();

            foreach (var player in players)
            {
                Console.WriteLine($"{player.FirstName} - {player.LastName} - {player.Address.StreetName} - {player.Address.PostalCode} - {player.Address.City} - {player.Contact.Email} - {player.Contact.PhoneNumber}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void UpdatePlayer()
        {
            Console.WriteLine("---Update Player---");

            Console.Write("Enter Player ID: ");
            var id = int.Parse(Console.ReadLine()!);

            var client = _clientService.GetClientById(id);

            if (client != null)
            {
                Console.WriteLine($"Current Player Details: {client.FirstName} - {client.LastName} - {client.Address.StreetName} - {client.Address.PostalCode} - {client.Address.City} - {client.Contact.Email} - {client.Contact.PhoneNumber}");
                Console.WriteLine();

                Console.Write("New First Name: ");
                client.FirstName = Console.ReadLine()!;

                var updatedPlayer = _clientService.UpdateClient(client);
                Console.WriteLine($"Updated Player Details: {updatedPlayer.FirstName} - {updatedPlayer.LastName} - {updatedPlayer.Address.StreetName} - {updatedPlayer.Address.PostalCode} - {updatedPlayer.Address.City} - {updatedPlayer.Contact.Email} - {updatedPlayer.Contact.PhoneNumber}");
            }
            else
            {
                Console.WriteLine("No Player Found");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void DeletePlayer()
        {
            Console.Write("Enter Player ID: ");
            var id = int.Parse(Console.ReadLine()!);

            var client = _clientService.GetClientById(id);

            if (client != null)
            {
                _clientService.DeleteClient(client.Id);
                Console.WriteLine("Player Was Deleted");
            }
            else
            {
                Console.WriteLine("Player was not Deleted");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }
}

