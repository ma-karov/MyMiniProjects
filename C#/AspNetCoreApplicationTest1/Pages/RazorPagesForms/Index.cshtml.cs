
using Db4objects.Db4o.Internal;

namespace AspNetCoreApplicationTest1.Pages.RazorPagesForms 
{ 
//    [ModelValidation.Infrastructure.NoVasyaOnMonday]
    public class PrintQueryCassandraForm : Microsoft.AspNetCore.Mvc.RazorPages.PageModel 
    { 
        const System.String DIR_DATABASES_FOR_CLASSES = "CustomFiles/ExtensionsUser/Files/DataBaseS_ForClasses/";
 
        public readonly RecordStructBooks []ArrayBooks; 
        public readonly RecordStructAuthors []ArrayAuthors; 
        public readonly RecordStructCategories []ArrayCategories; 
        public readonly RecordStructReviews []ArrayReviews; 

        public Microsoft.AspNetCore.Mvc.Rendering.SelectList SelectListItems; 

        [Microsoft.AspNetCore.Mvc.BindProperty] public RecordClassTable []TableRecords { get; set; } 
        [Microsoft.AspNetCore.Mvc.BindProperty] public System.UInt32 SwitchID { get; set; }  
        
        //private readonly Cassandra.ICluster CassandraCluster; 

