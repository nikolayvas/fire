using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using FireWork.Dto;

namespace FireWork
{
    public static class DBAccess
    {
        public static List<CompanyDto> LoadData()
        {
            using (var connection = new SQLiteConnection($"Data Source={Application.StartupPath}\\testDb.db"))
            {
                connection.Open();

                var data = new List<CompanyDto>();

                using (var command = new SQLiteCommand("SELECT Id, Name, datetime(Date,'unixepoch') FROM COMPANY ORDER BY Id Desc", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                data.Add(new CompanyDto()
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Date = ParseData(reader.GetString(2))
                                });
                            }
                        }
                    }

                }

                return data;
            }
        }

        public static void AddNewRow(CompanyDto dto)
        {
            using (var connection = new SQLiteConnection($"Data Source={Application.StartupPath}\\testDb.db"))
            {
                connection.Open();
                string sql = "INSERT INTO COMPANY(Name, Date) VALUES(@param, strftime ('%s', 'now'))";

                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.Parameters.Add("@param", DbType.String, 50).Value = dto.Name;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static DateTime ParseData(string data)
        {
            if (!DateTime.TryParse(data, out DateTime d))
            {
                return DateTime.MinValue;
            }
            else
            {
                return d;
            }
        }
    }
}
