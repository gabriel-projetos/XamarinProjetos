using App.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.DataService
{
    public class ProdutosDataBase
    {
        readonly SQLiteAsyncConnection _database;

        public ProdutosDataBase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Produto>().Wait();
        }

        public Task<List<Produto>> GetNotesAsync()
        {
            return _database.Table<Produto>().ToListAsync();
        }

        public Task<int> SaveNoteAsync(Produto produto)
        {
           
            return _database.InsertAsync(produto);
            
        }
    }

}
