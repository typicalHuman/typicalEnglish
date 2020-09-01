using NAudio.Wave;
using System.ComponentModel;
using System.IO;
using System.Media;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using typicalEnglish.Scripts.ViewModels;

namespace typicalEnglish.Scripts.Models
{
    /// <summary>
    /// Class for playing sounds in application.
    /// </summary>
    class WordSoundPlayer
    {
        #region Constuctor

        /// <summary>
        /// Selecting voice
        /// </summary>
        static WordSoundPlayer()
        {
            synthesizer.SelectVoice(ZIRA_VOICE);
            //Cancel rest calls of synthesizer.
            synthesizer.SpeakCompleted += (obj, e) =>
            {
                synthesizer.SpeakAsyncCancelAll();
            };
            player.LoadCompleted += delegate (object sender, AsyncCompletedEventArgs e)
            {
                player.Play();
            };
        }

        #endregion

        #region Constants

        private const string AUTO = "Auto";
        private const string ZIRA_VOICE = "Microsoft Zira Desktop";

        #endregion

        #region Properties

        /// <summary>
        /// Auto speaker.
        /// </summary>
        private static SpeechSynthesizer synthesizer { get; set; } = new SpeechSynthesizer();

        /// <summary>
        /// Sound player.
        /// </summary>
        private static SoundPlayer player { get; set; } = new SoundPlayer();

        /// <summary>
        /// Word which spelling will speak synthesizer.
        /// </summary>
        private static Word wordToSpeak { get; set; }

        #endregion

        #region Methods
        /// <param name="word">Word which spelling will speak synthesizer.</param>
        public static void PlayWordSpelling(Word word)
        {
            wordToSpeak = word;
            string source = word.PronunciationSource;
            if (source == AUTO)
                synthesizer.SpeakAsync(word.Spelling);
            else
                PlayAudio(source);
        }

        /// <summary>
        /// Play audio by url.
        /// </summary>
        /// <param name="url">Url must contains file with extension.</param>
        public static void PlayAudio(string url)
        {
            player.SoundLocation = url;
            player.Stream = null;
            Play();
        }

        /// <summary>
        /// Play audio from application resources.
        /// </summary>
        /// <param name="str">Stream of audio.</param>
        public static void PlayAudio(Stream str)
        {
            player.SoundLocation = null;
            player.Stream = str;
            Play();
            str.Position = 0;
        }

        private static void Play()
        {
            try
            {
                player.LoadAsync();
            }
            catch(FileNotFoundException){
                wordToSpeak.PronunciationSource = AUTO;
            }

        }
        #endregion
    }
}