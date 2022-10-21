namespace DesafioProjetoHospedagem.Models
{
    public class Reservation
    {
        public List<Person> Guests { get; set; }
        public Room Room { get; set; }
        public int BookedDays { get; set; }

        public Reservation() { }

        public Reservation(int bookedDays)
        {
            BookedDays = bookedDays;
        }


        public void GuestRegistration(List<Person> guests)
        {

            bool guestsAddition = true;

            while(guestsAddition == true) {
                Person p1 = new Person();
                Console.WriteLine("Enter the First name of the guest");
                string FirstName = Console.ReadLine();
                p1.Name = FirstName;
                Console.WriteLine("Enter the Last name of the guest");
                string LastName = Console.ReadLine();
                p1.LastName = LastName;
                Console.WriteLine(p1.FullName + "\n");
                guests.Add(p1);
                Console.WriteLine($"Want to add more guests? \n 1 - Yes \n 2 - No" );
                string moreGuests="";
                    moreGuests = Console.ReadLine();
                    if (moreGuests == "1") {
                        guestsAddition = true;
                    } else if(moreGuests == "2"){
                        guestsAddition = false;
                    } else {
                        Console.WriteLine("Invalid Option, try again"); 
                        moreGuests = Console.ReadLine();
                        break;
                    }
                
            }

            

            Room room = new Room (roomType: "Premium", capacity: 20, pricePerNight: 150);
            GetSuiteType(room);

            if (Room.Capacity >= guests.Count)
            {
                Guests = guests;
            }
            else
            {
                throw new Exception($"You can't book the selected room since the number of guests {guests.Count} is "+
                                    $"is greater than the room capacity {Room.Capacity}");
            }
        }

        public void GetSuiteType(Room room)
        {
            Room = room;

            bool roomMenu = true;
            bool petMenu = true;
            int petNumber = 0;
            decimal petFare = 30M;

            while(roomMenu) {
                Console.WriteLine("Please enter your the type of room you want to book \n");
                Console.WriteLine(" 1 - Single \n 2 - Double \n 3 - Small Family \n 4 - Medium family(2 kids) \n" + 
                " 5 - Big family(3 kids) \n 6 - Premium(4 people) \n 7 - Exit");
                string chosenRoom =  Console.ReadLine();
                switch (chosenRoom)
                {
                    case "1":
                        room.Capacity = 1;
                        room.PricePerNight = 120;
                        room.RoomType="Single";
                        break;

                    case "2":
                        room.Capacity = 2;
                        room.PricePerNight = 150;
                        room.RoomType="Double";
                        break;
                    
                    case "3":
                        room.Capacity = 3;
                        room.PricePerNight = 200;
                        room.RoomType="Small family";
                        break;
                    
                    case "4":
                        room.Capacity = 4;
                        room.PricePerNight = 280;
                        room.RoomType="Medium Family";
                        break;

                    case "5":
                        room.Capacity = 5;
                        room.PricePerNight = 320;
                        room.RoomType="Big Family";
                        break;

                    case "6":
                        room.Capacity = 4;
                        room.PricePerNight = 550;
                        room.RoomType="Premium";
                        break;
                        
                    case "7":
                        roomMenu=false;
                        petMenu=false;
                        break;

                    default:
                        Console.WriteLine("Invalid option please try again");
                        break;
            }
            

            while(petMenu) {
                Console.WriteLine("Do you need a pet friendly room? Any of our rooms can be turned into one," +  
                $" the charge is {petFare:C} per animal per night");
                Console.WriteLine(" 1 - Yes \n 2 - No");
                string petOption = Console.ReadLine();
                switch(petOption)
                {
                    case "1":
                        Console.WriteLine("Type the number of pets you're bringing in: \n");
                        petNumber = Convert.ToInt32(Console.ReadLine());
                        petMenu = false;
                        break;

                    case "2":
                        petMenu=false;
                        break;
        
                    default:
                        Console.WriteLine("Invalid option, please try again");
                        break;
                }
                

            }


            decimal totalFareWithPets = (room.PricePerNight) + (petNumber*petFare);

                  

            Console.WriteLine($"The chosen room was {room.RoomType}, for {(room.Capacity == 1 ? room.Capacity + " person" : room.Capacity + " people")} " + 
                              $" and costs {totalFareWithPets:C} per night.");
            Console.WriteLine("Press 7 if you are sure of your choice, or chose another one if you want.");

            }
        }

        public void DisplayBookedGuests()
        {
            Console.WriteLine($"There are {Guests.Count} guests staying at the hotel right now.");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        public void CalculateTotal() //GET this done right
        {
            Console.WriteLine("Type the number of nights you have stayed at our hotel: \n");
            BookedDays = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Confirm the number of pets you brought with you");
            int petNumber = Convert.ToInt32(Console.ReadLine());

            decimal petFare = 30M;
            decimal total = BookedDays * (Room.PricePerNight + petNumber*petFare);
            decimal totalAfterDiscount = 0;
            

            if (BookedDays >= 10 )
            {
                totalAfterDiscount = total -(0.10M*total);
                Console.WriteLine($"The total cost of you stay is {totalAfterDiscount:C}");
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
            } else {
                Console.WriteLine($"The total cost of you stay is {total:C}");
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
            }
          
        }
    }
}