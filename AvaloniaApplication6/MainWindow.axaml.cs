using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;

namespace AvaloniaApplication6;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }


    private async void ButtonOpenFile_OnClick(object? sender, RoutedEventArgs e)
    {
        var files = await TopLevel.GetTopLevel(this).StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Выбрать файл",
            AllowMultiple = false
        });

        if (files.Count == 0)
        {
            Output.Text = "Не выбрано ни одного файла";
            return;
        }
        
        var file = files[0];
        InputPathFile.Text = file.Path.AbsolutePath;
    }
}