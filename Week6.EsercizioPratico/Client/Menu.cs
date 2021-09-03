using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EsercizioPratico.Core.Models;
using Week6.EsercizioPratico.EF.Repositories;

namespace Week6.EsercizioPratico.Client
{
    public class Menu
    {
        private static MainBL mainBL = new MainBL(new EFCustomerRepository(), new EFPolicyRepository());

        internal static void Start()
        {
            Console.WriteLine("°°°°Benvenuto!°°°°");

            char choice;

            do
            {
                Console.WriteLine("Premi 1 per inserire un nuovo cliente");
                Console.WriteLine("Premi 2 per inserire una polizza per un cliente già esistente");
                Console.WriteLine("Premi 3 per visualizzare le polizze di un cliente");
                Console.WriteLine("Premi 4 per posticipare la data di scadenza");

                Console.WriteLine("Premi 0 per uscire");

                choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        //Inserisci nuovo cliente
                        InsertCustomer();
                        break;
                    case '2':
                        //Inserire polizza per un cliente esistente
                        InserPolicy();
                        break;
                    case '3':
                        //Visualizza polizze
                        ShowPolicy();
                        break;
                    case '4':
                        //Posticipa scadenza

                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Scelta non disponibile");
                        break;
                }
            }
            while (!(choice == '0'));
        }

        private static void ShowPolicy()
        {
            var policies = mainBL.FetchPolicies();

            if (policies.Count != 0)
            {
                Console.WriteLine("Polizze presenti");
                foreach (var p in policies)
                {
                    Console.WriteLine($"Numero Polizza: {p.NPolicy} Data di scadenza: {p.Expiration} " +
                        $"Rata Mensile: {p.MonthlyPayment} Tipo di polizza {p.Type}");
                }
            }
            else
            {
                Console.WriteLine("\nNon sono presenti polizze");
            }
        }

        private static void InserPolicy()
        {

            Console.WriteLine("Inserimento di una polizza per un cliente");
            string code = InsertCF();
            Customer customer = mainBL.GetCustomerByCF(code);
            if(customer != null)
            {
                Policy newPolicy = new Policy
                {
                    NPolicy = InsertNPolicy(),
                    Expiration = InsertExpiration(),
                    MonthlyPayment = InserMonthlyPayment(),
                    Type = ChoosePolicy(),
                    CoustomerId = customer.Id
                };


                bool isAdded = mainBL.AddP(newPolicy);

                if (isAdded)
                    Console.WriteLine("Cliente inserito con successo");
                else
                    Console.WriteLine("Si è verificato un problema");

            }
            else
            {
                Console.WriteLine("Il seguente codice fiscale non è presente");
            }
           

        }

        private static decimal InserMonthlyPayment()
        {
            bool isInt;
            decimal payment;
            do
            {
                Console.WriteLine("Inserisci rata mensile");

                isInt = decimal.TryParse(Console.ReadLine(), out payment);

            } while (!isInt);

            return payment;
        }

        private static int InsertNPolicy()
        {
            bool isInt;
            int nPolicy;
            do
            {
                Console.WriteLine("Inserisci il numero di polizza");

                isInt = int.TryParse(Console.ReadLine(), out nPolicy);

            } while (!isInt);

            return nPolicy;
        }

        private static DateTime InsertExpiration()
        {
            Console.WriteLine("Inserisci una data di scadenza futura (mm - gg - yyyy)");
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date) || date < DateTime.Today)
            {
                Console.WriteLine("Riprova! Data non valida");
            }
            return date;
        }

        private static string InsertCF()
        {
            string cf = String.Empty;
            
                do
                {
                    Console.WriteLine("Inserisci il Codice Fiscale");
                    cf = Console.ReadLine();

                } while (String.IsNullOrEmpty(cf) || cf.Length != 16);

            return cf;
        }

        private static TypeEnum ChoosePolicy()
        {
            Console.WriteLine("Segli il tipo di polizza che vuoi assegnare");
            Console.ReadLine();

            bool isInt;
            int choose;
            do
            {
                Console.WriteLine($"Premi {(int)TypeEnum.RCAuto} per scegliere la polizza RCAuto");
                Console.WriteLine($"Premi {(int)TypeEnum.Theft} per scegliere la polizza Furto");
                Console.WriteLine($"Premi {(int)TypeEnum.Life} per scegliere la polizza Vita");

                isInt = int.TryParse(Console.ReadLine(), out choose);
            } while (!isInt || choose < 0 || choose > 3);

            return (TypeEnum)choose;
        }

        private static void ShowCustomer()
        {
            var customers = mainBL.FetchCustomers();

            if (customers.Count != 0)
            {
                Console.WriteLine("Utenti presenti:");
                foreach (var c in customers)
                {
                    Console.WriteLine($"CF:\n {c.CF} Nome:\n {c.FirstName} Cognome:\n {c.LastName}");
                }
            }
            else
            {
                Console.WriteLine("\nNon sono presenti utenti");
            }

        }

        private static void InsertCustomer()
        {
            string firstname, lastname, cf;

            do
            {
                Console.Write("\nInserisci il Nome:\n");
                firstname = Console.ReadLine();
            }
            while (firstname.Length == 0 || firstname.Length > 30);

            do
            {
                Console.Write("Inserisci il Cognome:\n");
                lastname = Console.ReadLine();
            }
            while (lastname.Length == 0 || lastname.Length > 20);

            do
            {
                Console.Write("Inserisci il Codice Fiscale:\n");
                cf = Console.ReadLine();
            }
            while (cf.Length != 16);

            

            Customer newCustomer = new Customer
            {
                CF = cf,
                FirstName = firstname,
                LastName = lastname,
                
            };

            bool isAdded = mainBL.AddC(newCustomer);

            if (isAdded)
                Console.WriteLine("Cliente inserito con successo");
            else
                Console.WriteLine("Si è verificato un problema");

        }
    }
}
