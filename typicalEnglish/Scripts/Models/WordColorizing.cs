using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Rendering;
using System.Windows;
using System.Windows.Media;

namespace typicalEnglish.Scripts.Models
{
    /// <summary>
    /// Class for colorizing spelling of word in examples.
    /// </summary>
    internal class WordColorizing : DocumentColorizingTransformer
    {
        #region Constructor

        /// <summary>
        /// Set highlight word.
        /// </summary>
        /// <param name="hlWord">Speeling that should be colorized.</param>
        public WordColorizing(string hlWord)
        {
            this.hlWord = hlWord.ToLower();
        }

        #endregion

        #region Properties
        /// <summary>
        /// Highlight word.
        /// </summary>
        private string hlWord { get; set; }

        #endregion

        #region Constants

        private const string CANDARA_FONT_FAMILY = "Candara";

        #endregion

        #region Methods
        protected override void ColorizeLine(DocumentLine line)
        {
            int lineStartOffset = line.Offset;
            string text = CurrentContext.Document.GetText(line).ToLower();
            int start = 0;
            int index;
            while ((index = text.IndexOf(hlWord, start)) >= 0)
            {
                base.ChangeLinePart(
                    lineStartOffset + index,
                    lineStartOffset + index + hlWord.Length,
                    (VisualLineElement element) => {
                        Typeface tf = element.TextRunProperties.Typeface;
                        element.TextRunProperties.SetTypeface(new Typeface(
                                new FontFamily(CANDARA_FONT_FAMILY),
                                FontStyles.Normal,
                                FontWeights.Bold,
                                tf.Stretch
                            ));
                    });
                start = index + 1;
            }
        }
        #endregion
    }
}
