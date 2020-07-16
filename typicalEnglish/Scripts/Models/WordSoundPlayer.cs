using NAudio.Wave;
using System;
using System.IO;
using System.Net;
using System.Windows.Media;
using typicalEnglish.Scripts.ViewModels;

namespace typicalEnglish.Scripts.Models
{
    class WordSoundPlayer
    {
        #region Constants

        private const string AUTO = "Auto";
        private const string MP3_EXT = ".mp3";
        private const string WAV_EXT = ".wav";
        private const int ARRAY_SIZE = 32768;

        #endregion

        #region Properties

        private static MediaPlayer mediaPlayer { get; set; } = new MediaPlayer();

        #endregion

        #region Methods

        public static void PlaySound(Word word)
        {
            if (word.PronunciationSource == AUTO)
            {
                App.DecksVM.Synthesizer.SpeakAsync(word.Spelling);
            }
            else
            {
                string path = word.PronunciationSource;
                string extension = Path.GetExtension(path);
                if (extension == MP3_EXT)
                {
                    PlayMp3(path);
                }
                else if (extension == WAV_EXT)
                {
                    mediaPlayer.Open(new Uri(path));
                    mediaPlayer.Play();
                }
            }
        }
        private static void PlayMp3(string url)
        {
            using (Stream ms = new MemoryStream())
            {
                WriteStream(ms, url);
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
        private static void WriteStream(Stream ms, string url)
        {
            using (Stream stream = WebRequest.Create(url)
                   .GetResponse().GetResponseStream())
            {
                byte[] buffer = new byte[ARRAY_SIZE];
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
            }
        }

        #endregion
    }
}