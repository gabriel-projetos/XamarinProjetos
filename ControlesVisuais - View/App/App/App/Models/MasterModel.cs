using App.Controles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.Models
{
    public class MasterModel
    {
        public ICommand GoActivityIndicator { get; set; }
        public ICommand GoProgressBar { get; set; }
        public ICommand GoBoxView { get; set; }
        public ICommand GoLabel { get; set; }
        public ICommand GoButton { get; set; }
        public ICommand GoEntryEditor { get; set; }
        public ICommand GoDatePicker { get; set; }
        public ICommand GoTimePicker { get; set; }
        public ICommand GoPickerPage { get; set; }
        public ICommand GoSearchPage { get; set; }
        public ICommand GoSliderStepper { get; set; }
        public ICommand GoSwitch { get; set; }
        public ICommand GoImagePage { get; set; }
        public ICommand GoListView { get; set; }
        public ICommand GoTableViewPage { get; set; }

        

        public MasterModel()
        {
            TrocaTelaCommand();
        }
        
        private void TrocaTelaCommand()
        {
            var pageActivity = new ActivityIndicatorPage();
            GoActivityIndicator = new Command(() =>
            {
                MessagingCenter.Send<ActivityIndicatorPage>(pageActivity, "GoActivity");
            });

            var pageProgressBar = new ProgressBarPage();
            GoProgressBar = new Command(() =>
            {
                MessagingCenter.Send<ProgressBarPage>(pageProgressBar, "GoProgressBar");
            });

            var pageBoxView= new BoxViewPage();
            GoBoxView = new Command(() =>
            {
                MessagingCenter.Send<BoxViewPage>(pageBoxView, "GoBoxView");
            });

            var pageLabel = new LabelPage();
            GoLabel = new Command(() =>
            {
                MessagingCenter.Send<LabelPage>(pageLabel, "GoLabel");
            });

            var pageButton = new ButtonPage();
            GoButton = new Command(() =>
            {
                MessagingCenter.Send<ButtonPage>(pageButton, "GoButton");
            });

            var pageEntryEditor = new EntryEditorPage();
            GoEntryEditor = new Command(() =>
            {
                MessagingCenter.Send<EntryEditorPage>(pageEntryEditor, "GoEntryEditor");
            });

            var pageDatePicker = new DatePickerPage();
            GoDatePicker = new Command(() =>
            {
                MessagingCenter.Send<DatePickerPage>(pageDatePicker, "GoDatePicker");
            });

            var pageTimePicker = new TimePickerPage();
            GoTimePicker = new Command(() =>
            {
                MessagingCenter.Send<TimePickerPage>(pageTimePicker, "GoTimePicker");
            });

            var pagePickerPage = new PickerPage();
            GoPickerPage = new Command(() =>
            {
                MessagingCenter.Send<PickerPage>(pagePickerPage, "GoPickerPage");
            });

            var pageSearchBar = new SearchBarPage();
            GoSearchPage = new Command(() =>
            {
                MessagingCenter.Send<SearchBarPage>(pageSearchBar, "GoSearchPage");
            });

            var pageSliderStepper = new SliderStepperPage();
            GoSliderStepper = new Command(() =>
            {
                MessagingCenter.Send<SliderStepperPage>(pageSliderStepper, "GoSliderStepper");
            });
            
            var pageSwitch = new SwitchPage();
            GoSwitch = new Command(() =>
            {
                MessagingCenter.Send<SwitchPage>(pageSwitch, "GoSwitch");
            });

            var imagePage = new ImagePage();
            GoImagePage = new Command(() =>
            {
                MessagingCenter.Send<ImagePage>(imagePage, "GoImagePage");
            });

            var listView = new ListViewPage();
            GoListView = new Command(() =>
            {
                MessagingCenter.Send<ListViewPage>(listView, "GoListView");
            });

            var tablePage = new TableViewPage();
            GoTableViewPage = new Command(() =>
            {
                MessagingCenter.Send<TableViewPage>(tablePage, "GoTableViewPage");
            });
        }
    }
}
