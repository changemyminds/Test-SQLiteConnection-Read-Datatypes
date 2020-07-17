## Test SQLiteConnection read Datatypes

### Test Library
https://www.nuget.org/packages/SQLite/3.13.0 <br>
https://www.nuget.org/packages/System.Data.SQLite.Core/1.0.113.1 <br>

### Issue
https://stackoverflow.com/questions/62846033/sqliteconnection-read-smallint-overflow

### SQLite Datatypes
https://www.sqlite.org/datatype3.html

#### Range is 0 ~ 255, 0 ~ (2^8 -1)
- TINYINT

#### Range is -32768 ~ 32767, (-2^15) ~ (2^15 -1)
- SMALLINT

#### Range is -2147483648 ~ 2147483647, (-2^31) ~ (2^31 -1)
- INT
- MEDIUMINT

#### Range is over than -9223372036854775808 ~ 9223372036854775807, (-2^63) ~ (2^63 -1) that will cast to the exponent value
- INTEGER
- INT2
- INT8
- BIGINT
- UNSIGNED BIG INT


