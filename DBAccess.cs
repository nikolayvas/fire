﻿using System;
using System.CodeDom;
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
        public static void AddNewStatement(int companyId, StatementDto dto)
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

        #endregion

        #region Service
        public static void AddNewService(int statementId, ServiceDto dto)
        {
            using (var connection = new SQLiteConnection($"Data Source={Application.StartupPath}\\testDb.db"))
            {
                connection.Open();
                string sql = "INSERT INTO SERVICE(No, Name, Category, Foam_Name, Sticker_1, Sticker_2, Sticker_3, Weight, Statement_id) VALUES(@param0, @param1, @param2, @param3, @param4, @param5, @param6, @param7, @param8)";

                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.Parameters.Add("@param0", DbType.Int64).Value = dto.No;
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

                using (var command = new SQLiteCommand($"SELECT Id, No, Name, Category, Foam_name, Weight, Sticker_1, Sticker_2, Sticker_3 FROM SERVICE Where Statement_ID = {statementId} ORDER BY No", connection))
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
                                    No = reader.GetInt32(1),
                                    Name = GetStringOrEmpty(reader, 2),
                                    Category = reader.GetInt32(3),
                                    FoamName = GetStringOrEmpty(reader, 4),
                                    Weight = reader.GetDecimal(5),
                                    Sticker1 = GetStringOrEmpty(reader, 6),
                                    Sticker2 = GetStringOrEmpty(reader, 7),
                                    Sticker3 = GetStringOrEmpty(reader, 8)
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
