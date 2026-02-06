using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
using FireWork.Dto;

namespace FireWork
{
    public static class DBAccess
    {
        #region Company
        public static List<CompanyDto> LoadCompanies()
        {
            using (var connection = new SQLiteConnection($"Data Source={Application.StartupPath}\\testDb.db"))
            {
                connection.Open();

                var data = new List<CompanyDto>();

                using (var command = new SQLiteCommand("SELECT Id, Name, Address, datetime(Date,'unixepoch') FROM COMPANY ORDER BY Id Desc", connection))
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
                                    Name = GetStringOrEmpty(reader, 1),
                                    Address = GetStringOrEmpty(reader, 2),
                                    Date = ParseDate(reader.GetString(3))
                                });
                            }
                        }
                    }

                }

                return data;
            }
        }

        public static CompanyDto LoadCompany(int id)
        {
            using (var connection = new SQLiteConnection($"Data Source={Application.StartupPath}\\testDb.db"))
            {
                connection.Open();

                var data = new List<CompanyDto>();

                using (var command = new SQLiteCommand($"SELECT Id, Name, Address, datetime(Date,'unixepoch') FROM COMPANY WHERE id = {id} ORDER BY Id Desc", connection))
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
                                    Name = GetStringOrEmpty(reader, 1),
                                    Address = GetStringOrEmpty(reader, 2),
                                    Date = ParseDate(reader.GetString(3))
                                });
                            }
                        }
                    }

                }

                return data.FirstOrDefault();
            }
        }

        public static void AddNewCompany(CompanyDto dto)
        {
            using (var connection = new SQLiteConnection($"Data Source={Application.StartupPath}\\testDb.db"))
            {
                connection.Open();
                string sql = "INSERT INTO COMPANY(Name, Address, Date) VALUES(@param0, @param1, strftime ('%s', 'now'))";

                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.Parameters.Add("@param0", DbType.String, 50).Value = dto.Name;
                    cmd.Parameters.Add("@param1", DbType.String, 100).Value = dto.Address;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateCompany(CompanyDto dto)
        {
            using (var connection = new SQLiteConnection($"Data Source={Application.StartupPath}\\testDb.db"))
            {
                connection.Open();
                string sql = "UPDATE COMPANY SET Name = @param0, Address = @param1 WHERE id = @param2";

                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.Parameters.Add("@param0", DbType.String, 50).Value = dto.Name;
                    cmd.Parameters.Add("@param1", DbType.String, 100).Value = dto.Address;
                    cmd.Parameters.Add("@param2", DbType.Int64).Value = dto.Id;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Statement
        public static long AddNewStatement(int companyId, StatementDto dto)
        {
            using (var connection = new SQLiteConnection($"Data Source={Application.StartupPath}\\testDb.db"))
            {
                connection.Open();
                string sql = "INSERT INTO STATEMENT(NO, Company_id, Date) VALUES(@param0, @param1, strftime ('%s', 'now'))";

                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.Parameters.Add("@param0", DbType.Int64).Value = dto.No;
                    cmd.Parameters.Add("@param1", DbType.Int64).Value = companyId;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

                var rowID = connection.LastInsertRowId;

                return rowID;
            }
        }

        public static List<StatementDto> LoadStatements(int companyId)
        {
            using (var connection = new SQLiteConnection($"Data Source={Application.StartupPath}\\testDb.db"))
            {
                connection.Open();

                var data = new List<StatementDto>();

                using (var command = new SQLiteCommand($"SELECT Id, No, datetime(Date,'unixepoch') FROM STATEMENT Where Company_ID = {companyId} ORDER BY Date ", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                data.Add(new StatementDto()
                                {
                                    Id = reader.GetInt32(0),
                                    No = reader.GetInt32(1),
                                    Date = ParseDate(reader.GetString(2))
                                });
                            }
                        }
                    }
                }

                return data;
            }
        }

        public static StatementDto LoadStatement(int statementId)
        {
            using (var connection = new SQLiteConnection($"Data Source={Application.StartupPath}\\testDb.db"))
            {
                connection.Open();

                var data = new List<StatementDto>();

                using (var command = new SQLiteCommand($"SELECT Id, No, datetime(Date,'unixepoch') FROM STATEMENT Where id = {statementId}", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                data.Add(new StatementDto()
                                {
                                    Id = reader.GetInt32(0),
                                    No = reader.GetInt32(1),
                                    Date = ParseDate(reader.GetString(2))
                                });
                            }
                        }
                    }
                }

                return data.FirstOrDefault();
            }
        }

        public static int LastStatementNo()
        {
            using (var connection = new SQLiteConnection($"Data Source={Application.StartupPath}\\testDb.db"))
            {
                connection.Open();

                var data = new List<StatementDto>();

                using (var command = new SQLiteCommand($"SELECT MAX(No) FROM STATEMENT", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                return reader.GetInt32(0);

                            }
                        }
                    }
                }

                return 0;
            }
        }

        public static void TwinStatement(int companyId, int statementId, int no)
        {
            var services = LoadServices(statementId);

            var newStatementId = AddNewStatement(companyId, new StatementDto()
            {
                No = no,
            });

            foreach (var item in services)
            {
                AddNewService(newStatementId, item);
            }
        }

        public static void RemoveStatement(int statementId)
        {
            using (var connection = new SQLiteConnection($"Data Source={Application.StartupPath}\\testDb.db"))
            {
                connection.Open();
                string sql = "DELETE FROM STATEMENT WHERE id = @param0";

                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.Parameters.Add("@param0", DbType.Int64).Value = statementId;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Service
        public static void AddNewService(long statementId, ServiceDto dto)
        {
            using (var connection = new SQLiteConnection($"Data Source={Application.StartupPath}\\testDb.db"))
            {
                connection.Open();
                string sql = "INSERT INTO SERVICE(Name, Category, Foam_Name, Sticker_1, Sticker_2, Sticker_3, Weight, Statement_id) VALUES(@param1, @param2, @param3, @param4, @param5, @param6, @param7, @param8)";

                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.Parameters.Add("@param1", DbType.String, 50).Value = dto.Name;
                    cmd.Parameters.Add("@param2", DbType.Int64).Value = dto.Category;
                    cmd.Parameters.Add("@param3", DbType.String, 50).Value = dto.FoamName;
                    cmd.Parameters.Add("@param4", DbType.String, 50).Value = dto.Sticker1;
                    cmd.Parameters.Add("@param5", DbType.String, 50).Value = dto.Sticker2;
                    cmd.Parameters.Add("@param6", DbType.String, 50).Value = dto.Sticker3;
                    cmd.Parameters.Add("@param7", DbType.Decimal).Value = dto.Weight;
                    cmd.Parameters.Add("@param8", DbType.Int64).Value = statementId;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<ServiceDto> LoadServices(int statementId)
        {
            using (var connection = new SQLiteConnection($"Data Source={Application.StartupPath}\\testDb.db"))
            {
                connection.Open();

                var data = new List<ServiceDto>();

                using (var command = new SQLiteCommand($"SELECT Id, Name, Category, Foam_name, Weight, Sticker_1, Sticker_2, Sticker_3 FROM SERVICE Where Statement_ID = {statementId} order by id" , connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                data.Add(new ServiceDto()
                                {
                                    Id = reader.GetInt32(0),
                                    Name = GetStringOrEmpty(reader, 1),
                                    Category = reader.GetInt32(2),
                                    FoamName = GetStringOrEmpty(reader, 3),
                                    Weight = reader.GetDecimal(4),
                                    Sticker1 = GetStringOrEmpty(reader, 5),
                                    Sticker2 = GetStringOrEmpty(reader, 6),
                                    Sticker3 = GetStringOrEmpty(reader, 7)
                                });
                            }
                        }
                    }
                }

                return data;
            }
        }

        public static void RemoveService(int serviceId)
        {
            using (var connection = new SQLiteConnection($"Data Source={Application.StartupPath}\\testDb.db"))
            {
                connection.Open();
                string sql = "DELETE FROM SERVICE WHERE id = @param0";

                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.Parameters.Add("@param0", DbType.Int64).Value = serviceId;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static ServiceDto LoadService(int serviceId)
        {
            using (var connection = new SQLiteConnection($"Data Source={Application.StartupPath}\\testDb.db"))
            {
                connection.Open();

                var data = new List<ServiceDto>();

                using (var command = new SQLiteCommand($"SELECT Id, Name, Category, Foam_name, Weight, Sticker_1, Sticker_2, Sticker_3 FROM SERVICE Where id = {serviceId}", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                data.Add(new ServiceDto()
                                {
                                    Id = reader.GetInt32(0),
                                    Name = GetStringOrEmpty(reader, 1),
                                    Category = reader.GetInt32(2),
                                    FoamName = GetStringOrEmpty(reader, 3),
                                    Weight = reader.GetDecimal(4),
                                    Sticker1 = GetStringOrEmpty(reader, 5),
                                    Sticker2 = GetStringOrEmpty(reader, 6),
                                    Sticker3 = GetStringOrEmpty(reader, 7)
                                });
                            }
                        }
                    }
                }

                return data.FirstOrDefault();
            }
        }

        public static void UpdateService(ServiceDto dto)
        {
            using (var connection = new SQLiteConnection($"Data Source={Application.StartupPath}\\testDb.db"))
            {
                connection.Open();
                string sql = "UPDATE SERVICE SET Name = @param0, Category = @param1, Foam_Name = @param2, Weight = @param3, Sticker_1 = @param4, Sticker_2 = @param5, Sticker_3 = @param6  WHERE id = @param7";

                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.Parameters.Add("@param0", DbType.String, 50).Value = dto.Name;
                    cmd.Parameters.Add("@param1", DbType.Int64).Value = dto.Category;
                    cmd.Parameters.Add("@param2", DbType.String, 50).Value = dto.FoamName;
                    cmd.Parameters.Add("@param3", DbType.Decimal).Value = dto.Weight;
                    cmd.Parameters.Add("@param4", DbType.String, 50).Value = dto.Sticker1;
                    cmd.Parameters.Add("@param5", DbType.String, 50).Value = dto.Sticker2;
                    cmd.Parameters.Add("@param6", DbType.String, 50).Value = dto.Sticker3;
                    cmd.Parameters.Add("@param7", DbType.Int64).Value = dto.Id;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Report

        public static List<DiaryDto> GetReportData(int no)
        {
            using (var connection = new SQLiteConnection($"Data Source={Application.StartupPath}\\testDb.db"))
            {
                connection.Open();

                var data = new List<DiaryDto>();

                using (var command = new SQLiteCommand($"select datetime(Date,'unixepoch'), weight, name, STICKER_1, STICKER_2, STICKER_3, FOAM_NAME from SERVICE ser inner join STATEMENT st on ser.STATEMENT_ID = st.id where st.no > {no} order by st.no", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var date = ParseDate(reader.GetString(0));
                                var unitWeightType = reader.GetDecimal(1) > 25 ? "Возим    пожарог." : "Носим    пожарог.";
                                var unitModel = GetStringOrEmpty(reader, 2);
                                var sticker1 = GetStringOrEmpty(reader, 3);
                                var sticker2 = GetStringOrEmpty(reader, 4);
                                var sticker3 = GetStringOrEmpty(reader, 5);
                                var foamName = GetStringOrEmpty(reader, 6);

                                if(!string.IsNullOrEmpty(sticker1)) 
                                {
                                    data.Add(new DiaryDto()
                                    {
                                        Date = date.ToString("dd.MM.yyyy"),
                                        UnitWeightType = unitWeightType,
                                        UnitModel = unitModel,
                                        ServiceType = "Техн.об.",
                                        Sticker = sticker1,
                                        TradeNameFoam = foamName,
                                        DataNext = date.AddYears(1).ToString("dd.MM.yyyy")
                                    });
                                }

                                if (!string.IsNullOrEmpty(sticker2))
                                {
                                    data.Add(new DiaryDto()
                                    {
                                        Date = date.ToString("dd.MM.yyyy"),
                                        UnitWeightType = unitWeightType,
                                        UnitModel = unitModel,
                                        ServiceType = "Презар.",
                                        Sticker = sticker2,
                                        TradeNameFoam = foamName,
                                        DataNext = date.AddYears(1).ToString("dd.MM.yyyy")
                                    });
                                }

                                if (!string.IsNullOrEmpty(sticker3))
                                {
                                    data.Add(new DiaryDto()
                                    {
                                        Date = date.ToString("dd.MM.yyyy"),
                                        UnitWeightType = unitWeightType,
                                        UnitModel = unitModel,
                                        ServiceType = "Презар.",
                                        Sticker = sticker3,
                                        TradeNameFoam = foamName,
                                        DataNext = date.AddYears(1).ToString("dd.MM.yyyy")
                                    });
                                }
                            }
                        }
                    }
                }

                return data;
            }
        }

        #endregion

        private static DateTime ParseDate(string data)
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

        private static string GetStringOrEmpty(SQLiteDataReader reader, int column)
        {
            return reader[column] == DBNull.Value ? "" : reader[column].ToString();
        }
    }
}
