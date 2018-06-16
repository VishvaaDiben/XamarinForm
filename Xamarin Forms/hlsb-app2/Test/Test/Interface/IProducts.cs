using System;
using SQLite;



namespace Test
{
    public interface IProducts
    {
        SQLiteConnection GetConnection();
    }
}
