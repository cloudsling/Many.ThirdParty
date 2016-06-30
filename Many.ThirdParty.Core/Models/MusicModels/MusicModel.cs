using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Web.Http;
using Many.ThirdParty.Core.Commands;
using Many.ThirdParty.Core.Commons;
using Many.ThirdParty.Core.Interface;
using Many.ThirdParty.Core.Models.CommonModels;
using Many.ThirdParty.Core.Tools;
using Newtonsoft.Json;

namespace Many.ThirdParty.Core.Models.MusicModels
{
    public partial class MusicModel : ViewModelBase, IComments
    {
        public string Id { get; set; }

        public string Cover { get; set; }

        public string Title { get; set; }

        public string Platform { get; set; }

        public string Story_Title { get; set; }

        private string _story;
        public string Story
        {
            get { return _story; }
            set { _story = new StringBuilder(value).Replace("<br>", "").ToString(); }
        }

        public string Lyric { get; set; }

        public string Info { get; set; }

        public string IsFirst { get; set; }

        public string Music_Id { get; set; }

        public string Charge_Edt { get; set; }

        public string RelatedTo { get; set; }

        public string PraiseNum { get; set; }

        public string ShareNum { get; set; }

        public string CommentNum { get; set; }

        public string MakeTime { get; set; }

        public string Read_Num { get; set; }

        public Author Story_Author { get; set; }

        public Author Author { get; set; }


        private string _someTitle;
        public string SomeTitle
        {
            get { return _someTitle; }
            set
            {
                SetProperty(ref _someTitle, value);
            }
        }

        public AsyncCommand AudioCommand { get; set; }

        public Command UiCommand { get; set; }

        public ObservableCollection<CommentModel> HotComments { get; set; }

        public ObservableCollection<CommentModel> NormalComments { get; set; }

        public async Task RefreshCommentsCollection(string uri)
        {
            foreach (var item in await DataHelper.GetCommentJsonArrayAsync(uri))
            {
                var tem = JsonConvert.DeserializeObject<CommentModel>(item.Stringify());

                if (tem.Type == "0")
                {
                    HotComments.Add(tem);
                }
                else
                {
                    NormalComments.Add(tem);
                }
            }
        }
    }

    internal enum NewType
    {
        OldVer,
        NewVer,
    }

    public partial class MusicModel
    {
        public MusicModel()
        {
            UiCommand = new Command(UpdateUi);
            AudioCommand = new AsyncCommand(AudioPlayStart);

            HotComments = new ObservableCollection<CommentModel>();
            NormalComments = new ObservableCollection<CommentModel>();

            InitializeProperties();
        }

        // private readonly MediaElement _ele = new MediaElement();

        private async Task AudioPlayStart(object obj)
        {
            PlayImage = !PlayImage;

            await new MessageDialog("播放功能正在施工中。。。。。").ShowAsync();
            //if (_ele.CurrentState == MediaElementState.Playing)
            //{
            //    if (_ele.CanPause)
            //        _ele.Stop();
            //    return;
            //}

            //string audioUri = obj as string;

            //using (InMemoryRandomAccessStream memoryStream = new InMemoryRandomAccessStream())
            //{
            //    using (HttpClient client = new HttpClient())
            //    {
            //        var buff = await client.GetBufferAsync(new Uri(audioUri));

            //        await memoryStream.ReadAsync(buff, buff.Length, InputStreamOptions.None);

            //        _ele.SetSource(memoryStream, string.Empty);
            //        _ele.Play();

            //    }
            //}
        }

        private void UpdateUi(object obj)
        {
            UpdateOldUi(_index);

            int oldIndex = Convert.ToInt32(obj);

            _index = oldIndex;

            UpdateNewUi(_index);

            SomeTitle = SomeTitleContent[_index];
        }

