using NUnit.Framework;
using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace TestSQLiteDataType
{
    [TestFixture]
    public class NUnitTestSQLiteType
    {
        public readonly string Db_Path = @"C:\TestSQLite\{0}.db";

        private readonly string TINYINT = "TINYINT";
        private readonly string SMALLINT = "SMALLINT";
        private readonly string MEDIUMINT = "MEDIUMINT";
        private readonly string INT = "INT";
        private readonly string INT2 = "INT2";
        private readonly string INT8 = "INT8";
        private readonly string INTEGER = "INTEGER";
        private readonly string BIGINT = "BIGINT";
        private readonly string UNSIGNEDBIGINT = "UNSIGNEDBIGINT";

        private readonly string UNKOWNDATATYPE = "UNKOWNDATATYPE";

        #region Range is 0 ~ 255, 0 ~ (2^8 -1)
        [Test]
        public void TestTINYINT()
        {
            CreateTable(TINYINT);

            TestTINYINT("0");   // actual: 0
            TestTINYINT("255");   // actual: 255

            //TestTINYINT("256"); // actual: 0
            //TestTINYINT("-1");  // actual: 255

            // Range is 0 ~ 255, 0 ~ (2^8 -1)
        }
        public void TestTINYINT(string value) => TestSupport(TINYINT, value);
        #endregion

        #region Range is -32768 ~ 32767, (-2^15) ~ (2^15 -1)
        [Test]
        public void TestSMALLINT()
        {
            CreateTable(SMALLINT);

            TestSMALLINT("-32768");   // actual: -32768
            TestSMALLINT("32767");    // actual: 32767

            //TestSMALLINT("32768");    // actual: -32768
            //TestSMALLINT("-32769");   // actual: 32767

            // Range is -32768 ~ 32767, (-2^15) ~ (2^15 -1)
        }
        public void TestSMALLINT(string value) => TestSupport(SMALLINT, value);
        #endregion

        #region Range is -2147483648 ~ 2147483647, (-2^31) ~ (2^31 -1)
        [Test]
        public void TestINT()
        {
            CreateTable(INT);

            TestINT("-2147483648");    // actual: -2147483648
            TestINT("2147483647");     // actual: 2147483647

            //TestINT("2147483648");     // actual: -2147483648
            //TestINT("-2147483649");    // actual: 2147483647

            // Range is -2147483648 ~ 2147483647, (-2^31) ~ (2^31 -1)
        }
        public void TestINT(string value) => TestSupport(INT, value);

        [Test]
        public void TestMEDIUMINT()
        {
            CreateTable(MEDIUMINT);

            TestMEDIUMINT("-2147483648");    // actual: -2147483648
            TestMEDIUMINT("2147483647");     // actual: 2147483647

            //TestMEDIUMINT("2147483648");     // actual: -2147483648
            //TestMEDIUMINT("-2147483649");    // actual: 2147483647

            // Range is same as INT
        }
        public void TestMEDIUMINT(string value) => TestSupport(MEDIUMINT, value);
        #endregion

        #region Range is over than - 9223372036854775808 ~9223372036854775807, (-2 ^ 63) ~(2 ^ 63 - 1) that will cast the to exponent value
        [Test]
        public void TestINTEGER()
        {
            CreateTable(INTEGER);
            TestINTEGER("-9223372036854775808");    // actual: -9223372036854775808
            TestINTEGER("9223372036854775807");     // actual: 9223372036854775807

            //TestINTEGER("9223372036854775808");     // actual: 9223372036854780000
            //TestINTEGER("-9223372036854775809");    // actual: -9223372036854780000

            // Range is over than - 9223372036854775808 ~9223372036854775807, (-2 ^ 63) ~(2 ^ 63 - 1) 
            // that will cast the to exponent value
        }
        public void TestINTEGER(string value) => TestSupport(INTEGER, value);

        [Test]
        public void TestINT2()
        {
            CreateTable(INT2);

            TestINT2("-9223372036854775808");    // actual: -9223372036854775808
            TestINT2("9223372036854775807");     // actual: 9223372036854775807

            //TestINT2("9223372036854775808");     // actual: 9223372036854780000
            //TestINT2("-9223372036854775809");    // actual: -9223372036854780000

            // Range is same as INTEGER
        }
        public void TestINT2(string value) => TestSupport(INT2, value);

        [Test]
        public void TestINT8()
        {
            CreateTable(INT8);

            TestINT8("-9223372036854775808");    // actual: -9223372036854775808
            TestINT8("9223372036854775807");     // actual: 9223372036854775807

            //TestINT8("9223372036854775808");     // actual: 9223372036854780000
            //TestINT8("-9223372036854775809");    // actual: -9223372036854780000

            // Range is same as INTEGER
        }
        public void TestINT8(string value) => TestSupport(INT8, value);

        [Test]
        public void TestBIGINT()
        {
            CreateTable(BIGINT);
            TestBIGINT("-9223372036854775808");    // actual: -9223372036854775808
            TestBIGINT("9223372036854775807");     // actual: 9223372036854775807

            //TestBIGINT("9223372036854775808");     // actual: 9223372036854780000
            //TestBIGINT("-9223372036854775809");    // actual: -9223372036854780000

            // Range is same as INTEGER
        }
        public void TestBIGINT(string value) => TestSupport(BIGINT, value);

        //UNSIGNEDBIGINT

        [Test]
        public void TestUNSIGNEDBIGINT()
        {
            CreateTable(UNSIGNEDBIGINT, UNSIGNEDBIGINT, "UNSIGNED BIG INT");
            TestUNSIGNEDBIGINT("-9223372036854775808");    // actual: -9223372036854775808
            TestUNSIGNEDBIGINT("9223372036854775807");     // actual: 9223372036854775807

            //TestUNSIGNEDBIGINT("9223372036854775808");     // actual: 9223372036854780000
            //TestUNSIGNEDBIGINT("-9223372036854775809");    // actual: -9223372036854780000

            // Range is same as INTEGER
        }
        public void TestUNSIGNEDBIGINT(string value) => TestSupport(UNSIGNEDBIGINT, value);

        [Test]
        public void TestUNKOWNDATATYPE()
        {
            CreateTable(UNKOWNDATATYPE, UNKOWNDATATYPE);

            TestUNKOWNDATATYPE("-9223372036854775808");    // actual: -9223372036854775808
            TestUNKOWNDATATYPE("9223372036854775807");     // actual: 9223372036854775807

            //TestUNKOWNDATATYPE("9223372036854775808");     // actual: 9223372036854780000
            //TestUNKOWNDATATYPE("-9223372036854775809");    // actual: -9223372036854780000

            // Range is same as INTEGER
        }
        public void TestUNKOWNDATATYPE(string value) => TestSupport(UNKOWNDATATYPE, value);
        #endregion

        private void TestSupport(string tableAndcolumn, string value) => TestSupport(tableAndcolumn, tableAndcolumn, value);

        private void TestSupport(string table, string column, string value)
        {
            ExecuteInsertSQL(table, column, value);
            TestValue(table, (reader) =>
            {
                while (reader.Read())
                {
                    Assert.AreEqual(value, reader.GetDecimal(1).ToString());
                }
            });
            ExecuteDeleteSQL(table);
        }

        private void ExecuteDeleteSQL(string table)
        {
            ExecuteNonQuery(table, $"DELETE FROM {table}");
        }

        private void ExecuteInsertSQL(string table, string column, string value)
        {
            var insertSql = $"INSERT INTO {table}({column}) VALUES ({value})";
            ExecuteNonQuery(table, insertSql);
        }


        private void CreateTable(string tableAndColumn)
        {
            CreateTable(tableAndColumn, tableAndColumn);
        }

        private void CreateTable(string tableAndColumn, string column)
        {
            CreateTable(tableAndColumn, column, column);
        }

        private void CreateTable(string table, string column, string type)
        {
            var dbPath = GetDbPath(table);
            if (File.Exists(dbPath)) File.Delete(dbPath);
            var sql = $"CREATE TABLE IF NOT EXISTS {table}(ID INTEGER PRIMARY KEY AUTOINCREMENT, {column} {type} NOT NULL)";
            ExecuteNonQuery(table, sql);
        }

        private void ExecuteNonQuery(string table, string sql)
        {
            TestSqlite(table, (cmd) =>
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            });
        }

        private void TestValue(string table, Action<IDataReader> action)
        {
            var sqlQuery = $"SELECT * FROM {table}";
            TestSqlite(table, (cmd) =>
            {
                cmd.CommandText = sqlQuery;
                action?.Invoke(cmd.ExecuteReader());
            });
        }

        private void TestSqlite(string table, Action<IDbCommand> action)
        {
            var dbPath = GetDbPath(table);
            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {

                if (conn.State != ConnectionState.Open) conn.Open();
                var cmd = conn.CreateCommand();
                action?.Invoke(cmd);
                conn.Close();
            }
        }

        private string GetDbPath(string table)
        {
            var path = string.Format(Db_Path, table);
            var directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
            return path;
        }
    }
}
