using System;
using Xamarin.Forms;

namespace SQLiteSample000
{
    public partial class SQLiteSamplePage000 : ContentPage
    {
        public SQLiteSamplePage000()
        {
            //InitializeComponent();

            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };

            //Userテーブルに適当なデータを追加
            UserModel.insertUser("鈴木","15");
            UserModel.insertUser("田中", "13");
            UserModel.insertUser("斎藤", "18");

            //Userテーブルの行データを取得
            var query = UserModel.selectUser();

            foreach (var user in query)
            {

                //Userテーブルの名前列をLabelに書き出す
                layout.Children.Add(new Label { Text = user.Name });
                layout.Children.Add(new Label { Text = user.Ban });
            }

            Content = layout;
        }


    }
}