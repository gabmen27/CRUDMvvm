

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUDMvvm.Models;
using CRUDMvvm.Services;


namespace CRUDMvvm.ViewModels
{
    public partial class AddEditViewModel : ObservableObject
    {

        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private string direccion;

        [ObservableProperty]
        private string telefono;

        [ObservableProperty]
        private string email;

        private readonly ProveedorService _service;

        public AddEditViewModel(Proveedor proveedor) 
        {
            _service = new ProveedorService();

            id = proveedor.id;
            nombre = proveedor.Nombre;
            direccion = proveedor.Direccion;
            telefono = proveedor.numTelefono;
            email = proveedor.mail;
            
        }

        private void Alerta(string Titulo, string Mensaje)

        {

            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));

        }

        [RelayCommand]
        private async Task AddUpdate()
        {

            try
            {
                Proveedor Proveedor = new Proveedor
                {
     
                   
                   Nombre = Nombre,
                   Direccion = Direccion,
                   numTelefono = Telefono,
                   mail = Email,
                   id = Id,
                };

                if (id == 0)
                {
                    _service.Insert(Proveedor);
                }
                else {
                    _service.Update(Proveedor);
                }
                await App.Current!.MainPage!.Navigation.PopAsync();
             }
            catch (Exception ex) {

                Alerta("ERROR", ex.Message);
            }

        }

    }
}