        public PrintQueryCassandraForm()
        { 
            SelectListItems = new Microsoft.AspNetCore.Mvc.Rendering.SelectList( 
                new RecordClassTable[10]
                {
                    new RecordClassTable("1", "1 Выборка данных о книгах конкретного автора "), 
                    new RecordClassTable("2", "2 Выборка отзывов о книгах с рейтингом выше заданного уровня. "), 
                    new RecordClassTable("3", "3 Вывод названий книг, цены которых находятся в заданном диапазоне "), 
                    new RecordClassTable("4", "4 Выборка книг, выпущенных в конкретном году"), 
                    new RecordClassTable("5", "5 Наиболее популярные категории книг на основе количества книг в каждой категории "), 
                    new RecordClassTable("6", "6 Общее количество отзывов для каждой книги "), 
                    new RecordClassTable("7", "7 Список книг, отсортированный в порядке убывания рейтинга "), 
                    new RecordClassTable("8", "8 Выбор книг, для которых нет отзывов "), 
                    new RecordClassTable("9", "9 Список авторов вместе с общим числом написанных ими книг "), 
                    new RecordClassTable("10", "10 Для каждой категории выведите книгу с наивысшим рейтингом")
                }, 
                "ID", "Description"
            );

            TableRecords = new RecordClassTable[0];

            Cassandra.ICluster CassandraCluster = Cassandra.Cluster.Builder().AddContactPoints("localhost").WithPort(9042).Build(); 
            Cassandra.ISession NewISession = CassandraCluster.Connect(); 

            ArrayBooks = NewISession.Execute("Select * From BookStore.Books Allow FILTERING; ").Select<Cassandra.Row, RecordStructBooks>(Book => new RecordStructBooks(System.UInt32.Parse(Book["id"] + ""), Book["title"] + "", System.UInt32.Parse(Book["authorid"] + ""), Book["categoryname"] + "", System.UInt16.Parse(Book["price"] + ""), System.UInt16.Parse(Book["createyear"] + "") ) ).ToArray<RecordStructBooks>();
            
            ArrayAuthors = NewISession.Execute("Select * From BookStore.Authors Allow FILTERING; ").Select<Cassandra.Row, RecordStructAuthors>(Author => new RecordStructAuthors(System.UInt32.Parse(Author["id"] + ""), Author["name"] + "")).ToArray<RecordStructAuthors>(); 

            ArrayCategories = NewISession.Execute("Select * From BookStore.Categories Allow FILTERING; ").Select<Cassandra.Row, RecordStructCategories>(Category => new RecordStructCategories(System.UInt32.Parse(Category["id"] + ""), Category["categoryname"] + "", Category["description"] + "")).ToArray<RecordStructCategories>(); 
            
            ArrayReviews = NewISession.Execute("Select * From BookStore.Reviews Allow FILTERING; ").Select<Cassandra.Row, RecordStructReviews>(Review => new RecordStructReviews(System.UInt32.Parse(Review["id"] + ""), System.Single.Parse(Review["raiting"] + ""), Review["description"] + "", System.UInt32.Parse(Review["bookid"] + ""), System.UInt32.Parse(Review["userid"] + ""))).ToArray<RecordStructReviews>(); 
            
            NewISession.Dispose(); CassandraCluster.Dispose(); 


            Db4objects.Db4o.IObjectContainer DB4Objects = Db4objects.Db4o.Db4oFactory.OpenFile(DIR_DATABASES_FOR_CLASSES + "Category.data");

            DB4Objects.Store(new RecordClassCategories(ArrayCategories[0].ID, ArrayCategories[0].Name, ArrayCategories[0].Description));
            DB4Objects.Store(new RecordClassCategories(ArrayCategories[1].ID, ArrayCategories[1].Name, ArrayCategories[1].Description)); 

            DB4Objects.Set(new RecordClassBooks(ID: ArrayBooks[0].ID, Title: ArrayBooks[0].Title, AuthorID: ArrayBooks[0].AuthorID, CategoryName: ArrayBooks[0].CategoryName, Price: ArrayBooks[0].Price)); 
            DB4Objects.Set(new RecordClassBooks(ID: ArrayBooks[1].ID, Title: ArrayBooks[1].Title, AuthorID: ArrayBooks[1].AuthorID, CategoryName: ArrayBooks[1].CategoryName, Price: ArrayBooks[1].Price)); 
            //DB4Objects.Commit(); 

            //DB4Objects.Delete(DB4Objects.Query<RecordClassBooks>((RecordClassBooks Book) => Book.ID == 1).First()); 
            //DB4Objects.Delete(DB4Objects.Query<RecordClassBooks>((RecordClassBooks Book) => Book.ID == 2).First()); 
            DB4Objects.Commit(); 


            //DB4Objects.Ext().Configure().ObjectClass(ArrayBooks[0]).ObjectField("id").Indexed(true); 

            foreach (RecordClassCategories Category in DB4Objects.Query<RecordClassCategories>().OrderByDescending((RecordClassCategories Category) => Category.ID)) // (RecordStructCategories Category) => Category.ID == 1)
                System.Console.WriteLine(Category); 

            System.Console.WriteLine("=============================="); 

            //DB4Objects.Delete(DB4Objects.Get( new RecordStructCategories() { ID = 1 } )[0]); 
            //DB4Objects.Delete(DB4Objects.Get( new RecordStructCategories() { ID = 2 } )[0]); 

            //RecordClassCategories NewCategory = DB4Objects.Query((RecordClassCategories Category) => Category.ID == 3).First(); 
            //NewCategory.ID = 1; 
            //DB4Objects.Set(NewCategory); 

            //DB4Objects.Delete(DB4Objects.Query<RecordStructCategories>((RecordStructCategories Category) => Category.ID == 3)[0]); 


            /*Db4objects.Db4o.IObjectSet result = db.QueryByExample(new RecordStructCategories(ID: 0, Name: null, Description: null));
            while (result.HasNext())
            {
                RecordStructCategories next = (RecordStructCategories) result.Next();
                Console.WriteLine(next.ToString());
            }*/ 

            System.Console.WriteLine("BOOKS "); 
            foreach (RecordClassBooks Book in DB4Objects.Query<RecordClassBooks>())
                System.Console.WriteLine(Book); 

            System.Console.WriteLine("=============================="); 
            System.Console.WriteLine("CATEGORIES "); 
            foreach (RecordClassCategories Category in DB4Objects.Query<RecordClassCategories>())
                System.Console.WriteLine(Category); 

            System.Console.WriteLine("=============================="); 
            System.Console.WriteLine("CATEGORIES "); 
            foreach (RecordClassCategories Category in DB4Objects.Query<RecordClassCategories>((RecordClassCategories Category) => Category.Name == "Fiction"))
                System.Console.WriteLine(Category); 

            System.Console.WriteLine("=============================="); 
            System.Console.WriteLine("CATEGORIES INCLUDE BOOKS "); 
            foreach (RecordClassCategories Category in DB4Objects.Query<RecordClassCategories>((RecordClassCategories Category) => DB4Objects.Query((RecordClassBooks Book) => Book.CategoryName == Category.Name).Any<RecordClassBooks>()))
                System.Console.WriteLine(Category); 

            DB4Objects.Close(); 

        } 

