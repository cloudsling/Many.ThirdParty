using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Data;

namespace Many.ThirdParty.Core.Interface
{
    public class IncrementalLoadingCollection<T> : ObservableCollection<T>, ISupportIncrementalLoading
    {
        private readonly Func<uint, Task<ObservableCollection<T>>> _dataFetchDelegate;

        public IncrementalLoadingCollection(Func<uint, Task<ObservableCollection<T>>> dataFetchDelegate)
        {
            if (dataFetchDelegate == null) throw new ArgumentNullException(nameof(dataFetchDelegate));

            _dataFetchDelegate = dataFetchDelegate;
        }

        public bool HasMoreItems => Count < TotalCount;

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            _indexe += 1;

            if (Busy)
            {
                throw new InvalidOperationException("Only one operation in flight at a time");
            }

            Busy = true;

            return AsyncInfo.Run(c => LoadMoreItemsAsync(c, _indexe - 1));
        }

        protected async Task<LoadMoreItemsResult> LoadMoreItemsAsync(CancellationToken c, uint count)
        {
            try
            {
                OnLoadMoreStarted?.Invoke(count);

                // 我们忽略了CancellationToken，因为我们暂时不需要取消，需要的可以加上
                var result = await _dataFetchDelegate(count);

                var items = result;

                if (items != null)
                {
                    foreach (var item in items)
                    {
                        Add(item);
                    }
                }

                // 加载完成事件
                OnLoadMoreCompleted?.Invoke(items?.Count ?? 0);

                return new LoadMoreItemsResult { Count = items == null ? 0 : (uint)items.Count };
            }
            finally
            {
                Busy = false;
            }
        }

        public delegate void LoadMoreStarted(uint count);
        public delegate void LoadMoreCompleted(int count);

        public event LoadMoreStarted OnLoadMoreStarted;
        public event LoadMoreCompleted OnLoadMoreCompleted;

        private const uint TotalCount = 100;
        private uint _indexe;
        protected bool Busy;
    }

}
