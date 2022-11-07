using System;
using System.Collections.Generic;
using System.IO;
using taller_registrate.DataBase;
using taller_registrate.Model;
using taller_registrate.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace taller_registrate
{
    public partial class App : Application
    {
        static DataBaseQuery DataBase;

        public static DataBaseQuery Db
        {
            get
            {
                if(DataBase == null)
                {
                    DataBase = new DataBaseQuery(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBRegister.db"));
                }
                return DataBase;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new Views.registrate();
        }

        protected override void OnStart()
        {
            List<UserModel> Listusers = new List<UserModel>();

            Listusers = App.Db.GetUserModel().Result;
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