        public void OnGet() 
        { 
        } 
 
        [Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryToken]
        public void OnPostCheckInputData() 
        { 
            switch (SwitchID) 
            { 
                case 1: 
                { 
                    TableRecords = ( from Book in ArrayBooks 
                                    let Author = ( from Author in ArrayAuthors where Author.Name == "Harper Lee" select Author ).First<RecordStructAuthors>()  
                                    where Book.AuthorID == Author.ID
                                    select new RecordClassTable(Book.Title, Author.Name) ).ToArray<RecordClassTable>();
                    break; 
                } 
                case 2: 
                { 
                    TableRecords = ( from Book in ArrayBooks 
                                    let Reviews = ( from Review in ArrayReviews where Review.Raiting >= 4 && Review.BookID == Book.ID select Review )  
                                    from Review in Reviews 
                                    where Review.BookID == Book.ID
                                    select new RecordClassTable(Review.Description, Book.Title) ).ToArray<RecordClassTable>();
                    break; 
                } 
                case 3: 
                { 
                    TableRecords = ( from Book in ArrayBooks 
                                    where Book.Price >= 450 && Book.Price <= 600
                                    select new RecordClassTable(Book.Title, Book.Price + "") ).ToArray<RecordClassTable>(); 
                    break; 
                } 
                case 4: 
                { 
                    TableRecords = ( from Book in ArrayBooks 
                                    where Book.CreateYear == 1874 
                                    select new RecordClassTable(Book.Title, Book.CreateYear + "") ).ToArray<RecordClassTable>(); 
                    break; 
                } 
                case 5: 
                { 
                    TableRecords = ( from Book in ArrayBooks 
                                    group Book by Book.CategoryName into BookGroup 
                                    select new RecordClassTable(BookGroup.Count<RecordStructBooks>() + "", BookGroup.Key) ).ToArray<RecordClassTable>(); 
                    break; 
                } 
                case 6: 
                { 
                    TableRecords = ( from ReviewGroup in ( from Review in ArrayReviews 
                                    group Review by Review.BookID into ReviewGroup select ReviewGroup ) 
                                    let BookTitle = ( from Book in ArrayBooks where ReviewGroup.Key == Book.ID select Book.Title ).ToArray<System.String>() 
                                    select new RecordClassTable(BookTitle[0], ReviewGroup.Count<RecordStructReviews>() + "") ).ToArray<RecordClassTable>(); 
                    break; 
                } 
                case 7: 
                { 
                    TableRecords = ( from ReviewGroup in ( from Review in ArrayReviews 
                                    group Review by Review.BookID into ReviewGroup select ReviewGroup ) 
                                    let BookTitle = ( from Book in ArrayBooks where ReviewGroup.Key == Book.ID select Book.Title ).ToArray<System.String>() 
                                    select new RecordClassTable(BookTitle[0], ReviewGroup.Average((RecordStructReviews Review) => Review.Raiting) + "") ).OrderByDescending((RecordClassTable Record) => Record.Description).ToArray<RecordClassTable>(); 
                    break; 
                } 
                case 8: 
                { 
                    TableRecords = ( from Book in ArrayBooks 
                                     where !(( from Review in ArrayReviews where Review.BookID == Book.ID select true ).Any<System.Boolean>()) 
                                     select new RecordClassTable(Book.ID + "", Book.Title) ).ToArray<RecordClassTable>(); 
                    break; 
                } 
                case 9: 
                { 
                    TableRecords = ( from AuthorGroup in ( from RecordStructAuthors Author in ArrayAuthors 
                                     group Author by Author.ID into AuthorGroup select AuthorGroup ) 
                                     let ArrayAuthorName = ( from RecordStructAuthors Author in ArrayAuthors where Author.ID == AuthorGroup.Key select Author.Name ).ToArray<System.String>() 
                                     let Count = ( from RecordStructBooks Book in ArrayBooks where Book.AuthorID == AuthorGroup.Key select true ).Count<System.Boolean>() 
                                     select new RecordClassTable(Count + "", ArrayAuthorName.First<System.String>()) ).ToArray<RecordClassTable>(); 
                    break; 
                } 
                case 10: 
                { 
                    /*TableRecords = ( from BookGroup in ( from Book in ArrayBooks 
                                     group Book by Book.CategoryName into BookGroup select BookGroup ) 
                                     let ArrayBooksTemp = ( from Book in ArrayBooks where Book.CategoryName == BookGroup.Key && ( from Review in ArrayReviews where Book.ID == Review.BookID select true ).Any<System.Boolean>() select Book ).ToArray<RecordStructBooks>() 
                                     let ArrayReviewsRaiting = ( from Review in ArrayReviews where ( from Book in ArrayBooksTemp where Book.ID == Review.BookID select true ) != null select Review.Raiting ).Max<System.Single>()                                         
                                     select new RecordClassTable(ArrayBooksTemp.First<RecordStructBooks>().Title, ArrayReviewsRaiting + "") ).ToArray<RecordClassTable>();*/ 
                    TableRecords = ( from RecordStructBooks Book in ArrayBooks 
                                     join RecordStructReviews Review in ArrayReviews on Book.ID equals Review.BookID 
                                     group Book by new { Book.CategoryName, Book } into BookGroup
                                     select new RecordClassTable(BookGroup.Key.Book.Title, ( from Review in ArrayReviews where Review.BookID == BookGroup.Key.Book.ID select Review.Raiting ).Max<System.Single>() + "")).ToArray<RecordClassTable>(); 
                    break; 
                } 
            }
        } 

