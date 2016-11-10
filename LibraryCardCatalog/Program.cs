using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.Data;
using System.Runtime.Serialization.Formatters;


namespace LibraryCardCatalog
{
    [DataContract]
    public class Program
    {

        [DataMember]
        int a;

        [DataMember]
        string book;
        [DataMember]
        string happyness;

        static void Main(string[] args)
        {
            string catalogName = "thecatalog";
            string openingOption;
            int choice;
            bool keepGoing = true; 
            string stringChoice;
            string bookTitle;
            string bookAuthor;
            string bookSubject;


            //  Book[] allBooks;

            CardCatalog MainCatalog = new CardCatalog();

            List<Book> BookList = new List<Book>();
            
            Console.WriteLine("Do you want to open a catalog or do you want to create a new one? (type 'new' or 'open')");
           openingOption = Console.ReadLine();

            if (openingOption == "new")
            {
                Console.WriteLine("Type the name of the Book Catalog:");
                catalogName = Console.ReadLine();


               // Program theProgram = new Program();
              //  theProgram.happyness = "Singing";
            

            }

            if(openingOption == "open")
            {

                Console.WriteLine("Enter the catalog name correctly: ");
                catalogName = Console.ReadLine();

                DataContractSerializer ds = new DataContractSerializer(typeof(CardCatalog));
                FileStream fs = new FileStream(catalogName + ".xml", FileMode.Open);
                XmlDictionaryReader reader =
                    XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
               MainCatalog = (CardCatalog)ds.ReadObject(reader);
                reader.Close();

           

                //  currentScreen = OpeningMainScreen;
            }

            do
            {


                Console.WriteLine("1. List All Books");
                Console.WriteLine("2. Add A Book");
                Console.WriteLine("3. Save and Exit");

                Console.WriteLine("Choose One of these by pressing the number and enter:");
                stringChoice = Console.ReadLine();
                choice = Convert.ToInt32(stringChoice);


                if (choice == 1)
                {

                   BookList =  MainCatalog.BookListHolder;
                    int i = 1;
                    foreach (Book loopVar in BookList)
                    {
                        Console.WriteLine("Book {0}", i);
                        i++;
                        Console.WriteLine("Book Title: {0}", loopVar.title);
                        Console.WriteLine("Book Subject: {0}", loopVar.subject);
                        Console.WriteLine("Book Author: {0}", loopVar.author);
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("What is the book title?");
                    bookTitle = Console.ReadLine();

                    Console.WriteLine("Who is the author of the book?");
                    bookAuthor = Console.ReadLine();

                    Console.WriteLine("What is the subject of the book?");
                    bookSubject = Console.ReadLine();

                    BookList.Add(new Book() { title = bookTitle, author = bookTitle, subject = bookSubject });

                }
                else if (choice == 3)
                {

                    MainCatalog.BookListHolder = BookList;
                    MainCatalog.filename = catalogName;

                    var writer = new FileStream(catalogName + ".xml", FileMode.Create);
                    DataContractSerializer ser = new DataContractSerializer(typeof(CardCatalog));
                    ser.WriteObject(writer, MainCatalog);
                    writer.Close();
                    keepGoing = false;
                }
            } while (keepGoing == true);

            //Program theProgram = new Program();
            //theProgram.happyness = "Singing";
            //var writer = new FileStream(theProgram.happyness + ".xml", FileMode.Create);
            //DataContractSerializer ser = new DataContractSerializer(typeof(Program));
            //ser.WriteObject(writer, theProgram);
            //writer.Close();
        }




    }
  
    [DataContract]
    public class CardCatalog
    {
        [DataMember]      
        public List<Book> BookListHolder = new List<Book>();

        [DataMember]
        public string filename;

      //  private Book books;

        public void CatalogMenu()
        {

        }
    }
 }       


    //[OnDeserializing]
    //public void PlayVideoStateDeserialization(StreamingContext context)



