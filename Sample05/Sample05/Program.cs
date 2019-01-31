using System;
using Sample05.Model;
using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Sample05
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            test_mult_insert();
        }

        /// <summary>
        /// 单条数据插入
        /// </summary>
        static void test_insert()
        {
            var content = new Content
            {
                title = "标题1",
                content = "内容1"
            };
            using (var conn = new SqlConnection("Data Source=127.0.0.1;User ID=sa;Password=123;Initial Catalog=master;Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"INSERT INTO [content](title,[content],status,add_time,modify_time) values(@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, content);
                Console.WriteLine($"test_insert:插入了{result}条数据");
                Console.ReadLine();

            }
        }

        /// <summary>
        /// 批量数据插入
        /// </summary>
        static void test_mult_insert()
        {
            List<Content> contents = new List<Content>()
            {
                  new Content
                    {
                        title = "批量插入标题1",
                        content = "批量插入内容1",

                    },
                       new Content
                    {
                        title = "批量插入标题2",
                        content = "批量插入内容2",

                    }
            };
            using (var conn = new SqlConnection("Data Source=127.0.0.1;User ID=sa;Password=123;Initial Catalog=master;Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"INSERT INTO [content](title,[content],status,add_time,modify_time) values(@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, contents);
                Console.WriteLine($"test_insert:插入了{result}条数据");
                Console.ReadLine();

            }

        }


    }
}
