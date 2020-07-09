using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace LibraryMusic
{
    /// <summary>
    /// Храним и работаем с кэшем через бд SqLite
    /// </summary>
    class SqlLiteCache : ICache
    {

        private readonly string dbFileName = "SearchDB.db3";
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;
        private readonly DataTable dTable = new DataTable();

        public SqlLiteCache()
        {
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();
            CreateDB();
        }

        public string GetFromCache(string searchApiPath)
        {
            Console.WriteLine("Подгружаем из кэша...");

            //CreateDB();

            String result = string.Empty;
            String sqlQuery;

            if (m_dbConn?.State != ConnectionState.Open)
            {
                ConnectionToDB();
            }

            try
            {
                sqlQuery = "SELECT result " +
                           "FROM SearchResult " +
                           "WHERE apiPath = '" + searchApiPath + "'" +
                           "Order by id desc LIMIT 1";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                adapter.Fill(dTable);
                if (dTable != null && dTable.Rows.Count > 0)
                {
                     result = dTable.Rows[0][0].ToString();
                }
                else
                {
                    Console.WriteLine("В кэше отсутствуют запрошенные данные");
                }

            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
            return result;
        }

        public void SaveInCache(string apiPath, string searchText, string searchResult)
        {
            /// <summary>
            /// Заносим альбомы в БД
            /// </summary>
            if (m_dbConn.State != ConnectionState.Open)
            {
                ConnectionToDB();
            }

            try
            {
                m_sqlCmd.CommandText = $"INSERT INTO SearchResult ('apiPath', 'text', 'result') values ('{apiPath}','{searchText}','{searchResult.Replace("'", "`")}' ); ";                
                m_sqlCmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }

        /// <summary>
        /// Подключаемся к БД
        /// </summary>
        private void ConnectionToDB()
        {
            m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
            m_dbConn.Open();
            m_sqlCmd.Connection = m_dbConn;
        }

        /// <summary>
        /// Создаем БД если ее нет
        /// </summary>
        private void CreateDB()
        {
            if (!File.Exists(dbFileName))
            {
                SQLiteConnection.CreateFile(dbFileName);

                try
                {
                    ConnectionToDB();

                    m_sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS SearchResult (id INTEGER PRIMARY KEY AUTOINCREMENT, apiPath TEXT, Text TEXT, result TEXT); ";
                    m_sqlCmd.ExecuteNonQuery();

                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine("Не удалось установить соединение с БД...");
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

    }
}
