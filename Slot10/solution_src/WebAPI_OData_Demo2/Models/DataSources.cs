namespace WebAPI_OData_Demo2.Models
{
	public static class DataSources
	{
		private static IList<Book> books {  get; set; }

		public static IList<Book> GetBooks()
		{
			if(books != null) return books;
			books = new List<Book>();
			books.Add(new Book
			{
				Id = 1,
				ISBN = "078-1-334434332-2",
				Title = " Lap Trinh C# Pro",
				Author = "FPTU - HaiTD - HE170242",
				Price = 1000000m,
				Location = new Address
				{
					City = "Ha Noi City",
					Street = "Hoa Lac"
				},
				Press = new Press {
					Id = 1,
					Name = "Tran Van A",
					Email = "tranvana@fpt.edu.vn",
					Category = Category.Book,
				}
			});
			books.Add(new Book
			{
				Id = 3,
				ISBN = "078-1-334434332-2",
				Title = " Lap Trinh Ruby",
				Author = "FPTU - HaiTD - HE170242",
				Price = 17000000m,
				Location = new Address
				{
					City = "HCM City",
					Street = "Quan 1 District"
				},
				Press = new Press
				{
					Id = 1,
					Name = "Tran Van B",
					Email = "tranvanb@fpt.edu.vn",
					Category = Category.IBook,
				}
			});

			return books;
		}
	}
}