        private void UpdateOldUi(int index)
        {
            ChangePanelVis(index, NewType.OldVer);
            ChangeBtpCpl(index, NewType.OldVer);
        }
        private void UpdateNewUi(int index)
        {
            ChangePanelVis(index, NewType.NewVer);
            ChangeBtpCpl(index, NewType.NewVer);
        }

        private void ChangeBtpCpl(int index, NewType type)
        {
            List<BitmapImage> list;
            switch (type)
            {
                case NewType.OldVer:
                    list = DefaultImage;
                    break;
                case NewType.NewVer:
                    list = ActivedImage;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            switch (index)
            {
                case 0:
                    StoryImage = list[index];
                    return;
                case 1:
                    LyricImage = list[index];
                    return;
                case 2:
                    AboutImage = list[index];
                    return;
            }
        }
        private void ChangePanelVis(int index, NewType type)
        {
            Visibility vis;
            switch (type)
            {
                case NewType.OldVer:
                    vis = Visibility.Collapsed;
                    break;
                case NewType.NewVer:
                    vis = Visibility.Visible;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            switch (index)
            {
                case 0:
                    StoryPanelVis = vis;
                    return;
                case 1:
                    LyricPanelVis = vis;
                    return;
                case 2:
                    AboutPanelVis = vis;
                    return;
            }
        }

        private void InitializeProperties()
        {
            PlayImage = true;

            StoryImage = ActivedImage[0];
            LyricImage = DefaultImage[1];
            AboutImage = DefaultImage[1];

            StoryPanelVis = Visibility.Visible;
            LyricPanelVis = Visibility.Collapsed;
            AboutPanelVis = Visibility.Collapsed;

            _index = 0;
            SomeTitle = SomeTitleContent[0];
        }

        private int _index;

        private static readonly List<string> SomeTitleContent = new List<string>
        {
            "音乐故事", "歌词", "歌曲信息"
        };

        private static readonly List<BitmapImage> ActivedImage = new List<BitmapImage>
        {
            new BitmapImage(new Uri("ms-appx:///Resources/BgImages/music_story_selected.png")),
            new BitmapImage(new Uri("ms-appx:///Resources/BgImages/music_lyric_selected.png")),
            new BitmapImage(new Uri("ms-appx:///Resources/BgImages/music_about_selected.png")),
        };

        private static readonly List<BitmapImage> DefaultImage = new List<BitmapImage>
        {
            new BitmapImage(new Uri("ms-appx:///Resources/BgImages/music_story_default.png")),
            new BitmapImage(new Uri("ms-appx:///Resources/BgImages/music_lyric_default.png")),
            new BitmapImage(new Uri("ms-appx:///Resources/BgImages/music_about_default.png")),
        };



        private BitmapImage _storyImage;
        public BitmapImage StoryImage
        {
            get { return _storyImage; }
            set { SetProperty(ref _storyImage, value); }
        }

        private BitmapImage _lyricImage;
        public BitmapImage LyricImage
        {
            get { return _lyricImage; }
            set { SetProperty(ref _lyricImage, value); }
        }

        private BitmapImage _aboutImage;
        public BitmapImage AboutImage
        {
            get { return _aboutImage; }
            set { SetProperty(ref _aboutImage, value); }
        }

        private bool _playImage;
        public bool PlayImage
        {
            get { return _playImage; }
            set
            {
                SetProperty(ref _playImage, value);
            }
        }

        private Visibility _storyPanelVis;
        public Visibility StoryPanelVis
        {
            get { return _storyPanelVis; }
            set { SetProperty(ref _storyPanelVis, value); }
        }

        private Visibility _lyricPanelVis;
        public Visibility LyricPanelVis
        {
            get { return _lyricPanelVis; }
            set { SetProperty(ref _lyricPanelVis, value); }
        }

        private Visibility _aboutPanelVis;
        public Visibility AboutPanelVis
        {
            get { return _aboutPanelVis; }
            set { SetProperty(ref _aboutPanelVis, value); }
        }
    }
}
