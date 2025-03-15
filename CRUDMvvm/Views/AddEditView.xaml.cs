using CRUDMvvm.Models;
using CRUDMvvm.ViewModels;

namespace CRUDMvvm.Views;

public partial class AddEditView : ContentPage
{
	private AddEditViewModel viewModel;

	public AddEditView()
	{
		InitializeComponent();
	}

	public AddEditView(Proveedor proveedor) {
        InitializeComponent();
		viewModel = new AddEditViewModel(proveedor);
		this.BindingContext = viewModel;
    }
}