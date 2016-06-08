using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Data;

namespace Many.ThirdParty.Core.Data
{
    public class IncrementalLoadingCollection<T> : ObservableCollection<T>, ISupportIncrementalLoading
    {
        Func<uint, Task<ObservableCollection<T>>> _dataFetchDelegate = null;

        public IncrementalLoadingCollection(Func<uint, Task<ObservableCollection<T>>> dataFetchDelegate)
        {
            if (dataFetchDelegate == null) throw new ArgumentNullException("dataFetchDelegate");

            this._dataFetchDelegate = dataFetchDelegate;
        }

        public bool HasMoreItems
        {
            get { return this.Count < _totalCount; }
        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            indexe += 1;
 
            if (_busy)
            {
                throw new InvalidOperationException("Only one operation in flight at a time");
            }

            _busy = true;

            return AsyncInfo.Run((c) => LoadMoreItemsAsync(c, indexe - 1));
        }

        protected async Task<LoadMoreItemsResult> LoadMoreItemsAsync(CancellationToken c, uint count)
        {
            try
            {
                this.OnLoadMoreStarted?.Invoke(count);

                // 我们忽略了CancellationToken，因为我们暂时不需要取消，需要的可以加上
                var result = await this._dataFetchDelegate(count);

                var items = result;

                if (items != null)
                {
                    foreach (var item in items)
                    {
                        this.Add(item);
                    }
                }

                // 加载完成事件
                this.OnLoadMoreCompleted?.Invoke(items == null ? 0 : items.Count);

                return new LoadMoreItemsResult { Count = items == null ? 0 : (uint)items.Count };
            }
            finally
            {
                _busy = false;
            }
        }


        public delegate void LoadMoreStarted(uint count);
        public delegate void LoadMoreCompleted(int count);

        public event LoadMoreStarted OnLoadMoreStarted;
        public event LoadMoreCompleted OnLoadMoreCompleted;

        private uint _totalCount = 100;
        private uint indexe = 0;
        protected bool _busy = false;
    }

}
