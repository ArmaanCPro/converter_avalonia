using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace tdl_ui.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Celsius_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        if (double.TryParse(Celsius.Text, out double C))
        {
            double F = C * 9d / 5d + 32;

            // Temporarily detach the Fahrenheit TextChanged handler to avoid recursion
            Fahrenheit.TextChanged -= Fahrenheit_OnTextChanged;
            Fahrenheit.Text = F.ToString("0.0");
            await Task.Delay(500);
            Fahrenheit.TextChanged += Fahrenheit_OnTextChanged;
        }
    }

    private async void Fahrenheit_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        if (double.TryParse(Fahrenheit.Text, out double F))
        {
            double C = (F - 32) * 5d / 9d;

            // Temporarily detach the Celsius TextChanged handler to avoid recursion
            Celsius.TextChanged -= Celsius_OnTextChanged;
            Celsius.Text = C.ToString("0.0");
            await Task.Delay(500);
            Celsius.TextChanged += Celsius_OnTextChanged;
        }
    }

}