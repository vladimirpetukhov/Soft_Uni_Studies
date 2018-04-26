namespace _08.PetClinic
{
    using System;
    using System.Linq;

    public class Clinic
    {
        private int numberOfRooms;
        private readonly RoomsRegister roomsRegister;

        public Clinic(string name, int numberOfRooms)
        {
            this.Name = name;
            this.NumberOfRooms = numberOfRooms;
            this.roomsRegister = new RoomsRegister(numberOfRooms);
        }

        public string Name { get; }

        private int NumberOfRooms
        {
            get => this.numberOfRooms;
            set
            {
                if (value % 2 == 0)
                {
                    throw new ArgumentException("Invalid Operation!");
                }
                this.numberOfRooms = value;
            }
        }

        public bool TryAddPet(Pet pet)
        {
            foreach (var roomIndex in this.roomsRegister)
            {
                if (this.roomsRegister[roomIndex] != null) continue;
                this.roomsRegister[roomIndex] = pet;
                return true;
            }
            return false;
        }

        public bool TryReleasePet()
        {
            var centralRoomIndex = this.NumberOfRooms / 2;

            for (int i = 0; i < this.NumberOfRooms; i++)
            {
                var currentIndex = (centralRoomIndex + i) % this.NumberOfRooms;
                if (this.roomsRegister[currentIndex] == null) continue;
                this.roomsRegister[currentIndex] = null;
                return true;
            }
            return false;
        }

        public bool HasEmptyRooms()
        {
            return this.roomsRegister.Any(i => this.roomsRegister[i] == null);
        }

        public void PrintRoom(int index)
        {
            var room = this.roomsRegister[index];
            Console.WriteLine(room == null ? "Room empty" : room.ToString());
        }

        public void PrintAllRooms()
        {
            for (int i = 0; i < this.NumberOfRooms; i++)
            {
                this.PrintRoom(i);
            }
        }
    }
}
