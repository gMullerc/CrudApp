using System;
using System.Data.SqlClient;

namespace CrudApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnection;
            string connectionString = @"Data Source=GOSPNOT07;Initial Catalog=CoDB;Integrated Security=True";
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Conexao feita com sucesso!");
                string answer;
                do {
                    Console.WriteLine("Escolha o que deseja realizar, \n1. Criar \n2. inserir \n3. atualizar \n4. deletar");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:

                            //create => C

                            Console.WriteLine("Enter your name");
                            string userName = Console.ReadLine();
                            Console.WriteLine("entre your age");
                            int userAge = int.Parse(Console.ReadLine());
                            string insertQuery = "INSERT INTO details(user_name,user_age) VALUES ('" + userName + "'," + userAge + ")";
                            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("dado inserido com sucesso na tabela!");
                            break;
                        case 2:
                            //Reader => R 
                            string displayQuery = "SELECT * FROM details";
                            SqlCommand displayCommand = new SqlCommand(displayQuery, sqlConnection);
                            SqlDataReader dataReader = displayCommand.ExecuteReader();
                            while (dataReader.Read())
                            {
                                Console.WriteLine("Id: " + dataReader.GetValue(0).ToString());
                                Console.WriteLine("Name: " + dataReader.GetValue(1).ToString());
                                Console.WriteLine("Age: " + dataReader.GetValue(2).ToString());
                            }
                            dataReader.Close();
                            break;
                        case 3:

                            //Update =>
                            int u_id;
                            int u_age;

                            Console.WriteLine("Coloque o id que deseja mudar");
                            u_id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Coloque a idade desejada");
                            u_age = int.Parse(Console.ReadLine());
                            string updateQuery = "UPDATE details set user_age = " + u_age + "where user_id =" + u_id + "";
                            SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
                            updateCommand.ExecuteNonQuery();
                            Console.WriteLine("Dados atualizados com sucesso!");
                            break;
                        case 4:
                            //Delete => D
                            int d_id;
                            Console.WriteLine("Coloque o Id que deseja deletar");
                            d_id = int.Parse(Console.ReadLine());
                            string deleteQuery = "DELETE FROM details WHERE user_id =" + d_id + "";
                            SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
                            deleteCommand.ExecuteNonQuery();
                            Console.WriteLine("Deletado com sucesso");
                            break;


                        default:
                            Console.WriteLine("Número invalido");
                            break;
                    }
                    Console.WriteLine("Vc quer continuar?");
                    answer = Console.ReadLine();
                } while (answer != "NAO");
                sqlConnection.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
