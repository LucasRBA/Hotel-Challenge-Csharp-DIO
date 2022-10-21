namespace DesafioProjetoHospedagem.Models
{
    public class Room
    {
        public Room() { }

        public Room(string roomType, int capacity, decimal pricePerNight)
        {
            RoomType = roomType;
            Capacity = capacity;
            PricePerNight = pricePerNight;
        }

        public string RoomType { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
    }
}