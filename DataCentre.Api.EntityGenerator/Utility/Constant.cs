using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.EntityGenerator.Utility
{
    public class Constant
    {
        public static string PLEASE_SELECT_DB_TYPE { get; } = "請選擇DB類型!";
        public static string DB_CONN_MYSQL { get; } = "server={0};port={1};user id={2};password={3};database={4};charset=utf8;Pooling=true;min pool size=5;max pool size=1024;connect timeout = 20;SslMode=none;";
        public static string DB_CONN_MS_SQL { get; } = "data source={0};initial catalog={3};password={2};persist security info=True;user id={1};packet size=4096";
        public static string TEST_OPEN_CONN_ERROR { get; } = "測試連線失敗，請洽工程人員";
        public static string TEST_OPEN_CONN_OK { get; } = "測試連線成功";
        public static string UNDEFINED_DB_TYPE { get; } = "未定義的資料庫類型";
        public static string PLEASE_INPUT_DB_IP { get; } = "請輸入資料庫IP";
        public static string PLEASE_INPUT_DB_NAME { get; } = "請輸入資料庫名稱";
        public static string PLEASE_INPUT_DB_USERNAME { get; } = "請輸入資料庫使用者帳號";
        public static string PLEASE_INPUT_DB_PASSWORD { get; } = "請輸入資料庫使用者密碼";
        public static string PLEASE_INPUT_DB_PORT { get; } = "請輸入資料庫阜號";
        public static string EXECUTE_SUCCESS { get; } = "執行成功";
        public static string MYSQL { get; } = "MYSQL";
        public static string MS_SQL { get; } = "MSSQL";
        public static string PLEASE_INPUT_OUT_PATH { get; } = "請設定程式輸出路徑!";
        public static string? DB_SET_JSON_PATH { get; } = @".\dbSet.json";
        public static string? MYSQL_LIST_TABLE_SQL { get; } =
                                @"SELECT TABLE_NAME TableName
                                    FROM INFORMATION_SCHEMA.TABLES
	                               where table_schema='{0}'";
        public static string PLEASE_GENERATE_TABLE_LIST { get; }="請先產生Table列表!";
        public static string? MYSQL_SELECT_COLUMN_SQL { get; } =
                                @"SELECT COLUMN_NAME ColumnName, DATA_TYPE Type, COLUMN_KEY IsPrimaryKey, COLUMN_COMMENT Comment
                                    FROM INFORMATION_SCHEMA.COLUMNS
	                               where table_schema='{0}' AND TABLE_NAME = '{1}' ORDER BY ORDINAL_POSITION;";
        public static string? MS_SQL_SELECT_COLUMN_SQL { get; } =
                                @"SELECT c.name ColumnName,  y.name Type, c.is_identity IsPrimaryKey, C1.value Comment
                                    FROM sys.tables t 
                                    JOIN sys.columns c ON t.object_id = c.object_id
                                    JOIN sys.types y ON y.user_type_id = c.user_type_id
                                    LEFT JOIN sys.extended_properties C1 ON C1.major_id = c.object_id AND C1.minor_id = c.column_id
                                    WHERE t.name = '{0}'
                                    order by c.column_id;";
        public static string PLEASE_INPUT_NAMESPACE { get; } = "請輸入命名空間!";
        public static string? MS_SQL_LIST_TABLE_SQL { get; } = "select t.name TableName FROM sys.tables t ";
    }
}
