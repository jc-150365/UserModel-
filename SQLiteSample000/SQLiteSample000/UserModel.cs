using System;
using System.Collections.Generic;
using SQLite;

namespace SQLiteSample000
{
    //テーブル名を指定
    [Table("User")]
    public class UserModel
    {
        //主キーー　自動採番される
        [PrimaryKey, AutoIncrement, Column("_id")]
        //id列
        public int Id { get; set; }
        //名前列
        public string Name { get; set; }//

        public string Ban { get; set; }

        //画像列(仮)
        public byte[] Picture { get; set; }

        //Userテーブルに行追加するためのメソッド
        public static void insertUser(string name, string ban)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースにUserテーブルを作成する
                    db.CreateTable<UserModel>(); //赤線出てたから<UserModel>付けた

                    //Userテーブルに行追加する
                    db.Insert(new UserModel() { Name = name , Ban = ban});

                    db.Commit();

                }
                catch (Exception e)
                {

                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);

                }
            }
        }

        /*画像を追加するためのメソッド(ここにエンコードする処理書くのかと思う。それか上のインサートするメソッドのとこか。)
        public static void inserPicture(byte[] picture)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースにUserテーブルを作成する(画像の時もこれいるのか?)
                    db.CreateTable<UserModel>(); //赤線出てたから<UserModel>付けた

                    //Userテーブルに行追加する
                    db.Insert(new UserModel() { Picture = picture });

                    db.Commit();

                }
                catch (Exception e)
                {

                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);

                }
            }
        }*/

        //Userテーブルの行データを取得するメソッド
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
