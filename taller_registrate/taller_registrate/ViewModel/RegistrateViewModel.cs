using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using taller_registrate.Model;
using Xamarin.Forms;

namespace taller_registrate.ViewModel
{
    internal class RegistrateViewModel : BaseViewModel
    {
        #region Atributos
        public string Nombre;
        public string Apellido;
        public string Contraseña;
        public string Comfirmar_Passw;
        public string Email;
        #endregion

        #region Propiedades
        public string NombreTxt
        {
            get { return Nombre; }
            set { SetValue(ref this.Nombre, value); }
        }

        public string ApellidoTxt
        {
            get { return Apellido; }
            set { SetValue(ref this.Apellido, value); }
        }

        public string ContraseñaTxt
        {
            get { return Contraseña; }
            set { SetValue(ref this.Contraseña, value); }
        }
        public string ComfirmarTxt
        {
            get { return Comfirmar_Passw; }
            set { SetValue(ref this.Comfirmar_Passw, value); }
        }

        public string EmailTxt
        {
            get { return Email; }
            set { SetValue(ref this.Email, value); }
        }


        #endregion

        #region Commands
        public ICommand RegisterCommand
        {
            get { return new RelayCommand(RegisterMethods); }
        }
        #endregion

        #region Methods
        public async void RegisterMethods()
        {
            string _query = "SELECT * FROM UserModel WHERE Name = '" + NombreTxt.ToString() + "' AND LastName = '" + ApellidoTxt.ToString() + "' AND Email = '" + EmailTxt.ToString() + "' AND Password = '" + ContraseñaTxt.ToString() + "' ";
            List<UserModel> ListUser;
            ListUser = App.Db.QueryUserModel(_query).Result;

            Boolean datos = true;

            if (ContraseñaTxt.ToString() != Comfirmar_Passw.ToString())
            {
                datos = false;
                await Application.Current.MainPage.DisplayAlert("Contrseña Diferentes", "Las contraseñas digitadas no son las correctas por favor vuelve a intentarlo", "ok");
            }
            else if(datos == true)
            {
                UserModel user = new UserModel();
                user.Name = NombreTxt;
                user.LastName = ApellidoTxt;
                user.Email = EmailTxt;
                user.Password = ContraseñaTxt;

                var resul = App.Db.SaveUserModelAsync(user);
            }

            if (ListUser.Count>0)
            {
               await Application.Current.MainPage.DisplayAlert("Te damos la bienvenida a Xamarin","este aplicativo es de prueba tu informacion a sido guardada", "ok");
            }
            else
            {
               await Application.Current.MainPage.DisplayAlert("Error", "No se pudo guardar tus datos por favor vuelve a intentarlo", "ok");
            }
        }
        #endregion
    }
}
