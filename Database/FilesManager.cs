using System;
using System.Data.SqlClient;


namespace Database
{
    public class FilesManager
    {
        readonly SqlConnection _myConnection = new SqlConnection("user id=taip.msd1;" +
                                       "password=Azure123;server=aaqixphabv.database.windows.net;" +
                                       "database=files; ");

        public FilesManager()
        {
            _myConnection.Open();
        }
        public void GetAllFiles()
        {
            try
            {
                var myCommand = new SqlCommand("select * from [dbo].[UploadedFiles]",
                                                         _myConnection);
                var myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Console.WriteLine(myReader[1].ToString());
                    Console.WriteLine(myReader[2].ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void AddFile(String filename)
        {
           try
            {
                var myCommand = new SqlCommand("INSERT INTO [dbo].[UploadedFiles]" +
                                               "([FilePath],[AddedDate])" +
                                               "VALUES('"+filename+"','"+DateTime.Now+"')", _myConnection);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            GetAllFiles();
        }
    }
}