        public record struct RecordStructBooks(System.UInt32 ID, System.String Title, System.UInt32 AuthorID, System.String CategoryName, System.UInt16 Price, System.UInt16 CreateYear);
        public record struct RecordStructAuthors(System.UInt32 ID, System.String Name); 
        public record struct RecordStructCategories(System.UInt32 ID, System.String Name, System.String Description); 
        public record struct RecordStructReviews(System.UInt32 ID, System.Single Raiting, System.String Description, System.UInt32 BookID, System.UInt32 UserID);
        public record class RecordClassTable(System.String ID, System.String Description);
        
        
        public record class RecordClassCategories 
        { 
            public System.UInt32 ID; public System.String Name, Description; 

            public RecordClassCategories(System.UInt32 ID, System.String Name, System.String Description) 
            { 
                this.ID = ID; 
                this.Name = Name; 
                this.Description = Description; 
            }
        } 

        public record class RecordClassBooks 
        { 
            public System.UInt32 ID, AuthorID; public System.UInt16 Price; 
            public System.String Title, CategoryName; 

            public RecordClassBooks(System.UInt32 ID, System.String Title, System.UInt32 AuthorID, System.String CategoryName, System.UInt16 Price) 
            { 
                this.ID = ID; 
                this.Title = Title; 
                this.AuthorID = AuthorID; 
                this.CategoryName = CategoryName; 
                this.Price = Price; 
            } 
        }


    } 

    namespace ValidationsForm 
    { 
        public class AddRecordAboutCarInDataBaseFormValidationAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute 
        { 
            public AddRecordAboutCarInDataBaseFormValidationAttribute() { ErrorMessage = "Васи в понедельник отдыхают!"; }

            public override bool IsValid(System.Object SystemObject) 
            { 
                /*AspNetCoreApplicationTest1.Pages.RazorPagesForms.AddRecordAboutCarInDataBaseForm app = SystemObject as AspNetCoreApplicationTest1.Pages.RazorPagesForms.AddRecordAboutCarInDataBaseForm; 
                if (app == null || string.IsNullOrEmpty(app.Product.Name)) return true;
                else return !(app.Product.Name == "Добавление товара");*/ return true; 
            }
        } 
    } 
}
