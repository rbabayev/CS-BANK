using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankTask
{
    public class BankCard
    {
        public string Pan { get; set; }
        public string Pin { get; set; }
        public string Cvc { get; set; }

        public string Date { get; set; }
        public decimal Balans { get; set; }

        public BankCard(string pan, string pin, string cvc, string date, decimal balans)
        {
            Pan = pan;
            Pin = pin;
            Cvc = cvc;
            Date = date;
            Balans = balans;
        }
    }

    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public BankCard BankCard;

        public User(string name, string surname, BankCard bankCard)
        {
            Name = name;
            Surname = surname;
            BankCard = bankCard;

        }

    }

    public class Bank
    {
        public User[] Clients;
        BankCard Card;

        public Bank()
        {
            Clients = new User[50];

        }

        public void AddUser(User user)
        {
            for (int i = 0; i < Clients.Length; i++)
            {
                if (Clients[i] == null)
                {
                    Clients[i] = user;
                    return;
                }
            }
        }

        public void Welcome(User user, BankCard card)
        {
            for (int i = 0; i < Clients.Length; i++)
            {

                Clients[i] = user;
                Console.WriteLine("Pin daxil edin: ");
                string pin2 = Console.ReadLine();
                Console.Clear();
          
                if (pin2 == card.Pin)
                {

                    Console.WriteLine($"{user.Name} {user.Surname} xos gelmisiniz zehmet olmasa asagidakilardan birini secerdiniz !");
                    Console.WriteLine("1. Balans\n2. Nagd Pul\n3. Karta pul kocurme ");
                    string select = Console.ReadLine();
                    Console.Clear();
                    if (select == "1")
                    {
                        Console.WriteLine($"Balans : {card.Balans} ");
                    }
                    else if (select == "2")
                    {

                        Console.WriteLine($"1. 10 AZN\n2. 20 AZN\n3. 50 AZN\n4. 100 AZN\n5. Istediyiniz mebleg.\nSeciminzi daxil edin (1,2,3,4,5) : ");
                        string selectMoney = Console.ReadLine();
                        Console.Clear();
                        if (selectMoney == "1")
                        {
                            if (card.Balans > 10)
                            {
                                Console.WriteLine($"Balansinzdan 10 AZN cixildi .\nBalans : {card.Balans - 10}");
                                card.Balans -= 10;
                            }
                            else throw new Exception("Balansda yeterli mebleg yoxdur !");
                        }
                        else if (selectMoney == "2")
                        {
                            if (card.Balans > 20)
                            {
                                Console.WriteLine($"Balansinzdan 20 AZN cixildi .\nBalans : {card.Balans - 20}");
                                card.Balans -= 20;
                            }
                            else throw new Exception("Balansda yeterli mebleg yoxdur !");
                        }
                        else if (selectMoney == "3")
                        {
                            if (card.Balans > 50)
                            {
                                Console.WriteLine($"Balansinzdan 50 AZN cixildi .\nBalans : {card.Balans - 50}");
                                card.Balans -= 50;
                            }
                            else throw new Exception("Balansda yeterli mebleg yoxdur !");
                        }
                        else if (selectMoney == "4")
                        {
                            if (card.Balans > 100)
                            {

                                Console.WriteLine($"Balansinzdan 100 AZN cixildi .\nBalans : {card.Balans - 100}");
                                card.Balans -= 100;
                            }
                            else throw new Exception("Balansda yeterli mebleg yoxdur !");
                        }
                        else if (selectMoney == "5")
                        {
                            if (card.Balans > 0)
                            {
                                Console.WriteLine($"Meblegi daxil edin : ");
                                string Monney = Console.ReadLine();
                                int numMoney;

                                if (int.TryParse(Monney, out numMoney))
                                {
                                    if (numMoney < card.Balans)
                                    {
                                        Console.WriteLine($"Balansinzdan {numMoney} AZN cixildi .\nBalans : {card.Balans - numMoney}");
                                        card.Balans -= numMoney;
                                    }
                                    else throw new Exception("Balansda yeterli mebleg yoxdur !");
                                }
                                else
                                {
                                    Console.WriteLine("Reqem daxil edin!");
                                }
                            }
                        }
                    }
                    else if (select == "3")
                    {
                        Console.WriteLine("Kart PIN-ni daxil edin: ");
                        string cardNumber = Console.ReadLine();
                        Console.WriteLine("Gondermek istediyiniz meblegi daxil edin: ");
                        decimal amount = Convert.ToDecimal(Console.ReadLine());

                        bool cardFound = false;
                        foreach (User client in Clients)
                        {
                            if (client != null && client.BankCard.Pan == cardNumber)
                            {
                                client.BankCard.Balans += amount;
                                Console.WriteLine($"{amount} AZN karta kocuruldu!");
                                card.Balans -= amount;
                                cardFound = true;
                                break;
                            }
                        }

                        if (!cardFound)
                        {
                            Console.WriteLine("Kart tapilmadi!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Duzgun secim edin!");
                    }
                }
                else
                {
                    Console.WriteLine("Pin yanlisdir!");
                }

            } 
        
              

        }
        }

    


    public class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
            
             ___   ___   ___   ___   
            | |_) / / \ | |_) / / `  
            |_|_) \_\_/ |_| \ \_\_, 
            
                    B A N K
");

            Console.ResetColor();
            Bank bank = new Bank();

            BankCard card1 = new BankCard("4561 - 6584 - 7894 - 5423", "2003", "456", "06/26", 19250);
            User user1 = new User("Leo", "Messi", card1);

            BankCard card2 = new BankCard("4234 - 3154 - 9537 - 6824", "0707", "651", "10/23", 1);
            User user2 = new User("Ronaldo", "Cris", card2);

            BankCard card3 = new BankCard("5441 - 6845 - 1524 - 9472", "1937", "528", "07/24", 250);
            User user3 = new User("Ali", "Aliyev", card3);

            BankCard card4 = new BankCard("6895 - 3812 - 5286 - 7106", "6813", "958", "02/25", 98765);
            User user4 = new User("Rovshan", "Babayev", card4);

            BankCard card5 = new BankCard("2332 - 1234 - 2030 - 2323", "2323", "230", "12/23", 23);
            User user5 = new User("Amil", "Goycayli", card5);


            bank.AddUser(user1);
            bank.AddUser(user2);
            bank.AddUser(user3);
            bank.AddUser(user4);
            bank.AddUser(user5);

            foreach (User user in bank.Clients)
            {
                if (user != null)
                {
                    bank.Welcome(user, user.BankCard);
                    Console.WriteLine();
                }
            }

        }
    }



}
