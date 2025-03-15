using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUDMvvm.Models;
using CRUDMvvm.Services;
using CRUDMvvm.Views;
using System.Collections.ObjectModel;


namespace CRUDMvvm.ViewModels
{
    public partial class MainViewModel : ObservableObject

    {
        [ObservableProperty]
        private ObservableCollection<Proveedor> proveedorCollection = new ObservableCollection<Proveedor>();
        private readonly ProveedorService _service;

        public MainViewModel()
        {
            _service = new ProveedorService();

        }

        private void Alerta(string Titulo, string Mensaje)

        {

            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));

        }

        public void GetAll() 
        {

            var getAll = _service.GetAll();

            if (getAll.Count > 0) 
            {
                ProveedorCollection.Clear();
                foreach (var proveedor in getAll)
                {
                    ProveedorCollection.Add(proveedor);
                }
            }
        }
        
        [RelayCommand]
        private async Task GoToAddEditView()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddEditView());
        }

        [RelayCommand]
        private async Task SelectProveedor(Proveedor proveedor) 
        {
            try
            {
                const string ACTUALIZAR = "Actualiza";
                const string ELIMINAR = "Eliminar";

                string res = await App.Current!.MainPage!.DisplayActionSheet("OPCIONES", "Cancelar", null, ACTUALIZAR, ELIMINAR);

                if (res == ACTUALIZAR)
                {
                    await App.Current!.MainPage!.Navigation.PushAsync(new AddEditView(proveedor));
                }
                else if (res == ELIMINAR)
                {
                    bool respuesta = await App.Current!.MainPage!.DisplayAlert("ELIMINAR PROVEEDOR", "Desea eliminar empleadp?","Si","No");
                    if (respuesta) {
                        int del = _service.Delete(proveedor);

                        if (del > 0)
                        {
                            Alerta("Eliminar Empleado", "Proveedor Eliminado correctamente");
                        }
                        else {
                            Alerta("Eliminar Empleado", "NO se elimino Proveedor");
                        }
                    }
                }
            }
            catch(Exception ex) {
                Alerta("ERROR", ex.Message);
            }
        }
    }
}
