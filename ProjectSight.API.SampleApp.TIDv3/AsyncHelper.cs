using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectSight.API.SampleApp.TIDv3
{
    public static class AsyncHelper
    {
        private static readonly TaskFactory TaskFactory = new TaskFactory(CancellationToken.None, TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);

        /// <summary>
        /// Execute task on a Thread Pool thread, returning when task is completed
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <returns>Task result</returns>
        /// <remarks>Exceptions from task are rethrown into the callers context</remarks>
        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
        {
            // Exceptions handled by caller

            var cultureUi = CultureInfo.CurrentUICulture;
            var culture = CultureInfo.CurrentCulture;

            var result = TaskFactory.StartNew(() =>
                                              {
                                                  Thread.CurrentThread.CurrentCulture = culture;
                                                  Thread.CurrentThread.CurrentUICulture = cultureUi;

                                                  return func();
                                              }).Unwrap().GetAwaiter().GetResult();

            return result;
        }
    }
}
