﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Linq.Expressions;
using StockExchangeGame.Database.Models;

namespace StockExchangeGame.Database.Generic
{
    // ReSharper disable once UnusedMember.Global
    public class NamesController : IEntityController<Names>
    {
        private readonly SQLiteConnection _connection;

        public NamesController(string connectionString)
        {
            _connection = new SQLiteConnection(connectionString);
        }

        public int CreateTable()
        {
            int result;
            var sql = GetCreateTableSQL();
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                result = command.ExecuteNonQuery();
            }
            _connection.Close();
            return result;
        }

        public List<Names> Get()
        {
            var list = new List<Names>();
            var sql = "SELECT * FROM Names";
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var names = GetNamesFromReader(reader);
                        list.Add(names);
                    }
                }
            }
            _connection.Close();
            return list;
        }

        public Names Get(long id)
        {
            var sql = "SELECT * FROM Names WHERE Id = @Id";
            _connection.Open();
            using (var command = new SQLiteCommand(sql, _connection))
            {
                PrepareCommandSelect(command, id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        return GetNamesFromReader(reader);
                }
            }
            _connection.Close();
            return null;
        }

        public ObservableCollection<Names> Get<TValue>(Expression<Func<Names, bool>> predicate = null,
            Expression<Func<Names, TValue>> orderBy = null)
        {
            if (predicate == null && orderBy == null)
                return GetCollection(Get());
            if (predicate != null && orderBy == null)
                return GetCollection(GetQueryable().Where(predicate).ToList());
            return GetCollection(predicate == null
                ? GetQueryable().OrderBy(orderBy).ToList()
                : GetQueryable().Where(predicate).OrderBy(orderBy).ToList());
        }

        public Names Get(Expression<Func<Names, bool>> predicate)
        {
            return GetQueryable().Where(predicate).FirstOrDefault();
        }

        public int Insert(Names entity)
        {
            int result;
            _connection.Open();
            using (var command = new SQLiteCommand(_connection))
            {
                PrepareCommandInsert(command, entity);
                result = command.ExecuteNonQuery();
            }
            _connection.Close();
            return result;
        }

        public int Update(Names entity)
        {
            int result;
            _connection.Open();
            using (var command = new SQLiteCommand(_connection))
            {
                PrepareCommandUpdate(command, entity);
                result = command.ExecuteNonQuery();
            }
            _connection.Close();
            return result;
        }

        public int Delete(Names entity)
        {
            int result;
            _connection.Open();
            using (var command = new SQLiteCommand(_connection))
            {
                PrepareDeletCommand(command, entity);
                result = command.ExecuteNonQuery();
            }
            _connection.Close();
            return result;
        }

        public int Count(Expression<Func<Names, bool>> predicate = null)
        {
            return predicate == null ? Get().Count : GetQueryable().Where(predicate).Count();
        }

        private string GetCreateTableSQL()
        {
            return "CREATE TABLE Names (" +
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

        private Names GetNamesFromReader(SQLiteDataReader reader)
        {
            return new Names
            {
                Id = Convert.ToInt64(reader["Id"].ToString()),
                Name = reader["Name"].ToString(),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"].ToString()),
                Deleted = Convert.ToBoolean(reader["Deleted"].ToString()),
                ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"].ToString())
            };
        }

        private ObservableCollection<Names> GetCollection(IEnumerable<Names> oldList)
        {
            var collection = new ObservableCollection<Names>();
            foreach (var item in oldList)
                collection.Add(item);
            return collection;
        }

        private void PrepareCommandInsert(SQLiteCommand command, Names names)
        {
            command.CommandText = "INSERT INTO Names (Id, Name, CreatedAt, Deleted, ModifiedAt) " +
                                  "VALUES (@Id, @Name, @CreatedAt, @Deleted, @ModifiedAt)";
            command.Prepare();
            AddParametersInsert(command, names);
        }

        private void AddParametersInsert(SQLiteCommand command, Names names)
        {
            command.Parameters.AddWithValue("@Id", names.Id);
            command.Parameters.AddWithValue("@Name", names.Name);
            command.Parameters.AddWithValue("@CreatedAt", names.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@Deleted", names.Deleted);
            command.Parameters.AddWithValue("@ModifiedAt", names.ModifiedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void PrepareCommandUpdate(SQLiteCommand command, Names names)
        {
            command.CommandText =
                "UPDATE Names SET Name = @Name, CreatedAt = @CreatedAt, Deleted = @Deleted, " +
                "ModifiedAt = @ModifiedAt WHERE Id = @Id";
            command.Prepare();
            AddParametersUpdate(command, names);
        }

        private void AddParametersUpdate(SQLiteCommand command, Names names)
        {
            command.Parameters.AddWithValue("@Id", names.Id);
            command.Parameters.AddWithValue("@Name", names.Name);
            command.Parameters.AddWithValue("@CreatedAt", names.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            command.Parameters.AddWithValue("@Deleted", names.Deleted);
            command.Parameters.AddWithValue("@ModifiedAt", names.ModifiedAt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void PrepareDeletCommand(SQLiteCommand command, Names names)
        {
            command.CommandText = "DELETE FROM Names WHERE Id = @Id";
            command.Prepare();
            command.Parameters.AddWithValue("@Id", names.Id);
        }

        private IQueryable<Names> GetQueryable()
        {
            return Get().AsQueryable();
        }
    }
}