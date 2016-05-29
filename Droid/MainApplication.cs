using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Util;

namespace CorporateBsGenerator.Droid
{
    [Application]
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }

        /// <summary>
        /// Called when the application is starting, before any activity, service,
        ///  or receiver objects (excluding content providers) have been created.
        /// </summary>
        /// <remarks>
        /// <para tool="javadoc-to-mdoc">
        /// Called when the application is starting, before any activity, service,
        ///  or receiver objects (excluding content providers) have been created.
        ///  Implementations should be as quick as possible (for example using 
        ///  lazy initialization of state) since the time spent in this function
        ///  directly impacts the performance of starting the first activity,
        ///  service, or receiver in a process.
        ///  If you override this method, be sure to call super.onCreate().
        /// </para>
        /// <para tool="javadoc-to-mdoc">
        /// <format type="text/html"><a href="http://developer.android.com/reference/android/app/Application.html#onCreate()" target="_blank">[Android Documentation]</a></format>
        /// </para>
        /// </remarks>
        /// <since version="Added in API level 1"/>
        public override void OnCreate()
        {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
            App.Logger = new DroidDeviceLogger(App.AppName);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            App.Logger.LogInfo("System", "MainApplication.OnActivityCreated");
        }

        public void OnActivityDestroyed(Activity activity)
        {
            App.Logger.LogInfo("System", "MainApplication.OnActivityDestroyed");
        }

        public void OnActivityPaused(Activity activity)
        {
            App.Logger.LogInfo("System", "MainApplication.OnActivityPaused");
        }

        public void OnActivityResumed(Activity activity)
        {
            App.Logger.LogInfo("System", "MainApplication.OnActivityResumed");
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
            App.Logger.LogInfo("System", "MainApplication.OnActivitySaveInstanceState");
        }

        public void OnActivityStarted(Activity activity)
        {
            App.Logger.LogInfo("System", "MainApplication.OnActivityStarted");
        }

        public void OnActivityStopped(Activity activity)
        {
            App.Logger.LogInfo("System", "MainApplication.OnActivityStopped");
        }
    }
}