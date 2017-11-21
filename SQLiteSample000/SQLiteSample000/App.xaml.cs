﻿using System;
using Xamarin.Forms;

namespace SQLiteSample000
{
    public partial class App : Application
    {
        //データベースのパスを格納
        public static string dbPath;

        //コンストラクタの引数にstring型の引数を追加
        public App(string dbPath)
        {
            //AppのdbPathに引数のパスを設定します
            App.dbPath = dbPath;

            //InitializeComponent();

            MainPage = new SQLiteSamplePage000();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}