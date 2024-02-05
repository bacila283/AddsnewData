using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace project1
{
	internal class Program
	{
		static int id = 0;
		private static Random random = new Random();
		static void Main(string[] args)
		{
			string sqlserver = "Строка подключения";
			string sqlDB = "Название вашей БД";
			string username = "Логин";
			string password = "Пароль";


			Console.WriteLine("Введите число генерации");
			int count = Int32.Parse(Console.ReadLine());
			string connectionString = $"Data Source={sqlserver};Database={sqlDB};User Id={username};Password={password}";
			//@"Data Source=.\SQLEXPRESS;Initial Catalog=MegaIndex;Integrated Security=True";




			string sqlExpression = string.Empty;
			List<string> emails = new List<string>() { "@mail.ru", "@mail.bk", "@gmail.com", "@ya.ru", "@yandex.ru", "@mygmail.com", "@fa.ru", "@kip-fa.ru" };
			List<string> Fullemails = new List<string>();
			List<string> Adrss = new List<string>();
			for (int i = 0; i < count; i++)
			{
				Fullemails.Add(GetText(emails[random.Next(emails.Count)]));
				Adrss.Add(GetText());
			}
			Console.WriteLine("Lists - full");

			List<string> names = new List<string>() { "Милана", "Максим", "Аделина", "Елена", "Роберт", "Марк", "Али", "Ульяна", "София", "Иван", "Владимир", "Илья", "Ян", "Валерий", "Сергей", "Иван", "Петр", "Даниил", "Денис" };
			List<string> sur_names = new List<string>() { "Петров", "Иванов", "Сидоров", "Кузнецов", "Топоро", "Котусов", "Кулагин", "Сидлеров", "Бочкарев", "Калчу", "Николаве", "Якунов", "Путин", "Звезда", "Победитель" };
			List<string> doljnostu = new List<string> { "Модератор", "Кинолог", "Офицер", "Таксист", "Мед.Работник", "Портной", "Кондуктор" };

			SqlConnection connection = new SqlConnection(connectionString);
			try
			{
				connection.Open();
				Console.WriteLine("Успешное подлючение!");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			Console.WriteLine("Ввод данных! Это может занять некоторое время");
			for (id = 0; id < count; id++)
			{
				sqlExpression = $"insert into Clients values ('{names[random.Next(names.Count)]}','{sur_names[random.Next(sur_names.Count)]}',{random.Next(10000, 19000)},'{doljnostu[random.Next(doljnostu.Count)]}','{Fullemails[random.Next(Fullemails.Count)]}','{Adrss[random.Next(count)]}','{random.Next(15, 65)}')";
				SqlCommand command = new SqlCommand(sqlExpression, connection);
				command.ExecuteNonQuery();
			}
			Console.WriteLine("Данные внесены! Подключение закарыватеся");
			connection.Close();
			Console.Read();
		}

		private static string GetText(string text)
		{
			StringBuilder stringBuilder = new StringBuilder();

			for (int i = 0; i < 8; i++)
			{
				stringBuilder.Append((char)random.Next(97, 122));
			}
			return stringBuilder.Append(text).ToString();
		}
		private static string GetText()
		{
			StringBuilder stringBuilder = new StringBuilder();

			for (int i = 0; i < 15; i++)
			{
				stringBuilder.Append((char)random.Next(97, 122));
			}
			return stringBuilder.ToString();
		}
	}
}
