using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;


namespace TemperatureConverter
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TextView txtValue;
        private Button btnCelToFah, btnFahToCel;
        private double inputValue;
        private double result;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Map variables to UI elements
            txtValue = FindViewById<TextView>(Resource.Id.txtInputValue);
            btnCelToFah = FindViewById<Button>(Resource.Id.btnCelToFah);
            btnFahToCel = FindViewById<Button>(Resource.Id.btnFahToCel);

            // Link UI elements' Click event to event handlers
            btnCelToFah.Click += BtnCelToFah_Click;
            btnFahToCel.Click += BtnFahToCel_Click;

        }

        private void BtnFahToCel_Click(object sender, System.EventArgs e)
        {
            // Convert Fahrenheit To Celsius

            inputValue = inputHandling();
            if (double.IsNaN(inputValue))
            {
                displayProperMessage();
            }
            else
            {
                result = Calculation(inputValue, "FahToCel");
                displayResult(result);
            }
        }

        private void BtnCelToFah_Click(object sender, System.EventArgs e)
        {
            // Convert Celsius To Fahrenheit

            inputValue = inputHandling();
            if (double.IsNaN(inputValue))
            {
                displayProperMessage();
            }
            else
            {
                result = Calculation(inputValue, "CelToFah");
                displayResult(result);
            }
        }

        private double inputHandling()
        {
            //input error handling such as no input from user

            try
            {
                return System.Convert.ToDouble(txtValue.Text);
            }
            catch
            {
                return double.NaN;
            }
        }

        private void displayProperMessage()
        {
            Toast.MakeText(context: this, text: "Please enter a proper value", duration: ToastLength.Long).Show();
        }
        private void displayResult(double result)
        {
            Toast.MakeText(context: this, text: "The result is " + result, duration: ToastLength.Long).Show();
        }
       
        private double Calculation(double inputValue, string type)
        {
            // Converter logic
            
            if (type == "CelToFah")
            {
                result = (inputValue * 1.8) + 32;
            }
            else
            {
                //Fah to Cel
                result = (inputValue -32) * 5/9;
            }
            return result;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}