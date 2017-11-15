using System;
using System.Collections.Generic;
using SQLite;

namespace SQLiteSample000
{
    //テーブル名を指定
    [Table("User")]
    public class UserModel
    {
        //プライマリキー　自動採番されます
        [PrimaryKey, AutoIncrement, Column("_id")]
        //idカラム
        public int Id { get; set; }
        //名前カラム
        public string Name { get; set; }

        //Userテーブルに行追加するためのメソッドです
        public static void insertUser(string name)
        {
            //データベースに接続します
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースにUserテーブルを作成します
                    db.CreateTable<UserModel>(); //赤線出てたから<UserModel>付けた

                    //Userテーブルに行追加します
                    db.Insert(new UserModel() { Name = name });

                    db.Commit();

                }
                catch (Exception e)
                {

                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);

                }
            }
        }

        //Userテーブルの行データを取得します
        public static List<UserModel> selectUser() //赤線出てたから<UserModel>付けた
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースに指定したSQLを発行します
                    return db.Query<UserModel>("SELECT * FROM [User] "); //赤線出てたから<UserModel>付けた

                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }
    }
}
