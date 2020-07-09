using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using typicalEnglish.Scripts.Models;

namespace typicalEnglish.Scripts.ViewModels
{
    public class DeckPageVM: INotifyPropertyChanged
    {

        public DeckPageVM(ObservableCollection<Word> words)
        {
            Words = words;
        }

        #region Commands

        #region BackCommand
        private RelayCommand backCommand;
        public RelayCommand BackCommand
        {
            get => backCommand ?? (backCommand = new RelayCommand(obj =>
            {
                App.MainVM.Navigate("Scripts/Views/DecksPage.xaml");
            }));
        }
        #endregion

        #region AddWordCommand
        private RelayCommand addWordCommand;
        public RelayCommand AddWordCommand
        {
            get => addWordCommand ?? (addWordCommand = new RelayCommand(obj =>
            {
                Words.Insert(0, new Word());
            }));
        }
        #endregion


        #region ShowInfoCommand
        private RelayCommand showInfoCommand;
        public RelayCommand ShowInfoCommand
        {
            get => showInfoCommand ?? (showInfoCommand = new RelayCommand(obj =>
            {
                MoreVisibility = MoreVisibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
            }));
        }
        #endregion

        #region SpeakCommand
        private MediaPlayer mediaPlayer { get; set; } = new MediaPlayer();
        private RelayCommand speakCommand;
        public RelayCommand SpeakCommand
        {
            get => speakCommand ?? (speakCommand = new RelayCommand(obj =>
            {
                Word word = obj as Word;
                if(word != null)
                {
                    if(word.PronunciationSource == "Auto")
                    {
                        App.DecksVM.Synthesizer.SpeakAsync(word.Spelling);
                    }
                    else
                    {
                        string path = word.PronunciationSource;
                        string extension = Path.GetExtension(path);
                        if(extension == ".mp3")
                        {
                            PlayMp3(path);
                        }
                        else if(extension == ".wav")
                        {
                            mediaPlayer.Open(new Uri(path));
                            mediaPlayer.Play();
                        }
                    }
                }
            }));
        }

        private static void PlayMp3(string url)
        {
            using (Stream ms = new MemoryStream())
            {
                using (Stream stream = WebRequest.Create(url)
                    .GetResponse().GetResponseStream())
                {
                    byte[] buffer = new byte[32768];
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                }

                ms.Position = 0;
                using (WaveStream blockAlignedStream =
                    new BlockAlignReductionStream(
                        WaveFormatConversionStream.CreatePcmStream(
                            new Mp3FileReader(ms))))
                {
                    using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                    {
                        waveOut.Init(blockAlignedStream);
                        waveOut.Play();
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            System.Threading.Thread.Sleep(100);
                        }
                    }
                }
            }
        }

        #endregion


        #endregion

        #region Properties
        public ObservableCollection<Word> Words { get; set; }

        #region MoreVisibility

        private Visibility moreVisibility = Visibility.Collapsed;
        public Visibility MoreVisibility
        {
            get => moreVisibility;
            set
            {
                moreVisibility = value;
                OnPropertyChanged("MoreVisibility");
            }
        }
        #endregion

        #endregion




        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
