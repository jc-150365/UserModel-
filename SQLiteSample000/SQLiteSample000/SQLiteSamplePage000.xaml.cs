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
            UserModel.insertUser("鈴木","15");//
            UserModel.insertUser("田中", "13");
            UserModel.insertUser("斎藤", "18");

 　　　　　　

            //Userテーブルの行データを取得
            var query = UserModel.selectUser();

            Button button1 = null;

            foreach (var user in query)
            {
                
                //Userテーブルの名前列をLabelに書き出す
                layout.Children.Add(button1 = new Button{ Text = user.Name });
            

            Content = layout;

            }

           
            button1.Clicked += new EventHandler(Button1_Click);
            
            
            void Button1_Click(object sender, EventArgs e)
            {
                DisplayAlert("UserModel", "ボタンが押されたんご", "OK");//
            }
        }
    }
}