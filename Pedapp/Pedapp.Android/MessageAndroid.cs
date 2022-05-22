using System;
using Pedapp;
using Xamarin.Forms;
using Android.Widget;

[assembly: Dependency(typeof(MessageAndroid))]
namespace Pedapp

{
    public class MessageAndroid : IMessage
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
    }
}
