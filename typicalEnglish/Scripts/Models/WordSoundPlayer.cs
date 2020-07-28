using NAudio.Wave;
using System.IO;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using typicalEnglish.Scripts.ViewModels;

namespace typicalEnglish.Scripts.Models
{
    class WordSoundPlayer
    {

        #region Constuctor

        /// <summary>
        /// Selecting voice
        /// </summary>
        static WordSoundPlayer()
        {
            synthesizer.SelectVoice(ZIRA_VOICE);
        }

        #endregion

        #region Constants

        private const string AUTO = "Auto";
        private const string ZIRA_VOICE = "Microsoft Zira Desktop";

        #endregion

        #region Properties

        /// <summary>
        /// Auto speaker
        /// </summary>
        private static SpeechSynthesizer synthesizer { get; set; } = new SpeechSynthesizer();

        /// <summary>
        /// Audio player 
        /// </summary>
        private static WaveOut waveOut { get; set; } = new WaveOut();

        #endregion

        #region Methods

        public static void PlayWordSpelling(Word word)
        {
            string source = word.PronunciationSource;
            if (source == AUTO)
                synthesizer.SpeakAsync(word.Spelling);
            else
                PlayAudio(source);
        }
        public async static void PlayAudio(string url)
        {
            await Task.Run(() =>
            {
                AudioFileReader reader = new AudioFileReader(url);
                Play(reader);
            });
        }

        public async static void PlayAudio(Stream str)
        {
            await Task.Run(() =>
            {
                str.Position = 0;
                Mp3FileReader reader = new Mp3FileReader(str);
                Play(reader);
            });
        }

        private async static void Play(IWaveProvider reader)
        {
            await Task.Run(() =>
            {
                waveOut.Init(reader);
                waveOut.Play();
            });
        }
        #endregion
    }
}