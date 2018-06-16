using SQLite;
using System.Collections.Generic;
using System.Linq;
using PCLStorage;
using System;

namespace Test
{
    public class SqlHelper
    {
        static object locker = new object();
        SQLiteConnection database;
        public SqlHelper()
        {
            database = GetConnection();
            // create the tables  
            database.CreateTable<RegEntity>();
        }

        internal RegEntity GetItem(object text1, object text2)
        {
            throw new NotImplementedException();
        }

        internal RegEntity GetItem(object text1, string text2)
        {
            throw new NotImplementedException();
        }

     
        public SQLite.SQLiteConnection GetConnection()
        {
            SQLiteConnection sqlitConnection;
            var sqliteFilename = "Employee.db3";
            IFolder folder = FileSystem.Current.LocalStorage;
            string path = PortablePath.Combine(folder.Path.ToString(), sqliteFilename);
            sqlitConnection = new SQLite.SQLiteConnection(path);
            return sqlitConnection;
        }

        internal RegEntity GetItem(object text)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegEntity> GetItems()
        {
            lock (locker)
            {
                return (from i in database.Table<RegEntity>() select i).ToList();
            }
        }

        public RegEntity GetItem(string userName)
        {
            lock (locker)
            {
                return database.Table<RegEntity>().FirstOrDefault(x => x.Username == userName);
            }
        }
        public RegEntity GetItem(string userName, string passWord)
        {
            lock (locker)
            {
                return database.Table<RegEntity>().FirstOrDefault(x => x.Username == userName && x.Password == passWord);
            }
        }
        public int SaveItem(RegEntity item)
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    //Update Item  
                    database.Update(item);
                    return item.ID;
                }
                else
                {
                    //Insert item  
                    return database.Insert(item);
                }
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<RegEntity>(id);
            }
        }
    }
}