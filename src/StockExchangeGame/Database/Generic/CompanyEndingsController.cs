﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Languages.Interfaces;
using StockExchangeGame.Database.Extensions;
using StockExchangeGame.Database.Models;

namespace StockExchangeGame.Database.Generic
{
    using Serilog;

    public class CompanyEndingsController : IEntityController<CompanyEndings>
    {
        private readonly SQLiteConnection _connection;
        private readonly ILogger logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private ILanguage _currentLanguage;

        public CompanyEndingsController(ILogger logger, SQLiteConnection connection)
        {
            this.logger = logger;
            this._connection = connection;
        }

        public void SetCurrentLanguage(ILanguage language)
        {
            this._currentLanguage = language;
            this.logger.Information(string.Format(this._currentLanguage.GetWord("LanguageSet"), "CompanyEndings", language.Identifier));
        }

        public ILanguage GetCurrentLanguage()
        {
            return this._currentLanguage;
        }

        public int CreateTable()
        {
            int result;
            var sql = this.GetCreateTableSQL();
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                result = command.ExecuteNonQuery();
            }
            this._connection.Close();
            this.logger.Information(string.Format(this._currentLanguage.GetWord("TableCreated"), "CompanyEndings", result));
            return result;
        }

        public List<CompanyEndings> Get()
        {
            var list = new List<CompanyEndings>();
            var sql = "SELECT * FROM CompanyEndings";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var companyEndings = this.GetCompanyEndingsFromReader(reader);
                        list.Add(companyEndings);
                    }
                }
            }
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedGet"), "CompanyEndings",
                string.Join("; ", list)));
            this._connection.Close();
            return list;
        }

        public CompanyEndings Get(long id)
        {
            CompanyEndings companyEnding = null;
            var sql = "SELECT * FROM CompanyEndings WHERE Id = @Id";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                this.PrepareCommandSelect(command, id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        companyEnding = this.GetCompanyEndingsFromReader(reader);
                }
            }
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedGetSingle"), "CompanyEndings", companyEnding));
            this._connection.Close();
            return companyEnding;
        }

        public ObservableCollection<CompanyEndings> Get<TValue>(Expression<Func<CompanyEndings, bool>> predicate = null,
            Expression<Func<CompanyEndings, TValue>> orderBy = null)
        {
            if (predicate == null && orderBy == null)
                return this.GetNoPredicateNoOrderBy();
            if (predicate != null && orderBy == null)
                return this.GetPredicateOnly(predicate);
            return predicate == null ? this.GetOrderByOnly(orderBy) : this.GetPredicateAndOrderBy(predicate, orderBy);
        }

        private ObservableCollection<CompanyEndings> GetNoPredicateNoOrderBy()
        {
            var result = this.Get().ToCollection();
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "CompanyEndings", null,
                null, string.Join(";", result)));
            return result;
        }

        private ObservableCollection<CompanyEndings> GetPredicateOnly(
            Expression<Func<CompanyEndings, bool>> predicate = null)
        {
            var result = this.GetQueryable().Where(predicate).ToCollection();
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "CompanyEndings",
                predicate, null, string.Join(";", result)));
            return result;
        }

        private ObservableCollection<CompanyEndings> GetOrderByOnly<TValue>(
            Expression<Func<CompanyEndings, TValue>> orderBy = null)
        {
            var result = this.GetQueryable().OrderBy(orderBy).ToCollection();
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "CompanyEndings", null,
                orderBy, string.Join(";", result)));
            return result;
        }

        private ObservableCollection<CompanyEndings> GetPredicateAndOrderBy<TValue>(
            Expression<Func<CompanyEndings, bool>> predicate = null,
            Expression<Func<CompanyEndings, TValue>> orderBy = null)
        {
            var result = this.GetQueryable().Where(predicate).OrderBy(orderBy).ToCollection();
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedGetPredicateOrderBy"), "CompanyEndings",
                predicate, orderBy, string.Join(";", result)));
            return result;
        }

        public CompanyEndings Get(Expression<Func<CompanyEndings, bool>> predicate)
        {
            var result = this.GetQueryable().Where(predicate).FirstOrDefault();
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedGetSinglePredicate"), "CompanyEndings", predicate,
                string.Join(";", result)));
            return result;
        }

        public int Insert(CompanyEndings entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareCommandInsert(command, entity);
                result = command.ExecuteNonQuery();
            }
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedInsert"), "CompanyEndings", entity, result));
            this._connection.Close();
            return result;
        }

        public int Update(CompanyEndings entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareCommandUpdate(command, entity);
                result = command.ExecuteNonQuery();
            }
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedUpdate"), "CompanyEndings", entity, result));
            this._connection.Close();
            return result;
        }

        public int Delete(CompanyEndings entity)
        {
            int result;
            this._connection.Open();
            using (var command = new SQLiteCommand(this._connection))
            {
                this.PrepareDeleteCommand(command, entity);
                result = command.ExecuteNonQuery();
            }
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedDelete"), "CompanyEndings", entity, result));
            this._connection.Close();
            return result;
        }

        public int Count(Expression<Func<CompanyEndings, bool>> predicate = null)
        {
            return predicate == null ? this.CountNoPredicate() : this.CountPredicate(predicate);
        }

        private int CountNoPredicate()
        {
            var count = 0;
            const string sql = "SELECT COUNT(Id) FROM CompanyEndings";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())

                        count = Convert.ToInt32(reader[0].ToString());
                }
            }
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedCount"), "CompanyEndings", null, count));
            this._connection.Close();
            return count;
        }

        private int CountPredicate(Expression<Func<CompanyEndings, bool>> predicate = null)
        {
            var count = this.GetQueryable().Where(predicate).Count();
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedCount"), "CompanyEndings", predicate, count));
            return count;
        }

        private string GetCreateTableSQL()
        {
            return "CREATE TABLE IF NOT EXISTS CompanyEndings (" +
                   "Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE," +
                   "Name TEXT NOT NULL," +
                   "CreatedAt TEXT NOT NULL," +
                   "Deleted BOOLEAN NOT NULL," +
                   "ModifiedAt TEXT NOT NULL)";
        }

        private void PrepareCommandSelect(SQLiteCommand command, long id)
        {
            command.Prepare();
            command.Parameters.AddWithValue("@Id", id);
        }

        private CompanyEndings GetCompanyEndingsFromReader(SQLiteDataReader reader)
        {
            return new CompanyEndings
            {
                Id = Convert.ToInt64(reader["Id"].ToString()),
                Name = reader["Name"].ToString(),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"].ToString()),
                Deleted = Convert.ToBoolean(reader["Deleted"].ToString()),
                ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"].ToString())
            };
        }

        private void PrepareCommandInsert(SQLiteCommand command, CompanyEndings companyEndings)
        {
            command.CommandText = "INSERT INTO CompanyEndings (Id, Name, CreatedAt, Deleted, ModifiedAt) " +
                                  "VALUES (@Id, @Name, @CreatedAt, @Deleted, @ModifiedAt)";
            command.Prepare();
            this.AddParametersUpdateInsert(command, companyEndings);
        }

        private void AddParametersUpdateInsert(SQLiteCommand command, CompanyEndings companyEndings)
        {
            command.Parameters.AddWithValue("@Id", companyEndings.Id);
            command.Parameters.AddWithValue("@Name", companyEndings.Name);
            command.Parameters.AddWithValue("@CreatedAt", companyEndings.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@Deleted", companyEndings.Deleted);
            command.Parameters.AddWithValue("@ModifiedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void PrepareCommandUpdate(SQLiteCommand command, CompanyEndings companyEndings)
        {
            command.CommandText =
                "UPDATE CompanyEndings SET Name = @Name, CreatedAt = @CreatedAt, Deleted = @Deleted, " +
                "ModifiedAt = @ModifiedAt WHERE Id = @Id";
            command.Prepare();
            this.AddParametersUpdateInsert(command, companyEndings);
        }

        private void PrepareDeleteCommand(SQLiteCommand command, CompanyEndings companyEndings)
        {
            command.CommandText = "UPDATE CompanyEndings SET Deleted = true, ModifiedAt = @ModifiedAt WHERE Id = @Id";
            command.Prepare();
            command.Parameters.AddWithValue("@Id", companyEndings.Id);
            command.Parameters.AddWithValue("@ModifiedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private IQueryable<CompanyEndings> GetQueryable()
        {
            return this.Get().AsQueryable();
        }

        public void Truncate()
        {
            const string sql = "DELETE FROM CompanyEndings";
            this._connection.Open();
            using (var command = new SQLiteCommand(sql, this._connection))
            {
                command.ExecuteNonQuery();
            }
            this.logger.Information(string.Format(this._currentLanguage.GetWord("ExecutedTruncate"), "CompanyEndings"));
            this._connection.Close();
        }
    }
}