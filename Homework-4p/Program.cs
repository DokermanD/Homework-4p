namespace Homework_4p
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(
                    "Для вывода всех таблиц в консоль введите - Show \n"+
                    "Для ввода данных в таблицу введите номер таблицы:\n1 - Users\n2 - ProductsSale\n3 - ChatBuyer\n"+
                    "Для ВЫХОДА введите EX");

                var comand = Console.ReadLine().ToLower();
                try
                {
                    switch (comand)
                    {
                        case "show":
                            ShowDataTable();
                            break;
                        case "1":
                            Console.WriteLine("Введите пожлалуйста в таком порядке через (,) данные для добавления:\nLastName, FirstName, Phone, Email");
                            var strAddUsers = Console.ReadLine();

                            SetDataTable("1", strAddUsers.Split(',')[0], strAddUsers.Split(',')[1], strAddUsers.Split(',')[2], strAddUsers.Split(',')[3]);
                            Console.WriteLine(
                                "****************************************\n" +
                                "Данные успешно добавлены в таблицу Users");

                            break;
                        case "2":
                            Console.WriteLine("Введите пожлалуйста в таком порядке через (,) данные для добавления:\nProductName, ProductPrace, FkUserId");
                            var strAddProductsSale = Console.ReadLine();

                            SetDataTable("2", strAddProductsSale.Split(',')[0], strAddProductsSale.Split(',')[1], strAddProductsSale.Split(',')[2]);
                            Console.WriteLine(
                                "***********************************************\n" +
                                "Данные успешно добавлены в таблицу ProductsSale");
                            break;
                        case "3":
                            Console.WriteLine("Введите пожлалуйста в таком порядке через (,) данные для добавления:\nFkProductId, MessageChat");
                            var strAddChatBuyer = Console.ReadLine();

                            SetDataTable("3", strAddChatBuyer.Split(',')[0], strAddChatBuyer.Split(',')[1]);
                            Console.WriteLine(
                                "********************************************\n" +
                                "Данные успешно добавлены в таблицу ChatBuyer");
                            break;
                        case "ex":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine(
                                "*************************************\n"+
                                "* Вы ввели не существующую команду! *\n"+
                                "*************************************");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(
                        "**********************************************************************\n"+
                        "*Были введены не коректные данные для добавления, попробуйте ещё раз!*\n"+
                        "**********************************************************************");
                }
                
            }
           
            void SetDataTable(params string[] par )
            {
                switch (par[0])
                {
                    case "1":
                        using (AvitoContext db = new AvitoContext())
                        {
                            User D1 = new User { LastName = par[1], FirstName = par[2], Phone = par[3], Email = par[4] };
                            db.Users.Add(D1);
                            db.SaveChanges();
                        }
                        break;

                    case "2":
                        using (AvitoContext db = new AvitoContext())
                        {
                            ProductsSale D2 = new ProductsSale { ProductName = par[1], ProductPrace = Convert.ToInt32(par[2].Replace(" ","")), FkUserId = Convert.ToInt32(par[3]) };
                            db.ProductsSales.Add(D2);
                            db.SaveChanges();
                        }
                        break;

                    case "3":
                        using (AvitoContext db = new AvitoContext())
                        {
                            ChatBuyer D3 = new ChatBuyer { FkProductId = Convert.ToInt32(par[1]), MessageChat = par[2] };
                            db.ChatBuyers.Add(D3);
                            db.SaveChanges();
                        }
                        break;

                    default:
                        Console.WriteLine(
                            "*************************************\n"+
                            "* Вы ввели не существующую таблицу! *\n"+
                            "******* выберите 1 - 2 или 3 ********\n"+
                            "*************************************");
                        break;
                }
               
            }


            //Вывод всез таблиц в консоль
            void ShowDataTable()
            {
                using (AvitoContext db = new AvitoContext())
                {
                    var users = db.Users.ToList();
                    Console.WriteLine("Таблица User:\n------------------------");
                    Console.WriteLine($" UserId | FirstName | LastName | Phone | Email");
                    foreach (var user in users)
                    {
                        Console.WriteLine($"{user.UserId} | {user.FirstName} | {user.LastName} | {user.Phone} | {user.Email}");
                    }
                    Console.WriteLine();
                }

                using (AvitoContext db = new AvitoContext())
                {
                    var users = db.ProductsSales.ToList();
                    Console.WriteLine("Таблица ProductsSales:\n------------------------");
                    Console.WriteLine($" ProductId | ProductName | ProductPrace | FkUserId");
                    foreach (var user in users)
                    {
                        Console.WriteLine($"{user.ProductId} | {user.ProductName} | {user.ProductPrace} | {user.FkUserId}");
                    }
                    Console.WriteLine();
                }

                using (AvitoContext db = new AvitoContext())
                {
                    var users = db.ChatBuyers.ToList();
                    Console.WriteLine("Таблица ChatBuyers:\n------------------------");

                    Console.WriteLine($" BuyerId | FkProductId | MessageChat ");
                    foreach (var user in users)
                    {
                        Console.WriteLine($"{user.BuyerId} | {user.FkProductId} | {user.MessageChat}");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}