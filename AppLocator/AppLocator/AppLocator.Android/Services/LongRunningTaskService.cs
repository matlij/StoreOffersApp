using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using AppLocator.Utility;

namespace AppLocator.Droid.Services
{
    [Service]
    public class LongRunningTaskService : Service
    {
        CancellationTokenSource _cts;

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            _cts = new CancellationTokenSource();

            Task.Run(() =>
            {
                var locator = new TaskLocator();
                locator.RunFindOfferLocator(_cts.Token).Wait();
            });

            return StartCommandResult.Sticky;
        }

        public override void OnDestroy()
        {
            if (_cts != null)
            {
                _cts.Token.ThrowIfCancellationRequested();

                _cts.Cancel();
            }
            base.OnDestroy();
        }
    }
}