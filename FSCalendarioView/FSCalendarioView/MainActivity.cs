using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using static Android.App.DatePickerDialog;

namespace FSCalendarioView
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IOnDateSetListener
    {
        private Button btnOpenCalendario;
        private const int DATE_DIALOG = 1;
        private DateTime dt;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            dt = DateTime.Today;

            btnOpenCalendario = FindViewById<Button>(Resource.Id.btnOpenCalendar);
            btnOpenCalendario.Click += OpenCalendarClick;
            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        private void OpenCalendarClick(object sender, EventArgs eventArgs)
        {
            ShowDialog(DATE_DIALOG);
        }

        protected override Dialog OnCreateDialog(int id)
        {
            switch (id)
            {
                case DATE_DIALOG:
                    return new DatePickerDialog(this, this, dt.Year, dt.Month, dt.Day);
                    break;
                default:
                    break;
            }
            return null;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        {
            try
            {
                dt = new DateTime(year, month, dayOfMonth);
                Toast.MakeText(this, "Has seleccionado: " + dt.Day + "-" + dt.Month + "-" + dt.Year, ToastLength.Long).Show();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}

