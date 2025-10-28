using Microsoft.Maui.Controls;

namespace HabitTracker.Views;

public partial class FormPage : ContentPage
{
    public FormPage()
    {
        InitializeComponent();
    }

    // Синхронизация возраста
    private void OnAgeChanged(object sender, ValueChangedEventArgs e)
    {
        if (sender == AgeSlider)
        {
            AgeStepper.Value = e.NewValue;
        }
        else if (sender == AgeStepper)
        {
            AgeSlider.Value = e.NewValue;
        }

        AgeLabel.Text = ((int)e.NewValue).ToString();
    }

    // Проверка номера телефона
    private void OnPhoneChanged(object sender, TextChangedEventArgs e)
    {
        if (PhoneEntry.Text?.Length == 11)
            PhoneEntry.TextColor = Colors.Green;
        else
            PhoneEntry.TextColor = Colors.Red;
    }

    // Управление кнопкой
    private void OnAgreementToggled(object sender, ToggledEventArgs e)
    {
        SubmitButton.IsEnabled = e.Value;
    }

    // Обработка нажатия кнопки
    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        string message =
            $"ФИО: {LastNameEntry.Text} {FirstNameEntry.Text} {MiddleNameEntry.Text}\n" +
            $"Возраст: {AgeLabel.Text}\n" +
            $"Телефон: {PhoneEntry.Text}";

        await DisplayAlert("Форма отправлена", message, "OK");
    }
}