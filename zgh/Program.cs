using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace zgh
{ 
    internal class Program
    {
        private static void Main(string[] args)
        { 
             
            ////初始化并打开
            MySqlConnection myConnection = new MySqlConnection(MySqlHelper.Conn);
            myConnection.Open();

            fun01(myConnection);

            //关闭数据库
            myConnection.Close();
            Console.Read(); 
        }
           
        /// <summary>
        /// 增删查改
        /// </summary>
        /// <param name="myConnection"></param>
        static void fun01(MySqlConnection myConnection)
        {
            //查询sql
            String sqlSearch = "select * from table01";
            //插入sql
            String sqlInsert = "insert into table01 values (3,'张三',252525)";
            //修改sql
            String sqlUpdate = "update table01 set name='wangbingbing' where id= 3";
            //删除sql
            String sqlDel = "delete from table01 where id = 3";

            MySqlCommand mysqlInsert = new MySqlCommand(sqlInsert, myConnection);
            MySqlCommand mysqlUpdate = new MySqlCommand(sqlUpdate, myConnection);
            MySqlCommand mysqlDel = new MySqlCommand(sqlDel, myConnection);
            MySqlCommand mysqlSearch = new MySqlCommand(sqlSearch, myConnection);

            getInsert(mysqlInsert);
            getUpdate(mysqlUpdate);
            getDel(mysqlDel);
            getResultset(mysqlSearch);
        }

        /// <summary>
        /// 查询并获得结果集并遍历
        /// </summary>
        /// <param name="mySqlCommand"></param>
        public static void getResultset(MySqlCommand mySqlCommand)
        {
            MySqlDataReader myDataReader = mySqlCommand.ExecuteReader();
            try
            {
                while (myDataReader.Read())
                {
                    string bookres = "";
                    bookres += myDataReader["id"];
                    bookres += myDataReader["name"];
                    bookres += myDataReader["password"];
                    Console.WriteLine(bookres);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("查询失败了！");
            }
            finally
            {
                myDataReader.Close();
            }
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="mySqlCommand"></param>
        public static void getInsert(MySqlCommand mySqlCommand)
        {
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                Console.WriteLine("插入数据失败了！" + message);
            }

        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="mySqlCommand"></param>
        public static void getUpdate(MySqlCommand mySqlCommand)
        {
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                Console.WriteLine("修改数据失败了！" + message);
            }
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="mySqlCommand"></param>
        public static void getDel(MySqlCommand mySqlCommand)
        {
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                Console.WriteLine("删除数据失败了！" + message);
            }
        }
    }
}