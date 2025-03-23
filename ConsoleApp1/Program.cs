namespace ConsoleApp1
{
    class Program
    {
        static List<ContainerShip> ships = new List<ContainerShip>();
        static List<Container> containers = new List<Container>();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                DisplayMainScreen();
                Console.Write("Wybierz opcję: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddContainerShip();
                        break;
                    case "2":
                        RemoveContainerShip();
                        break;
                    case "3":
                        AddContainer();
                        break;
                    case "4":
                        LoadContainerOntoShip();
                        break;
                    case "5":
                        LoadContainersListOntoShip();
                        break;
                    case "6":
                        RemoveContainerFromShip();
                        break;
                    case "7":
                        UnloadContainer();
                        break;
                    case "8":
                        ReplaceContainerOnShip();
                        break;
                    case "9":
                        TransferContainerBetweenShips();
                        break;
                    case "10":
                        PrintContainerInfo();
                        break;
                    case "11":
                        PrintShipInfo();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Nieznana opcja. Naciśnij dowolny klawisz.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void DisplayMainScreen()
        {
            Console.WriteLine("=== Lista kontenerowców ===");
            if (ships.Count == 0)
            {
                Console.WriteLine("Brak");
            }
            else
            {
                int i = 1;
                foreach (var ship in ships)
                {
                    Console.WriteLine($"{i}. {ship.ToString()}");
                    i++;
                }
            }

            Console.WriteLine("\n=== Lista kontenerów ===");
            if (containers.Count == 0)
            {
                Console.WriteLine("Brak");
            }
            else
            {
                int i = 1;
                foreach (var container in containers)
                {
                    Console.WriteLine($"{i}. {container.ToString()}");
                    i++;
                }
            }

            Console.WriteLine("\n=== Możliwe akcje ===");
            Console.WriteLine("1. Dodaj kontenerowiec");
            Console.WriteLine("2. Usuń kontenerowiec");
            Console.WriteLine("3. Dodaj kontener");
            Console.WriteLine("4. Załaduj kontener na statek");
            Console.WriteLine("5. Załaduj listę kontenerów na statek");
            Console.WriteLine("6. Usuń kontener ze statku");
            Console.WriteLine("7. Rozładuj kontener");
            Console.WriteLine("8. Zastąp kontener na statku");
            Console.WriteLine("9. Przenieś kontener między statkami");
            Console.WriteLine("10. Wypisz informacje o kontenerze");
            Console.WriteLine("11. Wypisz informacje o statku i jego ładunku");
            Console.WriteLine("0. Wyjście");
            Console.WriteLine();
        }

        // 1. Dodaj kontenerowiec
        static void AddContainerShip()
        {
            try
            {
                Console.Write("Podaj maksymalną prędkość (w węzłach): ");
                double speed = double.Parse(Console.ReadLine());
                Console.Write("Podaj maksymalną liczbę kontenerów: ");
                int maxCount = int.Parse(Console.ReadLine());
                Console.Write("Podaj maksymalną wagę kontenerów (w tonach): ");
                double maxWeight = double.Parse(Console.ReadLine());

                ContainerShip ship = new ContainerShip(speed, maxWeight, maxCount);
                ships.Add(ship);
                Console.WriteLine("Kontenerowiec dodany. Naciśnij dowolny klawisz...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd przy dodawaniu kontenerowca: " + ex.Message);
            }
            Console.ReadKey();
        }

        // 2. Usuń kontenerowiec
        static void RemoveContainerShip()
        {
            try
            {
                Console.Write("Podaj numer statku do usunięcia (indeks, zaczynając od 1): ");
                int index = int.Parse(Console.ReadLine());
                if (index < 1 || index > ships.Count)
                {
                    Console.WriteLine("Nieprawidłowy numer statku.");
                }
                else
                {
                    ships.RemoveAt(index - 1);
                    Console.WriteLine("Kontenerowiec usunięty.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd: " + ex.Message);
            }
            Console.ReadKey();
        }

        // 3. Dodaj kontener
static void 
    AddContainer()
{
    try
    {
        Console.WriteLine("Wybierz typ kontenera:");
        Console.WriteLine("1. Kontener Chłodniczy");
        Console.WriteLine("2. Kontener na Gaz");
        Console.WriteLine("3. Kontener na Płyny");
        string choice = Console.ReadLine();

        Container newContainer = null;
        
        // Wspólne parametry
        Console.Write("Podaj aktualny ładunek (kg): ");
        double currentLoad = double.Parse(Console.ReadLine());
        Console.Write("Podaj wysokość (cm): ");
        double height = double.Parse(Console.ReadLine());
        Console.Write("Podaj wagę kontenera (kg): ");
        double containerWeight = double.Parse(Console.ReadLine());
        Console.Write("Podaj głębokość (cm): ");
        double depth = double.Parse(Console.ReadLine());
        Console.Write("Podaj maksymalną ładowność (kg): ");
        double maxLoad = double.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1": // Kontener Chłodniczy
                Console.Write("Podaj aktualną temperaturę (°C): ");
                double temperature = double.Parse(Console.ReadLine());
                Console.Write("Podaj typ produktu (np. Cheese, Meat, IceCream): ");
                string productStr = Console.ReadLine();
                if (!Enum.TryParse<ProductType>(productStr, out ProductType product))
                {
                    Console.WriteLine("Nieprawidłowy typ produktu.");
                    Console.ReadKey();
                    return;
                }
                newContainer = new RefrigeratedContainer(currentLoad, height, containerWeight, depth, maxLoad, temperature, product);
                break;
            case "2": // Kontener na Gaz
                Console.Write("Podaj ciśnienie (w atmosferach): ");
                double pressure = double.Parse(Console.ReadLine());
                newContainer = new GasContainer(currentLoad, height, containerWeight, depth, maxLoad, pressure);
                break;
            case "3": // Kontener na Płyny
                Console.Write("Czy ładunek jest niebezpieczny? (true/false): ");
                bool isHazardous = bool.Parse(Console.ReadLine());
                newContainer = new LiquidContainer(currentLoad, height, containerWeight, depth, maxLoad, isHazardous);
                break;
            default:
                Console.WriteLine("Nieprawidłowy wybór.");
                Console.ReadKey();
                return;
        }
        
        containers.Add(newContainer);
        Console.WriteLine($"Kontener {newContainer.serialNumber} został dodany.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Błąd przy dodawaniu kontenera: " + ex.Message);
    }
    Console.ReadKey();
}


        // 4. Załaduj kontener na statek
        static void LoadContainerOntoShip()
        {
            try
            {
                Console.Write("Podaj numer statku (indeks, zaczynając od 1): ");
                int shipIndex = int.Parse(Console.ReadLine());
                Console.Write("Podaj numer kontenera (indeks, zaczynając od 1): ");
                int containerIndex = int.Parse(Console.ReadLine());
                if (shipIndex < 1 || shipIndex > ships.Count || containerIndex < 1 || containerIndex > containers.Count)
                {
                    Console.WriteLine("Nieprawidłowy numer statku lub kontenera.");
                }
                else
                {
                    ContainerShip ship = ships[shipIndex - 1];
                    Container container = containers[containerIndex - 1];
                    ship.AddContainer(container);
                    Console.WriteLine("Kontener załadowany na statek.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd: " + ex.Message);
            }
            Console.ReadKey();
        }

        // 5. Załaduj listę kontenerów na statek
        static void LoadContainersListOntoShip()
        {
            try
            {
                Console.Write("Podaj numer statku (indeks, zaczynając od 1): ");
                int shipIndex = int.Parse(Console.ReadLine());
                if (shipIndex < 1 || shipIndex > ships.Count)
                {
                    Console.WriteLine("Nieprawidłowy numer statku.");
                }
                else
                {
                    ContainerShip ship = ships[shipIndex - 1];
                    // Próbujemy załadować wszystkie kontenery, które są w liście "containers"
                    ship.AddContainers(new List<Container>(containers));
                    Console.WriteLine("Lista kontenerów załadowana na statek.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd: " + ex.Message);
            }
            Console.ReadKey();
        }

        // 6. Usuń kontener ze statku
        static void RemoveContainerFromShip()
        {
            try
            {
                Console.Write("Podaj numer statku (indeks, zaczynając od 1): ");
                int shipIndex = int.Parse(Console.ReadLine());
                Console.Write("Podaj numer kontenera (numer seryjny) do usunięcia: ");
                string serial = Console.ReadLine();
                if (shipIndex < 1 || shipIndex > ships.Count)
                {
                    Console.WriteLine("Nieprawidłowy numer statku.");
                }
                else
                {
                    ContainerShip ship = ships[shipIndex - 1];
                    ship.RemoveContainer(serial);
                    Console.WriteLine("Kontener usunięty ze statku.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd: " + ex.Message);
            }
            Console.ReadKey();
        }

        // 7. Rozładuj kontener
        static void UnloadContainer()
        {
            try
            {
                Console.Write("Podaj numer kontenera (indeks, zaczynając od 1): ");
                int containerIndex = int.Parse(Console.ReadLine());
                if (containerIndex < 1 || containerIndex > containers.Count)
                {
                    Console.WriteLine("Nieprawidłowy numer kontenera.");
                }
                else
                {
                    containers[containerIndex - 1].UnloadContainer();
                    Console.WriteLine("Kontener rozładowany.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd: " + ex.Message);
            }
            Console.ReadKey();
        }

        // 8. Zastąp kontener na statku
        static void ReplaceContainerOnShip()
        {
            try
            {
                Console.Write("Podaj numer statku (indeks, zaczynając od 1): ");
                int shipIndex = int.Parse(Console.ReadLine());
                Console.Write("Podaj numer kontenera do zastąpienia (numer seryjny): ");
                string oldSerial = Console.ReadLine();
                Console.WriteLine("Podaj dane nowego kontenera:");
                Console.Write("Typ produktu: ");
                string productStr = Console.ReadLine();
                if (!Enum.TryParse<ProductType>(productStr, out ProductType product))
                {
                    Console.WriteLine("Nieprawidłowy typ produktu.");
                    Console.ReadKey();
                    return;
                }
                Console.Write("Podaj aktualny ładunek (kg): ");
                double currentLoad = double.Parse(Console.ReadLine());
                Console.Write("Podaj wysokość (cm): ");
                double height = double.Parse(Console.ReadLine());
                Console.Write("Podaj wagę kontenera (kg): ");
                double containerWeight = double.Parse(Console.ReadLine());
                Console.Write("Podaj głębokość (cm): ");
                double depth = double.Parse(Console.ReadLine());
                Console.Write("Podaj maksymalną ładowność (kg): ");
                double maxLoad = double.Parse(Console.ReadLine());
                Console.Write("Podaj aktualną temperaturę (°C): ");
                double temperature = double.Parse(Console.ReadLine());

                RefrigeratedContainer newContainer = new RefrigeratedContainer(currentLoad, height, containerWeight, depth, maxLoad, temperature, product);

                if (shipIndex < 1 || shipIndex > ships.Count)
                {
                    Console.WriteLine("Nieprawidłowy numer statku.");
                }
                else
                {
                    ContainerShip ship = ships[shipIndex - 1];
                    ship.ReplaceContainer(oldSerial, newContainer);
                    Console.WriteLine("Kontener zastąpiony.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd: " + ex.Message);
            }
            Console.ReadKey();
        }

        // 9. Przenieś kontener między statkami
        static void TransferContainerBetweenShips()
        {
            try
            {
                Console.Write("Podaj numer statku źródłowego (indeks, zaczynając od 1): ");
                int sourceIndex = int.Parse(Console.ReadLine());
                Console.Write("Podaj numer statku docelowego (indeks, zaczynając od 1): ");
                int targetIndex = int.Parse(Console.ReadLine());
                Console.Write("Podaj numer kontenera (numer seryjny) do przeniesienia: ");
                string serial = Console.ReadLine();

                if (sourceIndex < 1 || sourceIndex > ships.Count || targetIndex < 1 || targetIndex > ships.Count)
                {
                    Console.WriteLine("Nieprawidłowy numer statku.");
                }
                else
                {
                    ContainerShip sourceShip = ships[sourceIndex - 1];
                    ContainerShip targetShip = ships[targetIndex - 1];
                    sourceShip.TransferContainer(targetShip, serial);
                    Console.WriteLine("Kontener przeniesiony.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd: " + ex.Message);
            }
            Console.ReadKey();
        }

        // 10. Wypisz informacje o kontenerze
        static void PrintContainerInfo()
        {
            try
            {
                Console.Write("Podaj numer kontenera (indeks, zaczynając od 1): ");
                int containerIndex = int.Parse(Console.ReadLine());
                if (containerIndex < 1 || containerIndex > containers.Count)
                {
                    Console.WriteLine("Nieprawidłowy numer kontenera.");
                }
                else
                {
                    Console.WriteLine(containers[containerIndex - 1].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd: " + ex.Message);
            }
            Console.ReadKey();
        }

        // 11. Wypisz informacje o statku i jego ładunku
        static void PrintShipInfo()
        {
            try
            {
                Console.Write("Podaj numer statku (indeks, zaczynając od 1): ");
                int shipIndex = int.Parse(Console.ReadLine());
                if (shipIndex < 1 || shipIndex > ships.Count)
                {
                    Console.WriteLine("Nieprawidłowy numer statku.");
                }
                else
                {
                    var ship = ships[shipIndex - 1];
                    Console.WriteLine(ship.ToString());
                    Console.WriteLine("\nKontenery na statku:");
                    if (ship.Containers.Count == 0)
                    {
                        Console.WriteLine("Brak kontenerów.");
                    }
                    else
                    {
                        int i = 1;
                        foreach (var container in ship.Containers)
                        {
                            Console.WriteLine($"{i}. {container.ToString()}");
                            i++;
                        }
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd: " + ex.Message);
            }
            Console.ReadKey();
        }

    }
}
